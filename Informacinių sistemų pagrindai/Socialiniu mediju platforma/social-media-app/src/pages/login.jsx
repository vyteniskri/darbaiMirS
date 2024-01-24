import React, { useState } from "react";
import { useNavigate } from "react-router-dom";

import "../css/login.css";

//auth is used to check if the user is logged in, along with other futures
import { auth } from "../App";

import {
  createUserWithEmailAndPassword,
  signInWithEmailAndPassword,
} from "firebase/auth";

function Login() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const register = async (email, password) => {
    try {
      const userCredential = await createUserWithEmailAndPassword(
        auth,
        email,
        password
      );
      console.log("Registration Successful");
    } catch (error) {
      console.log(error.message);
    }
  };

  const login = async (email, password) => {
    try {
      const userCredential = await signInWithEmailAndPassword(
        auth,
        email,
        password
      );
      navigate("/");
      console.log("Login Successful");
    } catch (error) {
      console.log(error.message);
    }
  };

  return (
    <div className="login-box">
      <h2>Login or Register</h2>
      <form>
        <div className="user-box">
          <input
            type="text"
            name="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
          <label>Email</label>
        </div>
        <div className="user-box">
          <input
            type="password"
            name="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
          <label>Password</label>
        </div>
        <button type="button" onClick={() => login(email, password)}>
          Login
        </button>
        <button type="button" onClick={() => register(email, password)}>
          Register
        </button>
      </form>
    </div>
  );
}

export default Login;
