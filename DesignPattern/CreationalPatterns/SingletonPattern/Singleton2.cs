using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.SingletonPattern
{
    public sealed class Singleton2
    {
        private static Singleton2 _instance;
        private static readonly object lockObject = new object();

        private Singleton2()
        {

        }

        public static Singleton2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton2();
                        }
                    }
                }

                return _instance;
            }
        }

        public void SayHi()
        {
            Console.WriteLine("Hello Thread Safety Singleton!");
        }
    }
}
