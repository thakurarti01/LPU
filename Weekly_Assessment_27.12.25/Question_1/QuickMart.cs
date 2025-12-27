using System;

class SaleTransaction
{
    static string InvoiceNo;
    static string CustomerName;
    static string ItemName;
    static int Quantity;
    static double PurchaseAmount;
    static double SellingAmount;
    static string ProfitOrLossStatus;
    static double ProfitOrLossAmount;
    static double ProfitMarginPercent;

    public static void CreateMethod()
    {
        Console.Write("Enter Invoice No: ");
        InvoiceNo = Console.ReadLine();

        if(InvoiceNo == null)
        {
            return;
        }

        Console.Write("Enter Customer Name: ");
        CustomerName = Console.ReadLine();

        Console.Write("Enter Item Name: ");
        ItemName = Console.ReadLine();

        Console.Write("Enter Quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());

        if(Quantity <= 0)
        {
            Console.Write("Quantity must be greater than 0");
            return;
        }

        Console.Write("Enter total Purchase Amount: ");
        PurchaseAmount = Convert.ToDouble(Console.ReadLine());

        if(PurchaseAmount <= 0)
        {
            Console.Write("Purchase amount must be greater than 0");
            return;
        }

        Console.Write("Enter total Selling Amount: ");
        SellingAmount = Convert.ToDouble(Console.ReadLine());

        if(SellingAmount < 0)
        {
            Console.Write("Selling Amount must be greater than 0");
            return;
        }

        if(SellingAmount > PurchaseAmount)
        {
            ProfitOrLossStatus = "PROFIT";
            ProfitOrLossAmount = SellingAmount - PurchaseAmount;
        }

        else if(SellingAmount < PurchaseAmount)
        {
            ProfitOrLossStatus = "LOSS";
            ProfitOrLossAmount = PurchaseAmount - SellingAmount;
        }

        else if(SellingAmount == PurchaseAmount)
        {
            ProfitOrLossStatus = "BREAK-EVEN";
            ProfitOrLossAmount = 0;
        }

        double percent = (ProfitOrLossAmount / PurchaseAmount) * 100;
        ProfitMarginPercent = Math.Round(percent, 2);

        Console.WriteLine("Transaction saved successfully.");
        Console.WriteLine("Status: " + ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + ProfitOrLossAmount);
        Console.WriteLine("Profit Margin (%): " + ProfitMarginPercent);
    }
     // ----------------------- 2nd method ----------------
    public static void ViewMethod()
    {
        if (InvoiceNo == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("----------- Last Transaction -----------");
        Console.WriteLine("InvoiceNo: " + InvoiceNo);
        Console.WriteLine("Customer: " + CustomerName);
        Console.WriteLine("Item: " + ItemName);
        Console.WriteLine("Quantity: " + Quantity);
        Console.WriteLine("Purchase Amount: " + PurchaseAmount);
        Console.WriteLine("Selling Amount: " + SellingAmount);
        Console.WriteLine("Status: " + ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + ProfitOrLossAmount);
        Console.WriteLine("Profit Margin(%): " + ProfitMarginPercent);
        Console.WriteLine("--------------------------------");
    }

    // -------------------- 3rd method ------------------------------

    public static void ClearMethod()
    {
        InvoiceNo = null;
        CustomerName = null;
        ItemName = null;
        Quantity = 0;
        PurchaseAmount = 0;
        SellingAmount = 0;
        ProfitOrLossStatus = null;
        ProfitOrLossAmount = 0;
        ProfitMarginPercent = 0;

    }
}