import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom/extend-expect';
import { MemoryRouter } from 'react-router-dom'; // Import MemoryRouter for testing routing
import NumberInputForm from './NumberInputForm'; // Adjust the import path as necessary

describe('NumberInputForm Component', () => {
  test('renders without crashing', () => {
    render(
      <MemoryRouter>
        <NumberInputForm />
      </MemoryRouter>
    );
    expect(screen.getByText('Convert')).toBeInTheDocument();
  });

  test('renders Convert button', () => {
    render(
      <MemoryRouter>
        <NumberInputForm />
      </MemoryRouter>
    );
    const buttonElement = screen.getByText('Convert');
    expect(buttonElement).toBeInTheDocument();
  });

  test('calls apiRequest when form is submitted', () => {
    const mockApiRequest = jest.fn();
    render(
      <MemoryRouter>
        <NumberInputForm apiRequest={mockApiRequest} />
      </MemoryRouter>
    );
    
    // Simulate entering a valid number
    const inputElement = screen.getByPlaceholderText('ex: 1, 34, 5665, 21');
    fireEvent.change(inputElement, { target: { value: '1, 34, 56' } });

    // Simulate form submission
    const buttonElement = screen.getByText('Convert');
    fireEvent.click(buttonElement);
    
    expect(mockApiRequest).toHaveBeenCalled();


    
  });
  test('correct error message when input is blank', () => {
  render(
    <MemoryRouter>
      <NumberInputForm />
    </MemoryRouter>
  );
  //simulate entering a blank input
  const inputElement = screen.getByPlaceholderText('ex: 1, 34, 5665, 21');
  fireEvent.change(inputElement, { target: { value: '' } });

  //simulate form submission
  const buttonElement = screen.getByText('Convert');
  fireEvent.click(buttonElement);

  expect(screen.getByText('Input cannot be blank. Please enter some numbers.')).toBeInTheDocument();
  });
  test('correct error message when input is not a number', () => {
    render(
      <MemoryRouter>
        <NumberInputForm />
      </MemoryRouter>
    );
    //simulate entering a non-number input
    const inputElement = screen.getByPlaceholderText('ex: 1, 34, 5665, 21');
    fireEvent.change(inputElement, { target: { value: 'abc, 3232, 2222' } });

    //simulate form submission
    const buttonElement = screen.getByText('Convert');
    fireEvent.click(buttonElement);

    expect(screen.getByText('Please enter only numbers seperated by commas. Ex. 12, 34, 56')).toBeInTheDocument();
  });
  test('correct error message when input is a decimal', () => {
    render(
      <MemoryRouter>
        <NumberInputForm />
      </MemoryRouter>
    );
    //simulate entering a decimal input
    const inputElement = screen.getByPlaceholderText('ex: 1, 34, 5665, 21');
    fireEvent.change(inputElement, { target: { value: '1.1, 3232, 2222' } });

    //simulate form submission
    const buttonElement = screen.getByText('Convert');
    fireEvent.click(buttonElement);

    expect(screen.getByText('No decimals allowed. Please enter a whole numbers only. Ex. 12, 34, 56')).toBeInTheDocument();
  });

  test('correct error message when input is greater than max integer', () => {
    render(
      <MemoryRouter>
        <NumberInputForm />
      </MemoryRouter>
    );
    //simulate entering a number greater than max integer
    const inputElement = screen.getByPlaceholderText('ex: 1, 34, 5665, 21');
    fireEvent.change(inputElement, { target: { value: '21474836348, 3232, 2222' } });

    //simulate form submission
    const buttonElement = screen.getByText('Convert');
    fireEvent.click(buttonElement);

    expect(screen.getByText('Please enter a number less than 2,147,483,647 or greater than -2,147,483,647')).toBeInTheDocument();
  });
});
