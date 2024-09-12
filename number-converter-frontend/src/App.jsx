import React, { useState } from "react";
import NumberInputForm from "./Components/NumberInputForm/NumberInputForm";
import NumberResult from "./Components/NumberResult/NumberResult";
import { Routes, Route } from "react-router-dom";
import Navbar from "./Components/Navbar/Navbar";
import NoMatch from "./Components/NoMatch/NoMatch";
import styles from "./App.module.css";
import { useNavigate } from "react-router-dom";
import { convertNumbers } from "./numberConverterService";

function App() {
  const [converted, setConvertedNumbers] = useState([]);
  const navigate = useNavigate();

  const apiRequest = async (numbersArray) => {
    try{
      const result = await convertNumbers(numbersArray);
      setConvertedNumbers(result);
      navigate("/NumberResult");
    }
    catch (error){
      console.error("An error occured. Please try again.", error);
    }
  }

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
