using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class SalariedEmployee : Employee
    {
        private double weeklySalary;


        public SalariedEmployee() { }
        public SalariedEmployee(string employeeName, EmployeeType employeeType, double weeklySalary)
        {
            EmployeeName = employeeName;
            _EmployeeType = employeeType;
            this.weeklySalary = weeklySalary;

        }

        public double WeeklySalary
        {
            get => weeklySalary;
            set => weeklySalary = value;
        }
        public override double GrossEarnings()
        {
            if (WeeklySalary >= 0)
            {
                return WeeklySalary;
            }
            else
            {
                throw new Exception("The number you have input is less than zero ");
            }

        }
    }//end of class
}
