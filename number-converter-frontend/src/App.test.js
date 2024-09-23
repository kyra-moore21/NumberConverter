import { render, screen, fireEvent } from "@testing-library/react";
import { MemoryRouter } from "react-router-dom";
import App from "./App";
import axios from "axios";
import MockAdapter from "axios-mock-adapter";

test("submit form and display results", async () => {
  // Create an instance of the axios mock adapter
  const mock = new MockAdapter(axios);

  // Mock the post request to the API endpoint
  mock.onPost("https://localhost:7054/api/NumberConverter/sort").reply(200, [
    { word: "one" }, 
    { word: "two" }, 
    { word: "three" },
  ]);

  // Render the app
  render(
    <MemoryRouter>
      <App />
    </MemoryRouter>
  );

  // Simulate the user input
  fireEvent.change(screen.getByLabelText(/Enter Numbers/), {
    target: { value: "1, 2, 3" },
  });

  // Simulate the form submission
  fireEvent.click(screen.getByRole("button", { name: /convert/i }));

  // Wait and check if the results are displayed
  expect(await screen.findByRole("heading", { name: /sorted words/i })).toBeInTheDocument();
  expect(screen.getByText(/one/)).toBeInTheDocument();
  expect(screen.getByText(/two/)).toBeInTheDocument();
  expect(screen.getByText(/three/)).toBeInTheDocument();

  // Clean up
  mock.reset();
});
