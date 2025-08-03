using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Cart_System
{
    public class ShoppingCart
    {
        private List<CartItem> cartItems = new List<CartItem>();
        public void AddItem(Product product, int quantity,List<Product> products)
        {
            CartItem cartItem = null;
            foreach (var item in products)
            {
                if(item.Id == product.Id)
                {
                    if (item.Stock < quantity)
                    {
                        throw new CustomExceptions.InsufficientStockException("Insufficient stock for the product");
                    }
                    item.Stock -= quantity; // Reduce stock from the product list
                }
            }
            if (cartItems.Count != 0)
            {
                cartItem = cartItems.FirstOrDefault(c => c.Product == product);
            }
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
                return;
            }
            cartItem = new CartItem();
            cartItem.Product = product;
            cartItem.Quantity = quantity;
            cartItems.Add(cartItem);
        }

        public void RemoveItem(int productId,List<Product> products)
        {
            CartItem cartItem = cartItems.FirstOrDefault(c => c.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity--;
                foreach (var item in products)
                {
                    if (item.Id == productId)
                    {
                        item.Stock++; 
                    }
                }
                if (cartItem.Quantity <= 0)
                {
                    cartItems.Remove(cartItem);
                }
            }
            else
            {
                //CustomExceptions.ProductNotFoundException(productId);
                throw new CustomExceptions.ProductNotFoundException("Product not found in cart");
            }
        }
        public double CalculateTotal() {
            double total=0;
            foreach (var item in cartItems)
            {
                total += (double)(item.Product.Price * item.Quantity);
            }
            return total;
        }
        public void DisplayCart()
        {
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Empty Cart!\n");
                return;
            }
            foreach (var item in cartItems)
            {
                Console.WriteLine($"ID:{item.Product.Id}, Product: {item.Product.Name}, Quantity: {item.Quantity}, Price: {item.Product.Price}, Total: {item.Product.Price * item.Quantity}");
            }
            Console.WriteLine();
        }
    }
}
