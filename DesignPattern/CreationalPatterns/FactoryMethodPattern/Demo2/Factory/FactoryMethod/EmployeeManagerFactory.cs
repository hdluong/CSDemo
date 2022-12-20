using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Factory.FactoryMethod
{
    public class EmployeeManagerFactory
    {
        public static BaseEmployeeFactory CreateFactory(Employee employee)
        {
            BaseEmployeeFactory factory = null;

            switch (employee.EmployeeType)
            {
                case EmployeeType.Contract:
                    factory = new ContractEmployeeFactory(employee);
                    break;
                case EmployeeType.Permanent:
                    factory = new PermanentEmployeeFactory(employee);
                    break;
                default:
                    break;
            }

            return factory;
        }
    }
}
