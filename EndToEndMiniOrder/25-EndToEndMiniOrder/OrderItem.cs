using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_EndToEndMiniOrder
{
    public class OrderItem
    {
        public Product Product;
        public int Quantity;

        public OrderItem(Product product, int qty)
        {
            Product = product;
            Quantity = qty;
        }
    }
}
