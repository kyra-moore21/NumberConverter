// numberConverterService.js
import axios from "axios";

export const convertNumbers = async (numbersArray) => {
  try {
    const response = await axios.post("https://numberconverterbackend-hmekfdf6dmedd4b2.eastus2-01.azurewebsites.net/api/NumberConverter/sort", {
      numbers: numbersArray,
    });
    console.log("Numbers Converted Successfully", response.data);
    return response.data;
  } catch (error) {
    console.error("An error occurred. Please try again.", error);
    throw error;
  }
};
