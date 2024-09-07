import React, { useState } from "react";
import axios from "axios";
import NumberInputForm from "./Components/NumberInputForm/NumberInputForm";
import NumberResult from "./Components/NumberResult/NumberResult";
import { Routes, Route } from "react-router-dom";
import Navbar from "./Components/Navbar/Navbar";
import NoMatch from "./Components/NoMatch/NoMatch";
import styles from "./App.module.css";

function App() {
  const [converted, setConvertedNumbers] = useState([]);

  const apiRequest = (numbersArray, navigate) => {
    axios
      .post("https://localhost:7054/api/NumberConverter/sort", {
        numbers: numbersArray,
      })
      .then((response) => {
        console.log("Numbers Converted Sucessfully", response.data);
        setConvertedNumbers(response.data);
        navigate("/NumberResult");
      })
      .catch((error) => {
        console.error("An error occured please try again", error);
      });
  };

  return (
    <>
      <Navbar/>
      <div className={styles.App} >
      <Routes>
        <Route path="/" element={<NumberInputForm apiRequest={apiRequest} />} />
        <Route
          path="/NumberResult"
          element={<NumberResult converted={converted} />}
        />
        <Route path="*" element={<NoMatch />} />
      </Routes>
      </div>
    </>
  );
}

export default App;
