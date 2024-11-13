import React, { useState, useEffect } from "react";
import "../css/homepage.css";
import { auth, db } from "../App";
import { getStorage, ref, listAll, getDownloadURL } from "firebase/storage";
import { collection, setDoc, doc, query, where, getDocs, onSnapshot, deleteDoc, addDoc, getDoc } from "firebase/firestore";
import FileView from "./fileView";

function Home() {
  const [userFiles, setUserFiles] = useState([]);
  const user = auth.currentUser;

  useEffect(() => {
    const fetchUserFiles = async (directoryRef) => {
      try {
        const ikelimai = collection(db, "ikelimai");
        const userId = user.uid;
        const q = query(ikelimai);
        const querySnapshot = await getDocs(q);
        const fetchedFiles = [];
       
         
          querySnapshot.forEach((doc) => {
            //console.log(doc.data().user_id);
            fetchedFiles.push(doc.data());
          });
          
          const result = await listAll(directoryRef);

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
                const fileNameWithType = file.name + "." + file.type;
                
          
                return fetchedFiles.some((post) => fileNameWithType === post.failo_pavadinimas && catalogName === post.user_id);
              });
          
              const filteredFilesArray = await Promise.all(
                filteredFilesList.map(async (file) => {
                  
                  const name = file.name;
                  const type = file.type;
                  const url = file.url;

                  const fileNameWithType = file.name + "." + file.type;

                  const associatedData = fetchedFiles.find((post) => fileNameWithType === post.failo_pavadinimas && catalogName === post.user_id);
                  const user_id = associatedData ? associatedData.user_id : null;
                  const failo_pavadinimas = associatedData ? associatedData.failo_pavadinimas : null;
                  
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
          localStorage.setItem("userFiles", JSON.stringify(filesArray.flat()));
      } catch (error) {
        console.error("Error fetching user files:", error.message);
        // Handle the error gracefully, you may want to set an error state or log it as needed
      }
    };
    if (user) {
    const storage = getStorage();
    const userFilesRef = ref(storage, "user_files"); // Update this path as per your structure
    console.log(user.uid);
    fetchUserFiles(userFilesRef);
    }

   
  }, [user]); 

  useEffect(() => {
    // Load data from localStorage on component mount
    const storedUserFiles = localStorage.getItem("userFiles");
    if (storedUserFiles) {
      setUserFiles(JSON.parse(storedUserFiles));
      
    }
  }, []);

  return (
    <>
      <h1 className="center-text">Home Page:</h1>

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

export default Home;