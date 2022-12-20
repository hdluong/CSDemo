using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Factory;
using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2
{
    class Program
    {
        public static void Main(string[] args)
        {
            var employeeLst = new List<Employee>()
            {
                new Employee(EmployeeType.Contract),
                new Employee(EmployeeType.Permanent),
                new Employee(EmployeeType.Contract),
            };

            foreach (var emp in employeeLst)
            {
                IEmployeeManager empManager = EmployeeManagerFactory.CreateEmployeeManager(emp.EmployeeType);
                emp.Bonus = empManager.GetBonus();
                emp.HourlyPay = empManager.GetPay();

                Console.WriteLine($"Employee details: Bonus {emp.Bonus} - Pay (hourly) {emp.HourlyPay} - " +
                    $"employee type {empManager.GetEmployeeType()}");
            }
        }
    }
}
