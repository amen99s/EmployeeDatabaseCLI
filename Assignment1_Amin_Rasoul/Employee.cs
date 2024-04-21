using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    internal abstract class Employee
    {
        private static int nextEmployeeId = 1;
        private int employeeId;
        private string employeeName;
        private EmployeeType employeeType;
        public Employee()
        {
            employeeId = nextEmployeeId++;
        }

        public Employee(string employeeName, EmployeeType employeeType)
        {
            employeeId = nextEmployeeId++;
            this.employeeName = employeeName;
            this.employeeType = employeeType;
        }

        public int EmployeeId
        {
            get => employeeId;
        }

        public string EmployeeName
        {
            get => employeeName;
            set => employeeName = value;
        }

        public EmployeeType _EmployeeType
        {
            get => employeeType;
            set => employeeType = value;
        }




        public abstract double GrossEarnings();

        public double Tax
        {
            get { return (0.2 * GrossEarnings()); }
        }

        public double netEarnings
        {
            get { return GrossEarnings() - Tax; }
        }


    }//end of Employee Class
} //end of namespace
