import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import NavBar from "./navbar";
import Login from "./pages/login";
import Home from "./pages/home";
import Profile from "./pages/profile";
import Analytics from "./pages/analytics";
import UploadsPage from "./pages/uploads";
import SavedPosts from "./pages/savedPosts";
import { Route, Routes, useParams } from "react-router-dom";

//Allows the use of bootstrap for easy css
//https://getbootstrap.com/docs/5.3/getting-started/introduction/
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.min.js";

// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
import { getAuth } from "firebase/auth";
import { getFirestore } from "firebase/firestore";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyBrMzPUe4ANBqG6_7Re8aJxu3HuhjbRtBU",
  authDomain: "social-media-app-3587e.firebaseapp.com",
  projectId: "social-media-app-3587e",
  storageBucket: "social-media-app-3587e.appspot.com",
  messagingSenderId: "214674043205",
  appId: "1:214674043205:web:38c858ca867c90ebb7ce2c",
  measurementId: "G-SN79NN2E80",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);
//Initialize Firebase auth
export const auth = getAuth(app);
const db = getFirestore(app);
export { db };

function App() {
  return (
    <>
      <NavBar />
      <div className="App">
        {/* Responsible for routing user to different pages, to add a new path copy paste Route line and change 'path', 'element' values
        additional changes need to be made by adding 'Link' to buttons (see navbar.jsx) */}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/profile/:userId" element={<Profile />} />
          <Route path="/analytics" element={<Analytics />} />
          <Route path="/uploads/:userId" element={<UploadsPage />} />
          <Route path="/savedPosts/:userId" element={<SavedPosts />} />
        </Routes>
      </div>
    </>
  );
  
}

export default App;
