using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class CommissionEmployee : Employee
    {
        private double grossSale;
        private double commissionRate;

        public CommissionEmployee() { }
        public CommissionEmployee(string employeeName, EmployeeType employeeType, double grossSale, double commissionRate)
        {
            EmployeeName = employeeName;
            _EmployeeType = employeeType;
            this.grossSale = grossSale;
            this.commissionRate = commissionRate;

        }


        public double GrossSale
        {
            get => grossSale;
            set => grossSale = value;
        }

        public double CommissionRate
        {
            get => commissionRate;
            set => commissionRate = value;
        }

        public override double GrossEarnings()
        {
            if (GrossSale >= 0 && CommissionRate >= 0)
            {
                return (GrossSale * (CommissionRate / 100));
            }
            else
            {
                throw new Exception("The number you have input is less than zero ");
            }


        }
    }//end of CommissionEmployee Class
}
