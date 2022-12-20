using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2
{
    public enum EmployeeType
    {
        Contract,
        Permanent
    }

    public class Employee
    {
        public decimal Bonus { get; set; }

        public decimal HourlyPay { get; set; }

        public decimal MedicalAllowance { get; set; }

        public decimal HouseAllowance { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public string EmployeeTypeTxt { get; set; }

        public Employee(EmployeeType type)
        {
            EmployeeType = type;
        }
    }
}
