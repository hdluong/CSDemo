using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager
{
    public class PermanentEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 10m;
        }

        public decimal GetPay()
        {
            return 8m;
        }

        public string GetEmployeeType()
        {
            return "Permanent employee";
        }

        public decimal GetHouseAllowance()
        {
            return 120m;
        }
    }
}
