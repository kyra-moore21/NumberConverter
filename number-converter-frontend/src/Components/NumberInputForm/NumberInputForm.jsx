import { useNavigate } from "react-router-dom";
import React, { useState } from "react";
import styles from "./NumberInputForm.module.css";

const NumberInputForm = ({ apiRequest }) => {
  const [errorMsg, setErrorMessage] = useState("");
  const [number, setNumbers] = useState("");
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    event.preventDefault();

    if (number.trim() === "") {
      setErrorMessage("Input cannot be blank. Please enter some numbers.");
      return;
    }

    const numbersArray = number.split(",").map((num) => num.trim());

    if (numbersArray.some(isNaN)) {
      setErrorMessage(
        "Please enter only numbers seperated by commas. Ex. 12, 34, 56"
      );
      return;
    }
    if (
      numbersArray.some(
        (num) => num > Number.MAX_SAFE_INTEGER || num < Number.MIN_SAFE_INTEGER
      )
    ) {
      setErrorMessage(
        "Please enter a number less than 2,147,483,647 or greater than -2,147,483,647"
      );
      return;
    }
    if(
      numbersArray.some(
        (num) => num.includes(".")
    ))
    {
      setErrorMessage(
        "No decimals allowed. Please enter a whole numbers only. Ex. 12, 34, 56"
      );
      return;
    }
    setErrorMessage("");
    apiRequest(numbersArray, navigate);
  };
  return (
    <div className={styles.Container}>
      <div className={styles.Content}>
        <h1 className={styles.Title} >Number Converter</h1>
      <form onSubmit={handleSubmit}>
        <div>
        <label htmlFor="stringOfNums" className={styles.label}>
          Enter Numbers: <div className={styles.small}>(seperated by commas)
          </div>
        </label> 
        </div>
        <div className={styles.input}>
            <input
              type="text"
              value={number}
              onChange={(e) => setNumbers(e.target.value)}
              id="stringOfNums"
              placeholder="ex: 1, 34, 5665, 21"
            />
        </div>
        <div className={styles.danger}>
        {errorMsg && (
          <>
            <i className={`${styles.icon} bi bi-exclamation-circle me-1`}></i>
            {errorMsg}
          </>
        ) }
        </div>
        <div>
        <button className={styles.button} type="submit">
          Convert
        </button>
        </div>
       
      </form>
      </div>
    </div>
  );
};

export default NumberInputForm;
