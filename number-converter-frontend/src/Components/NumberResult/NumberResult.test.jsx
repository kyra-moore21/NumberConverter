import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import { MemoryRouter, Route, Routes } from "react-router-dom";
import NumberResult from "./NumberResult";

const mockNavigate = jest.fn();

//mock use navigate hook
jest.mock("react-router-dom", () => ({
    ...jest.requireActual("react-router-dom"),
    useNavigate: () => mockNavigate,
}));

describe("NumberResult Component", () => {
    const converted = [
        { word: "one", over9000: false }, // not over 9000
        { word: "nine thousand and one", over9000: true }, // over 9000
    ];

    test("renders the component with converted numbers", () => {
        render(
            <MemoryRouter>
                <NumberResult converted={converted} />
            </MemoryRouter>
        );

        expect(screen.getByText("Sorted Words:")).toBeInTheDocument();
        expect(screen.getByText("one,")).toBeInTheDocument();
        expect(screen.getByAltText("nine thousand and one")).toBeInTheDocument();
    });

    test("navigates back when 'Convert More Numbers' button is clicked", () => {
        render(
            <MemoryRouter>
                <NumberResult converted={converted} />
            </MemoryRouter>
        );

        const button = screen.getByText("Convert More Numbers");
        fireEvent.click(button);

        expect(mockNavigate).toHaveBeenCalledWith(-1);
    });

    test("renders the image when number is over 9000", () => {
        render(
            <MemoryRouter>
                <NumberResult converted={converted} />
            </MemoryRouter>
        );

        const img = screen.getByAltText("nine thousand and one");
        expect(img).toBeInTheDocument();
        expect(img).toHaveAttribute("src", "/assests/over9000.jpg");
    });

    test("renders the word when number is not over 9000", () => {
        render(
            <MemoryRouter>
                <NumberResult converted={converted} />
            </MemoryRouter>
        );

        const word = screen.getByText("one,");
        expect(word).toBeInTheDocument();
    });
});