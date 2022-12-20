using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Factory.FactoryMethod;
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
                new Employee(EmployeeType.Permanent),
            };

            Console.WriteLine($"Employee details: ");
            foreach (var emp in employeeLst)
            {
                BaseEmployeeFactory empFactory = EmployeeManagerFactory.CreateFactory(emp);
                empFactory.ApplySalary();

                Console.WriteLine("===============================================");
                Console.WriteLine($"employee type: {emp.EmployeeTypeTxt}");
                Console.WriteLine($"Bonus: {emp.Bonus}");
                Console.WriteLine($"Pay (hourly): {emp.HourlyPay}");
                Console.WriteLine($"House Allowance: {emp.HouseAllowance}");
                Console.WriteLine($"Medical Allowance: {emp.MedicalAllowance}");
                Console.WriteLine("===============================================");
            }
        }
    }
}
