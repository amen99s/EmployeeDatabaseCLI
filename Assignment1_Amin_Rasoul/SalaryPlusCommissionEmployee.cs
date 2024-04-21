using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class SalaryPlusCommissionEmployee : CommissionEmployee
    {
        private double weeklySalary;


        public SalaryPlusCommissionEmployee() { }

        public SalaryPlusCommissionEmployee(string employeeName, EmployeeType employeeType, double weeklySalary, double grossSale, double commissionRate)
        {
            EmployeeName = employeeName;
            _EmployeeType = employeeType;
            WeeklySalary = weeklySalary;
            GrossSale = grossSale;
            CommissionRate = commissionRate;
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
                return WeeklySalary + GrossSale * (CommissionRate / 100);
            }
            else
            {
                throw new Exception("The number you have input is less than zero ");
            }

        }
    }//end of class
}
