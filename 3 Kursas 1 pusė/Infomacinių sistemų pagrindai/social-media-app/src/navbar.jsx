import React, { useState, useEffect } from "react";
import "./css/navbar.css";
import { Link, useNavigate } from "react-router-dom";
import { auth, db } from "./App";
import { Modal, Button, Form } from "react-bootstrap";
import { collection, setDoc, doc, query, where, getDocs, onSnapshot, deleteDoc, addDoc, getDoc } from "firebase/firestore";

import firebase from "firebase/compat/app";
import "firebase/compat/auth";
import "firebase/compat/storage";

const firebaseConfig = {
  apiKey: "AIzaSyBrMzPUe4ANBqG6_7Re8aJxu3HuhjbRtBU",
  authDomain: "social-media-app-3587e.firebaseapp.com",
  projectId: "social-media-app-3587e",
  storageBucket: "social-media-app-3587e.appspot.com",
  messagingSenderId: "214674043205",
  appId: "1:214674043205:web:38c858ca867c90ebb7ce2c",
  measurementId: "G-SN79NN2E80",
};

firebase.initializeApp(firebaseConfig);

function navbar() {
  const [user, setUser] = useState(null);
  const navigate = useNavigate();
  const [show, setShow] = useState(false);
  const [caption, setCaption] = useState("");
  const [selectedFile, setSelectedFile] = useState(null);

  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);

  useEffect(() => {
    const unsubscribe = auth.onAuthStateChanged((user) => {
      if (user) {
        setUser(user);
      } else {
        setUser(null);
      }
    });

    // Cleanup subscription on unmount
    return () => unsubscribe();
  }, []);

  const handleLogout = () => {
    auth.signOut();
    navigate("/");
    console.log("logged out");
  };

  const handleUploadFile = () => {
    if (selectedFile) {
      const storageRef = firebase
        .storage()
        .ref(`user_files/${user.uid}/${selectedFile.name}`);
      const uploadTask = storageRef.put(selectedFile);

      // Handle the upload task events
      uploadTask.on(
        "state_changed",
        (snapshot) => {
          // Progress, if needed
          const progress =
            (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
          console.log(`Upload progress: ${progress}%`);
        },
        (error) => {
          // Handle errors during upload
          console.error("Upload error:", error.message);
        },
        async () => {
          // Handle successful upload
          console.log("File uploaded successfully!");
  
          // Get download URL of the uploaded file
          
          // Save file details to Firestore
          const ikelimai = collection(db, "ikelimai");
          const timestamp = new Date();

          try {
            await addDoc(ikelimai, {
              user_id: user.uid,
              failo_pavadinimas: selectedFile.name,
              data: timestamp,
            });
            console.log("File details saved to Firestore with ID:");
  
            // Optionally, you can navigate to the profile page or perform other actions after upload
            window.location.reload();
            
          } catch (error) {
            console.error("Error saving file details to Firestore:", error.message);
          }
        }
      );


    }
    console.log(caption);
    setShow(false);
  };

  const handleFileChange = (event) => {
    const file = event.target.files[0];
    setSelectedFile(file);
  };

  return (
    <nav className="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
      <Link className="navbar-brand" to="/">
        Social media app
      </Link>
      <button
        className="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div className="navbar-nav">
        {user ? (
          <Link className="nav-item nav-link active" to="/">
            Home <span className="sr-only"></span>
          </Link>
           ) : null}
          {user ? null : (
            <>
              {" "}
              <Link className="nav-item nav-link" to="/login">
                Login
              </Link>
            </>
          )}

          {user ? (
            <>
              <Link className="nav-item nav-link" to={`/profile/${user.uid}`}>
                Profile
              </Link>
              <Link className="nav-item nav-link" to="/analytics">
                Analytics
              </Link>
            </>
          ) : null}

          {user ? (
            <>
              <div className="ml-auto" style={{ marginLeft: "1000px" }}>
                <button onClick={handleLogout}>Logout</button>
                
                {location.pathname.includes(`/profile/${user.uid}`) && (
                      <button
                        style={{ marginLeft: "50px" }}
                        onClick={handleShow}
                        className="ms-auto"
                      >
                       Upload File
                      </button>
                    )}
                <Modal show={show} onHide={handleClose} className="modal-style">
                  <Modal.Header closeButton>
                    <Modal.Title>Post something!</Modal.Title>
                  </Modal.Header>
                  <Modal.Body>
                    Select a picture or a video to upload and write a caption of
                    your choice!
                  </Modal.Body>
                  <Modal.Body>
                    <Form.Group controlId="formCaption" className="mb-3">
                      <Form.Label>Caption</Form.Label>
                      <Form.Control
                        type="text"
                        placeholder="Enter caption"
                        value={caption}
                        onChange={(e) => setCaption(e.target.value)}
                      />
                    </Form.Group>
                    <Form.Group controlId="formFile" className="mb-3">
                      <Form.Label>Select a file</Form.Label>
                      <Form.Control type="file" onChange={handleFileChange} />
                    </Form.Group>
                  </Modal.Body>
                  <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                      Close
                    </Button>
                    <Button variant="primary" onClick={handleUploadFile}>
                      Upload
                    </Button>
                  </Modal.Footer>
                </Modal>
              </div>
            </>
          ) : null}
        </div>
      </div>
    </nav>
  );
}

export default navbar;
