import React, { useState, useEffect } from "react";
import "../css/profile.css";
import { collection, query, getDocs, where } from "firebase/firestore";
import { getStorage, ref, listAll, getDownloadURL } from "firebase/storage";
import { Link, useParams } from "react-router-dom";
import { db } from "../App";
import FileView from "./fileView";

function SavedPosts() {
  const [userFiles, setUserFiles] = useState([]);
  const { userId } = useParams();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const savedPostsCollection = collection(db, "issaugotiPostai");
        const q = query(savedPostsCollection, where("user_id", "==", userId));

        const querySnapshot = await getDocs(q);
        const fetchedSavedPosts = [];

        querySnapshot.forEach((doc) => {
          fetchedSavedPosts.push(doc.data());
        });


        const storage = getStorage();
        const allFilesRef = ref(storage, "user_files");
        const result = await listAll(allFilesRef);


        const AllFiles = await Promise.all(
          result.prefixes.map(async (item) => {
            const catalogName = item.name.split("/").pop(); 
            const result2 = await listAll(item);
            const filesData = await Promise.all(
              result2.items.map(async (file) => {
                //console.log(file.name);
                const [name, type] = file.name.split("."); // Assuming file names have extensions
                const downloadURL = await getDownloadURL(file);
                return { name, type, url: downloadURL };
              })
            );
            return { catalogName, filesData };
          })
        );



        const filesArray = await Promise.all(
          AllFiles.map(async ({ catalogName, filesData }) => {
            const filteredFilesList = filesData.filter((file) => {
              return fetchedSavedPosts.some((post) => post.post_id === file.name);
            });
        
            const filteredFilesArray = await Promise.all(
              filteredFilesList.map(async (file) => {
                
                const name = file.name;
                const type = file.type;
                const url = file.url;


                
                const associatedData = fetchedSavedPosts.find((post) =>  file.name === post.post_id);
                const kurejo_id = associatedData ? associatedData.kurejo_id : null;
                const failo_pavadinimas = associatedData ? associatedData.post_id : null;
                console.log(kurejo_id);
                const user_id = kurejo_id;
                return { name, type, url, user_id, failo_pavadinimas };
              })
            );
        
            return {
              catalogName,
              files: filteredFilesArray,
            };
          })
        );

 
        setUserFiles(filesArray.flat());
      } catch (error) {
        console.error("Error fetching data:", error.message);
      }
    };
    if (userId) {
      fetchData();
    }
  }, [userId]);
  
  return (
    <>
      <h1 className="center-text">Uploads page:</h1>
        
      <div className="center-content">
        {userFiles.map((entry) => (
          <div key={entry.catalogName}>
            {entry.files.map((file) => (
              <div key={file.name}>
                {file.type.startsWith("jpg") || file.type.startsWith("png") ? (
                  <FileView file={file} catalogName={entry.catalogName} />
                ) : file.type.startsWith("mp4") ||
                  file.type.startsWith("avi") ||
                  file.type.startsWith("webm") ||
                  file.type.startsWith("gif") ? (
                  <video
                    controls
                    className="users-file"
                    onClick={async () => {
                      console.log("Video clicked");
                    }}
                    onLoadedMetadata={(e) => {
                      // Your existing video handling logic
                    }}
                  >
                    <source src={file.url} type={file.type} />
                    Your browser does not support the video tag.
                  </video>
                ) : (
                  <p>Unsupported file type: {file.type}</p>
                )}
              </div>
            ))}
          </div>
        ))}
      </div>
    </>
  );
}
export default SavedPosts;