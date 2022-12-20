using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo1
{
    public class SeafoodPizza : IPizza
    {
        private decimal price = 9M;

        public decimal GetPrice()
        {
            return price;
        }
    }
}
