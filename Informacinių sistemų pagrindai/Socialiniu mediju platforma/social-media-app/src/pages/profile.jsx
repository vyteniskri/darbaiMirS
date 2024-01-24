import React, { useState, useEffect } from "react";
import "../css/profile.css";
import { Link, useParams } from "react-router-dom";
import { auth } from "../App";
import { getStorage, ref, listAll, getDownloadURL } from "firebase/storage";
import { Modal, Button, Form } from "react-bootstrap";
import FileView from "./fileView";

function profile() {
  const [userFiles, setUserFiles] = useState([]);
  const { userId } = useParams();
  const user = auth.currentUser;
  useEffect(() => {
    const fetchUserFiles = async () => {
      // Fetch the list of files associated with the current user
      const storage = getStorage();
      const user = auth.currentUser;
      
      const targetUserId = userId;
      
      if (targetUserId) {
        const userFilesRef = ref(storage, `user_files/${user.uid}`);
        try {
          const result = await listAll(userFilesRef);
          const fileUrls = await Promise.all(
            result.items.map(async (file) => {
              
              const [name, type] = file.name.split("."); // Assuming file names have extensions
              const downloadURL = await getDownloadURL(file);
              return { name, type, url: downloadURL };
            })
          );
          setUserFiles(fileUrls);
        } catch (error) {
          console.error("Error fetching user files:", error.message);
        }
      }
    };

    fetchUserFiles();
  }, [userId]);

  return (
    <>
      {/* TOP HEADER */}
      <div className="main-container">
        <header className="block">
          <ul className="header-menu horizontal-list">
          <li>
              <Link className="header-menu-tab" to={`/uploads/${userId}`}>
                <span className="icon entypo-cog scnd-font-color"></span>
                Uploads
              </Link>
            </li>
            <li>
              <a className="header-menu-tab" href="#1">
                <span className="icon entypo-cog scnd-font-color"></span>
                Settings
              </a>
            </li>
            <li>
              <a className="header-menu-tab" href="#2">
                <span className="icon fontawesome-user scnd-font-color"></span>
                Account
              </a>
            </li>
            <li>
              <a className="header-menu-tab" href="#5">
                <span className="icon fontawesome-star-empty scnd-font-color"></span>
                Followers
              </a>
            </li>
            {user && user.uid === userId && (
              <li>
                <Link className="header-menu-tab" to={`/savedPosts/${userId}`}>
                  <span className="icon entypo-cog scnd-font-color"></span>
                  Saved Posts
                </Link>
              </li>
            )}
            <li>
              <button className="change-profile-button" href="">
                Change profile picture
              </button>
            </li>
          </ul>
          <div className="profile-menu">
            <p>
              Me{" "}
              <a href="#26">
                <span className="entypo-down-open scnd-font-color"></span>
              </a>
            </p>
            <div className="profile-picture small-profile-picture">
              <img
                width="40px"
                alt="Anne Hathaway picture"
                src="https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/Default_pfp.svg/2048px-Default_pfp.svg.png"
              ></img>
            </div>
          </div>
        </header>
       
      </div>
    </>
  );
}

export default profile;
