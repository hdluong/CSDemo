using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo1
{
    public class HamAndMushroomPizza : IPizza
    {
        private decimal price = 8.5M;

        public decimal GetPrice()
        {
            return price;
        }
    }
}
