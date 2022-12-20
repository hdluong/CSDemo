using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo1
{
    public class DeluxePizza : IPizza
    {
        private decimal price = 10.5M;

        public decimal GetPrice()
        {
            return price;
        }
    }
}
