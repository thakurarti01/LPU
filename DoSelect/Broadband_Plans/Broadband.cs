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
        if(_discountPercentage < 0 || _discountPercentage > 50)
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
        if(_discountPercentage < 0 || _discountPercentage > 30)
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
    }

    public IList<Tuple<string, int>> GetSubscriptionPlan()
    {
        
    }
}