using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo1.Factory
{
    public class PizzaFactory
    {
        public enum PizzaType
        {
            Deluxe,
            HamAndMushroom,
            Seafood
        }

        public static IPizza CreatePizza(PizzaType type)
        {
            IPizza pizza = null;

            switch (type)
            {
                case PizzaType.Deluxe:
                    pizza = new DeluxePizza();
                    break;
                case PizzaType.HamAndMushroom:
                    pizza = new HamAndMushroomPizza();
                    break;
                case PizzaType.Seafood:
                    pizza = new SeafoodPizza();
                    break;
                default:
                    break;
            }

            return pizza;
        }
    }
}
