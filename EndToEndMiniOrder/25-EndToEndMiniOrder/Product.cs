using _25_EndToEndMiniOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//25.End - to - End Mini Order System (OOP + Validation + Exceptions)
//Design a mini order system with entities: Customer, Product, Order, OrderItem, Payment.
//Implement:
//• Add to cart
//• Place order (validate stock)
//• Deduct stock atomically
//• Apply coupon with rules
//• Generate invoice number
//• Handle failures with meaningful exceptions.



namespace _25_EndToEndMiniOrder
{
    public class Product
    {
        public string Name;
        public int Stock;
        public int Price;

        public Product(string name, int stock, int price)
        {
            Name = name;
            Stock = stock;
            Price = price;
        }


    }
}
