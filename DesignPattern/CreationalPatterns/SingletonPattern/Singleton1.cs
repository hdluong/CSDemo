using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.SingletonPattern
{
    public sealed class Singleton1
    {
        private static Singleton1 _instance;

        public static Singleton1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton1();
                }

                return _instance;
            }
        }

        private Singleton1()
        {
            
        }

        public void SayHi()
        {
            Console.WriteLine("Hello No Thread Safe Singleton!");
        }
    }
}
