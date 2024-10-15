# Dad's Coffee Shop
![screenshot__6_](https://github.com/user-attachments/assets/5b6b10a4-a562-4218-a7c2-43f3250b5f74) ![screenshot__11_](https://github.com/user-attachments/assets/09adf9ea-4d3a-4676-bc98-bcfd0bff6b15)



## Project Overview
**Dad's Coffee Shop** is a cash register or self-service terminal designed for small retail locations such as a coffee shop, fast food restaurant, or small store. This solution allows users to select products, enter quantities, calculate totals, and handle various payment methods. After each transaction, a receipt is generated, and the system returns to the main menu for new orders.

## Features
- **Product Management**: Choose from a menu of items, each with properties like name, category, description, and price.
  - **Order Process**:
  - Browse and select items by number or letter.
  - Input the quantity of the selected item.
  - Display a line total for each selected item (item price * quantity).
  - Re-display the menu or proceed to checkout.
- **Transaction Summary**:
  - Calculate subtotal, sales tax, and grand total using the `Math` library for precise rounding.
  - Display a receipt of all items ordered, along with payment details.
- **Payment Options**:
  - **Cash**: Input amount tendered and calculate change.
  - **Check**: Enter check number for the transaction.
  - **Credit**: Enter credit card number, expiration date, and CVV for payment.
- **Return to Menu**: After each transaction, the system loops back to the menu for a new order.

## Product Class Structure
Each product is stored in a list and follows the below structure:
- **Name**: Name of the product (e.g., "Cappuccino").
- **Category**: Type of item (e.g., "Beverage").
- **Description**: Short description of the product (e.g., "Rich espresso with steamed milk").
- **Price**: Item price (e.g., $3.50).

## User Interaction
1. **View Menu**: The user is presented with a list of items and their corresponding prices.
2. **Select Items**: The user selects items and quantities to add to their order.
3. **Display Totals**: A running total is displayed, including subtotal and tax.
4. **Select Payment Method**: Cash, check, or credit.
5. **Receipt**: After payment, a detailed receipt is displayed, and the user is returned to the main menu for new orders.

## Technologies Used
- C# for backend logic.
- Console or UI for user interaction.
  
## How to Run
1. Clone the repository.
2. Build the solution using your preferred IDE.
3. Run the program and follow the prompts to place orders and complete transactions.

## Future Enhancements
- Integrate with a graphical user interface (GUI) for better user experience.
- Add product categories to filter items by type (e.g., drinks, snacks, etc.).
- Implement discount codes or loyalty points.
- Connect to a database to store transaction histories.

## License
This project is licensed under the MIT License.
