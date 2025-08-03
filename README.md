# 🛒 E-Commerce Cart System (.NET 8 Console App)

The **E-Commerce Cart System** is a simple .NET 8 Console Application that simulates an online shopping experience. Users can view a product catalog, add/remove items to/from their cart, view the cart, and checkout — all via command-line interface.

## ✅ Features
- 📦 View catalog of products (loaded from a JSON file)
- ➕ Add items to the cart
- ➖ Remove items from the cart
- 🧾 View current cart with totals
- 💳 Checkout and reduce inventory stock

## 💻 Requirements
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Windows/macOS/Linux with terminal access

## ⚙️ Setup Instructions
1. **Clone the Repository**
   ```bash
   git clone https://github.com/DevPanchal297/E_Commerce_Cart_System.git
   cd E_Commerce_Cart_System/E_Commerce_Cart_System/
   ```

2. **Ensure `products.json` exists**
   Place your `products.json` file in the root of the project. Example structure:
   ```json
   [
     {
       "Id": 1,
       "Name": "Wireless Mouse",
       "Price": 799.99,
       "Stock": 25
     },
     {
       "Id": 2,
       "Name": "Laptop Stand",
       "Price": 1299.50,
       "Stock": 10
     }
   ]
   ```

3. **Build the Project**
   ```bash
   dotnet build
   ```

4. **Run the Application**
   ```bash
   dotnet run
   ```

## 💡 Sample Output
```text
WelCome to E-Commerce Cart System!
1. View Catalog
2. Add Item to Cart
3. Remove Item from Cart
4. View Cart
5. Checkout
6. Exit
```

📦 **Catalog View**
```text
Id: 1, Name: Wireless Mouse, Price: 799.99, Stock: 25
Id: 2, Name: Laptop Stand, Price: 1299.5, Stock: 10
```

🛒 **Cart View**
```text
Item: Wireless Mouse | Price: 799.99 | Quantity: 1 | Subtotal: 799.9 | Total: 799.99
```

💳 **Checkout**
```text
Item: Wireless Mouse | Price: 799.99 | Quantity: 1 | Subtotal: 799.9 | Total: 799.99
Total Amount: 799.99
Thank you for shopping with us!
```

## 🤝 Contributions
Feel free to fork and contribute! Open issues or feature requests are welcome.

## 📄 License
This project is licensed under the MIT License.
