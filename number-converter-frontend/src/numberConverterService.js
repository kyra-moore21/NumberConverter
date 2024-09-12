// numberConverterService.js
import axios from "axios";

export const convertNumbers = async (numbersArray) => {
  try {
    const response = await axios.post("https://localhost:7054/api/NumberConverter/sort", {
      numbers: numbersArray,
    });
    console.log("Numbers Converted Successfully", response.data);
    return response.data;
  } catch (error) {
    console.error("An error occurred. Please try again.", error);
    throw error;
  }
};
