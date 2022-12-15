using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern
{
    public class HalfDiscountStrategy : IPromotionStrategy
    {
        public double DoDiscount(double price)
        {
            return price * 0.5;
        }
    }
}
