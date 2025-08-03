using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Cart_System
{
    public class CustomExceptions(string message) : Exception(message)
    {
        public class ProductNotFoundException : CustomExceptions
        {
            public ProductNotFoundException(string message) : base(message)
            {
            }
        }

        public class InsufficientStockException : CustomExceptions
        {
            public InsufficientStockException(string message) : base(message)
            {
            }
        }
    }
}
