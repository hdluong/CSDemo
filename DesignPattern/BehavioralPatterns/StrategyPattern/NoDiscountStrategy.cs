using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern
{
    public class NoDiscountStrategy : IPromotionStrategy
    {
        public double DoDiscount(double price)
        {
            return price;
        }
    }
}
