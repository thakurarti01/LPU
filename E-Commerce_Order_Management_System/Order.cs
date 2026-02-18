using System;
using System.Collections.Generic;
class OutOfStockException : Exception
{
    public OutOfStockException(string message) : base(message){}
}

class OrderAlreadyShippedException : Exception
{
    public OrderAlreadyShippedException(string message) : base(message){}
}

class CustomerBlacklistedException : Exception
{
    public CustomerBlacklistedException(string message) : base(message){}
}

class Product
{
    public int Id{get; set;}
    public string Name{get; set;}
    public double Price{get; set;}
    public int Stock{get; set;}

    public Product(int id, string name, double price, int stock)
    {
        Id = id;
        Name = name;
        Price = price;
        Stock = stock;
    }

    public void ReduceStock(int quantity)
    {
        if(quantity > Stock)
        {
            throw new OutOfStockException("Quantity is more than stock");
        }
        Stock -= quantity;
    }
}

class Customer
{
    public int Id{get; set;}
    public string Name{get; set;}
    public bool IsBlacklisted{get; set;}

    public Customer(int id, string name, bool blacklisted)
    {
        Id = id;
        Name = name;
        IsBlacklisted = blacklisted;
    }
}

public enum OrderStatus
{
    Pending,
    Shipped,
    Delivered,
    Cancelled
}
class Order
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderStatus Status { get; set; }
    public Customer Customer { get; set; }
    public List<OrderItem> Items { get; set; }

    public Order(int orderId, Customer customer)
    {
        if (customer.IsBlacklisted)
            throw new CustomerBlacklistedException("Blacklisted customer");

        OrderId = orderId;
        Customer = customer;
        OrderDate = DateTime.Now;
        Items = new List<OrderItem>();
        Status = OrderStatus.Pending;
    }

    
    public void AddItem(Product product, int quantity)
    {
        product.ReduceStock(quantity);
        Items.Add(new OrderItem(product.Name, product.Price, quantity));
    }

    
    public double GetTotalAmount()
    {
        return Items.Sum(i => i.GetTotalPrice());
    }

    
    public void Ship()
    {
        if (Status != OrderStatus.Pending)
            throw new Exception("Only pending orders can be shipped.");

        Status = OrderStatus.Shipped;
    }

    
    public void Cancel()
    {
        if (Status == OrderStatus.Shipped)
            throw new OrderAlreadyShippedException("Can't cancel shipped order now");

        Status = OrderStatus.Cancelled;
    }
}

class OrderItem
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public OrderItem(string productName, double price, int quantity)
    {
        ProductName = productName;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return Price * Quantity;
    }
}
