using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.BehavioralPatterns.StrategyPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var ticketLst = new List<Ticket>();

            ticketLst.AddRange(new List<Ticket>()
            {
                new Ticket(new NoDiscountStrategy(), "Ticket 1", 100),
                new Ticket(new QuarterDiscountStrategy(), "Ticket 2", 200),
                new Ticket(new HalfDiscountStrategy(), "Ticket 3", 300),
                new Ticket(new QuarterDiscountStrategy(), "Ticket 4", 400),
                new Ticket(new HalfDiscountStrategy(), "Ticket 5", 500),
            });

            foreach (var item in ticketLst)
            {
                Console.WriteLine($"{item.Name} - Price: {item.Price} - Discount price: {item.GetPromotedPrice()}");
            }
        }
    }
}
