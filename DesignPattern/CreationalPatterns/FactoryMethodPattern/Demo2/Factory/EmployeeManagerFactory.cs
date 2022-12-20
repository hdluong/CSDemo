using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Factory
{
    public class EmployeeManagerFactory
    {
        public static IEmployeeManager CreateEmployeeManager(EmployeeType type)
        {
            IEmployeeManager employeeManager = null;

            switch (type)
            {
                case EmployeeType.Contract:
                    employeeManager = new ContractEmployeeManager();
                    break;
                case EmployeeType.Permanent:
                    employeeManager = new PermanentEmployeeManager();
                    break;
                default:
                    break;
            }

            return employeeManager;
        }
    }
}
