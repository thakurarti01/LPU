using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_EndToEndMiniOrder
{
    public class Order
    {
        public List<OrderItem> Cart = new List<OrderItem>();
        public int InvoiceNo;
        static int invoiceCounter = 100;

        public void AddToCart(Product product, int qty)
        {
            if (qty > product.Stock)
                throw new Exception("Out of stock");

            Cart.Add(new OrderItem(product, qty));
        }

    
        public int PlaceOrder(int couponAmount)
        {
            int total = 0;

            foreach (var item in Cart)
            {
                item.Product.Stock -= item.Quantity;   
                total += item.Product.Price * item.Quantity;
            }

            if (couponAmount > total)
                throw new Exception("Invalid coupon");

            InvoiceNo = ++invoiceCounter;
            return total - couponAmount;
        }


    }
}
