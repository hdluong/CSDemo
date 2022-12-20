using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager
{
    public class ContractEmployeeManager : IEmployeeManager
    {
        public decimal GetBonus()
        {
            return 5M;
        }

        public decimal GetPay()
        {
            return 12M;
        }

        public string GetEmployeeType()
        {
            return "Contract employee";
        }
    }
}
