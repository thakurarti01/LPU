using System;

namespace PropertyDemo
{
   class Customer
    {
        List<Orders> orderList;

        public Customer()
        {
            orderList = new List<Orders>();
        }

        public int CustID {get; set;}
        public string Name {get; set;}
        public string BillingAddress {get; set;}
        public string ShippingAddress {get; set;}

        public List<Orders> MyOrders
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
            }
        }
    } 
}


