//Function for opening an interaction window when clicking on a file
import { Link, useNavigate, useLocation } from "react-router-dom";
import React, { useEffect, useState } from "react";
import { Modal, Button, Form } from "react-bootstrap";
import { auth } from "../App";
import { db } from "../App";
import { collection, setDoc, doc, query, where, getDocs, onSnapshot, deleteDoc, addDoc, getDoc } from "firebase/firestore";
import { v4 as uuidv4 } from 'uuid';

import {
  getStorage,
  ref,
  deleteObject,
  listAll,
  getDownloadURL,
} from "firebase/storage";


export default function FileView({ file, catalogName }) {
  const [show, setShow] = useState(false);
  const [likesCount, setLikesCount] = useState(0); //Patikimai
  const [unsubscribe, setUnsubscribe] = useState(null);
  const [dislikesCount, setDislikesCount] = useState(0); //Nepatikimai
  const [comment, setComment] = useState(''); //Vieno naudotojo komentaraui
  const [comments, setComments] = useState([]); //Visi komentarai is duombazes
  const navigate = useNavigate(); //I Profili
  const handleClose = () => setShow(false);

  const [likePressed, setLikePressed] = useState(false); //Paspaustas arba nepaspaustas mygtukas
  const [dislikePressed, setDislikePressed] = useState(false); //Paspaustas arba nepaspaustas mygtukas
  const [savePressed, setSavePressed] = useState(false); // New state for tracking whether the post is saved

  useEffect(() => {
    const unsubscribeComments = fetchComments(file.name);
    setUnsubscribe(unsubscribeComments);

    const fetchPreviousActionsLikeOrDislike = async () => {
      const patikimai = collection(db, "patikimai");
      const userId = user.uid;
  
      const likeSnapshot = await getDocs(
        query(patikimai, where("post_id", "==", file.name), where("user_id", "==", userId), where("tipas", "==", 'like'))
      );
  
      const dislikeSnapshot = await getDocs(
        query(patikimai, where("post_id", "==", file.name), where("user_id", "==", userId), where("tipas", "==", 'dislike'))
      );
  
      setLikePressed(likeSnapshot.size > 0);
      setDislikePressed(dislikeSnapshot.size > 0);
    };

    fetchPreviousActionsLikeOrDislike();

    const fetchPreviousActionsSavedPost = async () => {
      const issaugoti = collection(db, "issaugotiPostai");
      const userId = user.uid;

      const savedSnapshot = await getDocs(
        query(issaugoti, where("post_id", "==", file.name), where("user_id", "==", userId))
      );

      setSavePressed(savedSnapshot.size > 0);
    }

    fetchPreviousActionsSavedPost();
    return () => {
      if (unsubscribe) {
        unsubscribe();
      }
    };
  }, [file.name]);


  const handleShow = () => {
    const unsubscribeLikesDislikes = fetchLikesAndDislikesCount(file.name); 
    const unsubscribeComments = fetchComments(file.name);
    setShow(true);
    setUnsubscribe(unsubscribeLikesDislikes);
    setUnsubscribe(unsubscribeComments);
  };

  const storage = getStorage();
  const user = auth.currentUser;

  const handleSave = async () => {
    const timestamp = new Date();
    const savedPosts = collection(db, "issaugotiPostai");
    const docRef = doc(savedPosts, `${file.name}_${user.uid}`);

    try {
      const docSnapshot = await getDocs(query(savedPosts, where("post_id", "==", file.name), where("user_id", "==", user.uid)));
      
      if (docSnapshot.size > 0) {
        const docToDelete = doc(savedPosts, `${file.name}_${user.uid}`);
        await deleteDoc(docToDelete);
        console.log(`SavedPost deleted`);
        setSavePressed(false);
      } else {
        await setDoc(docRef, {
          kurejo_id: file.user_id,
          user_id: user.uid,
          post_id: file.name,
          data: timestamp,
          type: file.type,
        });
        console.log("Post saved successfully");
        setSavePressed(true);
      } 
  } catch (error) {
    console.error("Error saving post: ", error);
  }
};


  const handleDeleteComment = async (unikalusId) => {
    const komentaras = collection(db, "komentarai");
  
    try {
      const q = query(komentaras, where("unikalus_id", "==", unikalusId));
      const querySnapshot = await getDocs(q);
  
      querySnapshot.forEach(async (D) => {
        const docRef = doc(komentaras, D.id);
        await deleteDoc(docRef);
        
      });
    } catch (error) {
      console.error("Error deleting comment: ", error);
    }
  };

  const fetchComments = async (postId) => {
    const commentsCollection = collection(db, "komentarai");
    const q = query(commentsCollection, where("iraso_id", "==", postId));

    const unsubscribe = onSnapshot(q, (querySnapshot) => {
      const fetchedComments = [];
      querySnapshot.forEach((doc) => {
        fetchedComments.push(doc.data());
      });
      setComments(fetchedComments);
    });

    return unsubscribe;
  };

  const handleComment = async () => {
    if (comment.trim() === '') {
      // Don't save an empty comment
      return;
    }

    const timestamp = new Date();
    const comments = collection(db, "komentarai");

    try {
      const unikalusId = uuidv4(); // Generate a unique ID
      await addDoc(comments, {
        user_id: user.uid,
        iraso_id: file.name,
        tekstas: comment,
        data: timestamp,
        unikalus_id: unikalusId,
      });

      console.log("Comment added successfully");

      // Clear the comment input after submitting
      setComment('');
    } catch (error) {
      console.error("Error adding comment: ", error);
    }

  };

  const fetchLikesAndDislikesCount = async (postId) => {
    const patikimai = collection(db, "patikimai");
    const q = query(patikimai, where("post_id", "==", postId));

    const unsubscribe = onSnapshot(q, (querySnapshot) => {
      let likes = 0;
      let dislikes = 0;
  
      querySnapshot.forEach((doc) => {
        const data = doc.data();
        if (data.tipas === 'like') {
          likes++;
        } else if (data.tipas === 'dislike') {
          dislikes++;
        }
      });
  
      setLikesCount(likes);
      setDislikesCount(dislikes);
    })
    return unsubscribe
  };


  const saveLikeOrDislike = async (postName, userId, type) => {
    const timestamp = new Date();
    const customDocId = `${postName}_${userId}`;
  
    const patikimai = collection(db, "patikimai");
    const docRef = doc(patikimai, customDocId);
  
    try {
      const docSnapshot = await getDocs(query(patikimai, where("post_id", "==", postName), where("user_id", "==", userId), where("tipas", "==", type)));
  
      if (docSnapshot.size > 0) {
        // User has already liked or disliked, delete the record
        const docToDelete = doc(patikimai, customDocId);
        await deleteDoc(docToDelete);
        console.log(`Like/Dislike deleted with ID: ${customDocId}`);
        setLikePressed(false);
        setDislikePressed(false);
      } else {
        // User hasn't liked or disliked yet, add a new record
        await setDoc(docRef, {
          user_id: userId,
          post_id: postName,
          tipas: type, // 'like' or 'dislike'
          data: timestamp,
        });
        console.log(`Like/Dislike added with ID: ${customDocId}`);
      }
    } catch (error) {
      console.error("Error adding/deleting like/dislike: ", error);
    }
  };

  const handleLike = () => {
    saveLikeOrDislike(file.name, user.uid, 'like');
    setLikePressed(true);
    setDislikePressed(false); // Reset the dislike state
    
  };

  const handleDislike = () => {
    saveLikeOrDislike(file.name, user.uid, 'dislike');
    setDislikePressed(true);
    setLikePressed(false); // Reset the like state
    
  };

  const handleGoToProfile = () => {
    // Navigate to the profile page
    navigate(`/profile/${catalogName}`);
    
  };


  const handleDelete = () => {
    
    const fileRef = ref(
      storage,
      `user_files/${user.uid}/${file.name}.${file.type}`
    );
    deleteObject(fileRef)
      .then(() => {
        console.log("File deleted successfully!");
        window.location.reload();
      })
      .catch((error) => {
        console.error("Error deleting file:", error.message);
      });
  };

  const handleDownload = () => {
    getDownloadURL(
      ref(storage, `user_files/${user.uid}/${file.name}.${file.type}`)
    )
      .then((url) => {
        const xhr = new XMLHttpRequest();
        xhr.responseType = "blob";

        xhr.onload = () => {
          const blob = xhr.response;

          // Create a download link
          const downloadLink = document.createElement("a");
          downloadLink.href = URL.createObjectURL(blob);
          downloadLink.download = file.name; // Set the file name

          // Simulate a click on the download link
          document.body.appendChild(downloadLink);
          downloadLink.click();

          // Clean up
          document.body.removeChild(downloadLink);
        };

        xhr.open("GET", url);
        xhr.send();
      })
      .catch((error) => {
        console.error("Error getting download URL:", error.message);
      });
  };

  return (
    <>
      <img
        src={file.url}
        alt={file.name}
        className="users-file"
        onClick={handleShow}
      />
      {user && (
        <Modal show={show} onHide={handleClose} className="modal-style">
          <Modal.Header closeButton>{file.user_id}
            {!location.pathname.includes("/uploads") && (
              <Button
                variant="info"
                onClick={handleGoToProfile}
                className="ms-auto"
              >
                Go to profile
              </Button>
            )}
          </Modal.Header>
          <Modal.Title>{file.failo_pavadinimas}</Modal.Title>
          <Modal.Body>
            <img
              src={file.url}
              alt={file.name}
              className="modal-file"
              style={{
                maxWidth: "100%",
                maxHeight: "100%",
                width: "auto",
                height: "auto",
              }}
            />
            <Button
              variant={likePressed ? "success" : "outline-success"}
              onClick={handleLike}
            >
              Like ({likesCount})
            </Button>
            <Button
              variant={dislikePressed ? "danger" : "outline-danger"}
              onClick={handleDislike}
            >
              Dislike ({dislikesCount})
            </Button>
            <Form>
              <Form.Group controlId="commentForm">
                <Form.Label>Leave a Comment:</Form.Label>
                <Form.Control
                  as="textarea"
                  rows={3}
                  placeholder="Type your comment here"
                  value={comment}
                  onChange={(e) => setComment(e.target.value)}
                />
              </Form.Group>
              <Button variant="primary" onClick={handleComment}>
                Submit 
              </Button>
            </Form>

             {/* Display comments */}
          <div>
            <h5>Comments:</h5>
            <ul>
              {comments.map((comment, index) => (
                <li key={index}>
                  <strong>{comment.user_id}:</strong> {comment.tekstas}
                  {comment.user_id === user.uid && (
                   <> 
                   <Button variant="danger"  size="sm" onClick={() => handleDeleteComment(comment.unikalus_id)}>
                     Delete comment
                   </Button>
                  </>
                  )}
                </li>
              ))}
            </ul>
          </div>

            {/* Additional file details if needed */}
            <p>File Name: {file.name}</p>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="danger" onClick={handleDelete}>
              Delete
            </Button>
            <Button variant="primary" onClick={handleDownload}>
              Download
            </Button>
            <Button variant={savePressed ? "success" : "outline-success"} onClick={handleSave}>
               Save
            </Button>
          </Modal.Footer>
        </Modal>
      )}
    </>
  );
}
