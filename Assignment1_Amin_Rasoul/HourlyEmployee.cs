using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal class HourlyEmployee : Employee
    {
        private double hours;
        private double wage;

        public HourlyEmployee() { }

        public HourlyEmployee(string employeeName, EmployeeType employeeType, double hours, double wage)
        {
            EmployeeName = employeeName;
            _EmployeeType = employeeType;
            this.hours = hours;
            this.wage = wage;
        }

        public double Hours
        {
            get => hours;
            set => hours = value;
        }

        public double Wage
        {
            get => wage;
            set => wage = value;
        }


        public override double GrossEarnings()
        {
            if (hours <= 40.0 && Hours > 0.0)
            {
                return Hours * wage;
            }
            if (Hours > 40.0 && (Hours > 0.0))
            {
                double result = ((40 * wage) + (Hours - 40) * wage * 1.5);
                return result;
            }
            else
            {
                throw new Exception("The number you have input is out of range ");

            }
        }
    }//end of class
}
