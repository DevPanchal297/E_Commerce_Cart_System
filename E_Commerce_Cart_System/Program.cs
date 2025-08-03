namespace E_Commerce_Cart_System;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("WelCome to E-Commerce Cart System!");
            List<Product> products = new List<Product>();
            JsonLoader jsonLoader = new JsonLoader();
            ShoppingCart shoppingCart = new ShoppingCart();
            products = jsonLoader.LoadProducts();
            int input = 0;
            do
            {
                Console.WriteLine(" 1. View Catalog\n 2. Add Item to Cart\n 3. Remove Item from Cart\n 4. View Cart\n 5. Checkout\n 6. Exit");
                input = TryParseInt(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("\nCatalog:");
                        foreach (var product in products)
                        {
                            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        var productToAdd = " "; int productIdToAdd = -1; bool productNotFound = true;
                        do
                        {
                            Console.WriteLine("Enter the ProductID to add to cart:");
                            productToAdd = Console.ReadLine();
                            if (int.TryParse(productToAdd, out productIdToAdd))
                            {
                                Product? productSearch = products.FirstOrDefault(p => p.Id == productIdToAdd);
                                if (productSearch != null)
                                {
                                    try
                                    {
                                        shoppingCart.AddItem(productSearch, 1, products);
                                        productNotFound = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Exception: {ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input, Please provide valid ProductID");
                                continue;
                            }
                        }
                        while (productNotFound);

                        break;
                    case 3:
                        var productToRemove = " "; int productIdToRemove = -1; bool productNotFoundToRemove = true;
                        do
                        {
                            Console.WriteLine("Enter the ProductID to remove from cart:");
                            productToRemove = Console.ReadLine();
                            if (int.TryParse(productToRemove, out productIdToRemove))
                            {
                                Product? productSearch = products.FirstOrDefault(p => p.Id == productIdToRemove);
                                if (productSearch != null)
                                {
                                    try
                                    {
                                        shoppingCart.RemoveItem(productIdToRemove, products);
                                        productNotFoundToRemove = false;
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Exception:{ex.Message}");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input, Please provide valid ProductID");
                                continue;
                            }
                        }
                        while (productNotFoundToRemove);
                        break;
                    case 4:
                        Console.WriteLine("Your Cart:");
                        shoppingCart.DisplayCart();
                        break;
                    case 5:
                        Console.WriteLine("Checkout:");
                        double total = shoppingCart.CalculateTotal();
                        if (total > 0)
                        {
                            shoppingCart.DisplayCart();
                            Console.WriteLine($"Total Amount: {total}");
                            Console.WriteLine("Thank you for shopping with us!\n");
                            jsonLoader.UpdateProducts(products);
                            input = 6;
                        }
                        else
                        {
                            Console.WriteLine("Your cart is empty. Please add items to your cart before checking out.\n");
                        }
                        break;

                }
            }
            while (input != 6);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
    static int TryParseInt(string? input)
    {
        int result;
        while (!int.TryParse(input, out result) || result < 1 || result > 6)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
            input = Console.ReadLine();
        }
        return result;
    }
}