using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace E_Commerce_Cart_System
{
    internal class JsonLoader
    {
        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();
            string json = File.ReadAllText("../../../catalog.json");
            products = JsonSerializer.Deserialize<List<Product>>(json);
            //foreach (var product in products)
            //{
            //    Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            //}
            return products;
        }

        public void UpdateProducts(List<Product> products)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(products, options);
            File.WriteAllText("../../../catalog.json", json);
        }
    }
}
