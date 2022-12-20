using System;
using System.Collections.Generic;
using System.Text;
using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo1.Factory;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo1
{
    class Program
    {
        public static void Main(string[] args)
        {
            IPizza pizza = null;
            PizzaFactory.PizzaType type = PizzaFactory.PizzaType.Deluxe;

            pizza = PizzaFactory.CreatePizza(type);

            Console.WriteLine($"Pizza's price: {pizza.GetPrice()}");
        }
    }
}
