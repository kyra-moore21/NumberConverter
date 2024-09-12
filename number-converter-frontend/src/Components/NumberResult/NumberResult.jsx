import React from "react";
import { useNavigate } from "react-router-dom";
import styles from "./NumberResult.module.css";
import { useEffect } from "react";

const NumberResult = ({ converted }) => {
  const navigate = useNavigate();
  useEffect(() => {
    if (converted.length === 0) {
      navigate("/");
    }
  }, [converted, navigate]);
  return (
    <div className={styles.Container}>
      <div className={styles.Content}>
      <h1 className={styles.Title}>Sorted Words:</h1>
      <ul className={styles.ListGroup} >
        {converted.map((number, id) => {
          return (
            <li key={id} className={styles.ListItem}>
              {number.over9000 ? (
                //display an img if over 9000
                <img
                  className={styles.Img}
                  src="/assests/over9000.jpg"
                  alt={number.word}
                  title={number.word}
                />
              ) : (
                <span>{number.word},</span>
              )}
            </li>
          );
        })}
      </ul>

      <button className={styles.Button} onClick={() => navigate(-1)}>
        Convert More Numbers
      </button>

    </div>
    </div>
  );
};

export default NumberResult;
