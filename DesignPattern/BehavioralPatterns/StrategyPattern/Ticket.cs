using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern
{
    public class Ticket
    {
        public IPromotionStrategy PromotionStrategy { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Ticket()
        {

        }

        public Ticket(IPromotionStrategy promotionStrategy, string name, double price)
        {
            PromotionStrategy = promotionStrategy;
            Name = name;
            Price = price;
        }

        public double GetPromotedPrice()
        {
            return PromotionStrategy.DoDiscount(Price);
        }
    }
}
