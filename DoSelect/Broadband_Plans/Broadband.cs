using System;
using System.Collections.Generic;
interface IBroadbandPlan
{
    int GetBroadbandPlanAmount();
}

class Black : IBroadbandPlan
{
    private readonly bool _isSubscriptionValid;
    private readonly int _discountPercentage;
    private const int PlanAmount = 3000;

    public Black(bool isSubscriptionValid, int discountPercentage)
    {
        _isSubscriptionValid = isSubscriptionValid;
        _discountPercentage = discountPercentage;
        if(discountPercentage < 0 || discountPercentage > 50)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public int GetBroadbandPlanAmount()
    {
        if (_isSubscriptionValid)
        {
            int discountedPrice = PlanAmount - (int)((_discountPercentage/100.0) * PlanAmount);
            return discountedPrice;
        }
        return PlanAmount;
    }
}

class Gold : IBroadbandPlan
{
    private readonly bool _isSubscriptionValid;
    private readonly int _discountPercentage;
    private const int PlanAmount = 1500;

    public Gold(bool isSubscriptionValid, int discountPercentage)
    {
        _isSubscriptionValid = isSubscriptionValid;
        _discountPercentage = discountPercentage;
        if(discountPercentage < 0 || discountPercentage > 30)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public int GetBroadbandPlanAmount()
    {
        if (_isSubscriptionValid)
        {
            int discountedPrice = PlanAmount - (int)((_discountPercentage/100.0) * PlanAmount);
            return discountedPrice;
        } 
        return PlanAmount;
    }
}

class SubscribePlan
{
    private readonly IList<IBroadbandPlan> _broadbandPlans;

    public SubscribePlan(IList<IBroadbandPlan> broadbandPlans)
    {
        _broadbandPlans = broadbandPlans;
        if(broadbandPlans == null)
        {
            throw new ArgumentNullException();
        }
    }

    public IList<Tuple<string, int>> GetSubscriptionPlan()
    {
        List<Tuple<string, int>> PlanDetails = new List<Tuple<string, int>>();

        foreach(var plan in _broadbandPlans)
        {
            PlanDetails.Add(new Tuple<string, int>(plan.GetType().Name, plan.GetBroadbandPlanAmount()));
        }
        return PlanDetails;
    }
}