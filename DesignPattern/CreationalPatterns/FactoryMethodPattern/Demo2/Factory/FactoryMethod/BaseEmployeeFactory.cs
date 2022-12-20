using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Factory.FactoryMethod
{
    public abstract class BaseEmployeeFactory
    {
        protected Employee _employee;

        public BaseEmployeeFactory(Employee emp)
        {
            _employee = emp;
        }

        public Employee ApplySalary()
        {
            IEmployeeManager empManager = this.Create();

            _employee.EmployeeTypeTxt = empManager.GetEmployeeType();
            _employee.Bonus = empManager.GetBonus();
            _employee.HourlyPay = empManager.GetPay();

            return _employee;
        }

        public abstract IEmployeeManager Create();
    }
}
