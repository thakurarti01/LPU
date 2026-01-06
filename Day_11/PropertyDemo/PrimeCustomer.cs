using System;

namespace PropertyDemo
{
    class PrimeCustomer : Customer
    {
        public List<Orders> MyPrimeOrders //writeonly property
        {
            set
            {
                MyOrders = value;
            }
        } 
    }
}


//70 page