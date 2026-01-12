using System;
using System.Collections.Generic;

public interface IProduct
{
    string Name{get; set;}
    string Category{get; set;}
    int Stock{get; set;}
    int Price{get; set;}
}

public class Product : IProduct
{
    public string Name{get; set;}
    public string Category{get; set;}
    public int Stock{get; set;}
    public int Price{get; set;}
}

public interface IInventory
{
    void AddProduct(IProduct product);
    void RemoveProduct(IProduct product);
    int CalculateTotalValue();
    List<IProduct> GetProductsByCategory(string category);
    List<(string category, int count)> GetProductsByCategoryWithCount();
    List<IProduct> SearchProductsByName(string name);
    List<(string category, List<IProduct> products)> GetAllProductsByCategory();
}

public class Inventory : IInventory
{
    private List <IProduct> _products = new List <IProduct>();
    public Inventory()
    {
        _products = new List <IProduct> ();
    }

    public void AddProduct(IProduct product)
    {
        if(product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _products.Add(product);
    }

    // public void RemoveProduct(IProduct product)
    // {
    //     IProduct productToRemove = null;
    //     foreach(IProduct item in _products)
    //     {
    //         if(item == product)
    //         {
    //             productToRemove = item;
    //             break;
    //         }
    //     }
    //     if(productToRemove != null)
    //     {
    //         _products.Remove(productToRemove);
    //     }   
    // }

    public void RemoveProduct(IProduct product)
    {
        if (_products.Contains(product))
        {
            _products.Remove(product);
        }
    }


    public int CalculateTotalValue()
    {
        int total = 0;

        foreach(var item in _products)
        {
            total += item.Stock*item.Price;
        }

        return total;
    }

    public List<IProduct> GetProductsByCategory(string category)
    {
       List<IProduct> result = new  List<IProduct>();
       foreach(var item in _products)
        {
            if(item.Category == category)
            {
                result.Add(item);
            }
        }
        return result;
    }

    public List<(string category, int count)> GetProductsByCategoryWithCount()
    {
        List<(string category, int count)> result = new List<(string category, int count)>();
        List<string> uniqueCategories = new List<string>();

        foreach(var item in _products)
        {
            if(!uniqueCategories.Contains(item.Category))
            {
                uniqueCategories.Add(item.Category);
            }
        }

        foreach(var category in uniqueCategories)
        {
            int count = 0;
            foreach(var item in _products)
            {
                if(item.Category == category)
                {
                    count++;
                }
            }
            result.Add((category, count));
        }
        return result;
    }

    public List<IProduct> SearchProductsByName(string name)
    {
        List<IProduct> newList = new List<IProduct>();

        foreach(var item in _products)
        {
            if(item.Name == name)
            {
                newList.Add(item);
            }

            // OR FOR PARTIAL MATCH:
            // if (item.Name.Contains(name))
            // {
            //     newList.Add(item);
            // }
        }
        return newList;
    }

    public List<(string category, List<IProduct> products)> GetAllProductsByCategory()
    {
       List<(string category, List<IProduct> products)> result = new List<(string category, List<IProduct> products)>();
       List<string> uniqueCategories = new List<string>();

       foreach(var item in _products)
        {
            if (!uniqueCategories.Contains(item.Category))
            {
                uniqueCategories.Add(item.Category);
            }
        } 

        foreach(var category in uniqueCategories)
        {
            List<IProduct> productInCategory = new List<IProduct>(); //temporary list
            foreach(var item in _products)
            {
                if(item.Category == category)
                {
                    productInCategory.Add(item);
                }
            }
            result.Add((category, productInCategory));
        }
        return result;
    }
}