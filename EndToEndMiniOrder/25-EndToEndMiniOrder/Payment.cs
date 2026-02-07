using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_EndToEndMiniOrder
{
    public class Payment
    {
        public void Pay(int amount)
        {
            if (amount <= 0)
                throw new Exception("Payment failed");

            Console.WriteLine("Payment Successful");
        }



    }
}
