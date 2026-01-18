using System;

class ConstructionEstimateException : Exception
{
    public ConstructionEstimateException(string message) : base(message)
    {}
}

class Program
{
    public EstimateDetails ValidateConstructionEstimate(float ConstructionArea, float siteArea)
    {
        EstimateDetails obj = new EstimateDetails();
        obj.ConstructionArea = ConstructionArea;
        obj.SiteArea = siteArea;

        if(ConstructionArea > siteArea)
        {
            throw new ConstructionEstimateException("Sorry your Construction Estimate is not approved");
        }
        Console.WriteLine("Construction Estimate approved");
        return obj;
    }

    static void Main()
    {
        Console.WriteLine("Enter Construction Area: ");
        float ConstructionArea = float.Parse(Console.ReadLine());
        Console.WriteLine("Enter Site Area: ");
        float siteArea = float.Parse(Console.ReadLine());

        Program program = new Program();

        try
        {
            EstimateDetails details = program.ValidateConstructionEstimate(ConstructionArea, siteArea);
            Console.WriteLine("Construction Area: " + details.ConstructionArea);
            Console.WriteLine("Site Area: " + details.SiteArea);
            
        }
        catch(ConstructionEstimateException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}