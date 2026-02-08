using System;
using System.Collections.Generic;

class Customer
{
    public string Name{get; set;}
    public string Address{get; set;}
    public int PhoneNo{get; set;}

    public Customer(string name, string address, int phoneNo)
    {
        this.Name = name;
        this.Address = address;
        this.PhoneNo = phoneNo;
    }
}

class Product
{
    public int ProdId{get; set;}
    public string ProdName{get; set;}
    public int ProdPrice{get; set;}
    public int ProdQuantity{get; set;}

    public static List<Product> prodList = new List<Product>()
    {
        new Product(){ProdId = 101, ProdName = "Pen", ProdPrice = 20, ProdQuantity = 386},
        new Product(){ProdId = 102, ProdName = "Notebook", ProdPrice = 50, ProdQuantity = 157},
        new Product(){ProdId = 103, ProdName = "Pencil", ProdPrice = 10, ProdQuantity = 96},
        new Product(){ProdId = 104, ProdName = "Bottle", ProdPrice = 120, ProdQuantity = 55},
        new Product(){ProdId = 105, ProdName = "Bag", ProdPrice = 500, ProdQuantity = 30},
    };
    //somehow after ordering product quantity will be deducted
}

class Order : Customer
{
    public int OrderId{get; set;}
    public List<OrderItem> Items{get; set;} = new List<OrderItem>(); 

    public Order(int orderId, string name, string address, int phone) : base(name, address, phone)
    {
        OrderId = orderId;
    }

    // i want to inherit customer class so that order should contain details of customer who have placed the order
    //then i will inherit payment class which will show total price of order
    // used order item class which contain all the items which we have ordered
    // and then will write a function that will validate the stock while ordering 
}

class OrderItem
{
    public int ProdId{get; set;}
    public string ProdName{get; set;}
    public int ProdQuantity{get; set;}
    public int ProdPrice{get; set;}

    public static bool AddToCart(int prodId, int quantity)
    {
        
    }

    //will add AddToCart method here as it is given in question to implement this method, so as this method and orderitem are almost same so this will contain product details which like product name, id, quantity which has been ordered 
}

class Payment
{
    public int InvoiceNo{get; set;}

    public int CalculatePrice()
    {
        int total = 0;
        foreach(var item in order)
        {
            total += item.Price * item.Quantity;
        }
        
    }
    //apply coupans
    //generate invoice no
    //here will inherit orderitem class,
    //will make one calculateprice method in which price will be calculated of ordered product after applying coupans and it will generate invoice number(i think that will be generated using random method)
}