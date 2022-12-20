using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager
{
    public interface IEmployeeManager
    {
        decimal GetBonus();
        decimal GetPay();

        string GetEmployeeType();
    }
}
