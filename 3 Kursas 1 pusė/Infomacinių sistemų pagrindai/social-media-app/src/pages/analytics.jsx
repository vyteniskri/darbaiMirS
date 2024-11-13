import React from "react";
import "../css/profile.css";

function analytics() {
  return (
    <>
      {/* Analytics Header */}
      <div className="main-container">
        <header className="block">
          <ul className="header-menu horizontal-list">
            <li>
              <a className="header-menu-tab" href="#time-spent">
                <span className="icon entypo-cog scnd-font-color"></span>
                Time Spent
              </a>
            </li>
            <li>
              <a className="header-menu-tab" href="#activity">
                <span className="icon fontawesome-user scnd-font-color"></span>
                Activity
              </a>
            </li>
            <li>
              <a className="header-menu-tab" href="#like-dislike">
                <span className="icon fontawesome-star-empty scnd-font-color"></span>
                Like/Dislike
              </a>
            </li>
            <li>
              <a className="header-menu-tab" href="#interactions">
                <span className="icon fontawesome-comment scnd-font-color"></span>
                Interactions
              </a>
            </li>
          </ul>
        </header>
       {/* Analytics Content */}
        <div className="main-block-info">
          <div className="analytics-category" id="time-spent">
            <h2>Time Spent</h2>
            {/* Add content for Time Spent here */}
          </div>
          <div className="analytics-category" id="activity">
            <h2>Activity</h2>
            {/* Add content for Activity here */}
          </div>
          <div className="analytics-category" id="like-dislike">
            <h2>Like/Dislike</h2>
            {/* Add content for Like/Dislike here */}
          </div>
          <div className="analytics-category" id="interactions">
            <h2>Interactions</h2>
            {/* Add content for Interactions here */}
          </div>
        </div>
      </div>
    </>
  );
}


export default analytics;
