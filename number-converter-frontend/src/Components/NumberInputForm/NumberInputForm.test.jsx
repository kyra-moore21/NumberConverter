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
});
