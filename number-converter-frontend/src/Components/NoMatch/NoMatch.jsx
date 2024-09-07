import React from "react";
import styles from "./NoMatch.module.css";

const NoMatch = () => {
  return (
    <div className={styles.Center}>
      <h1>404 - Page Not Found</h1>
      <p>The requested page does not exist.</p>
    </div>
  );
};

export default NoMatch;
