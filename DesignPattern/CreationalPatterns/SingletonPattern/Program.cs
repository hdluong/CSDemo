using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.SingletonPattern
{
    class Program
    {
        public static void Main(string[] args)
        {
            var i1 = Singleton1.Instance;
            var i2 = Singleton1.Instance;

            if (i1.GetHashCode() == i2.GetHashCode())
            {
                i1.SayHi();
            }

            Singleton2.Instance.SayHi();
        }
    }
}
