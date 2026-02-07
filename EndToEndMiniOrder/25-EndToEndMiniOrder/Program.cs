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
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Product phone = new Product("Phone", 5, 20000);
                Product charger = new Product("Charger", 10, 1000);

                Order order = new Order();

                order.AddToCart(phone, 1);
                order.AddToCart(charger, 2);

                int finalAmount = order.PlaceOrder(2000); 

                Payment payment = new Payment();
                payment.Pay(finalAmount);

                Console.WriteLine("Invoice No: " + order.InvoiceNo);
                Console.WriteLine("Order Completed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}
