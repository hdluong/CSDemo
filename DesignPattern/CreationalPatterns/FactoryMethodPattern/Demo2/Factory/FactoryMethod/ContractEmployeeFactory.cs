using DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Manager;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.CreationalPatterns.FactoryMethodPattern.Demo2.Factory.FactoryMethod
{
    public class ContractEmployeeFactory : BaseEmployeeFactory
    {
        public ContractEmployeeFactory(Employee emp) : base(emp)
        {

        }

        public override IEmployeeManager Create()
        {
            ContractEmployeeManager manager = new ContractEmployeeManager();
            _employee.MedicalAllowance = manager.GetMedicalAllowance();
            return manager;
        }
    }
}
