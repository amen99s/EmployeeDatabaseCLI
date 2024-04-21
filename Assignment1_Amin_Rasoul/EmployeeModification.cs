using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;

namespace MainApp
{
    internal class EmployeeModification
    {
        public void viewEmployee(List<Employee> myList)
        {
            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "GrossEarnings");

            foreach (Employee emp in myList)
            {
                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp._EmployeeType, emp.GrossEarnings().ToString("C"));
            }

            table.Write(Format.MarkDown);
        }//end of viewEmployee
        public void viewHourlyEmployee(List<Employee> myHourlyEmployee)
        {
            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "Hour", "Wage", "GrossEarnings", "Tax", "Net Earning");

            foreach (Employee emp in myHourlyEmployee)
            {
                if (emp is HourlyEmployee hourlyEmployee)
                {
                    table.AddRow(hourlyEmployee.EmployeeId, hourlyEmployee.EmployeeName, hourlyEmployee._EmployeeType, hourlyEmployee.Hours, hourlyEmployee.Wage.ToString("C"), hourlyEmployee.GrossEarnings().ToString("C"), emp.Tax.ToString("C"), emp.netEarnings.ToString("C"));
                }
            }

            table.Write(Format.MarkDown);
        }//end of viewHourlyEmployee

        public void viewSalariedEmployee(List<Employee> mySalariedEmployee)
        {
            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "WeeklySalary", "GrossEarnings", "Tax", "Net Earning");

            foreach (Employee emp in mySalariedEmployee)
            {
                if (emp is SalariedEmployee salariedEmployee)
                {
                    table.AddRow(salariedEmployee.EmployeeId, salariedEmployee.EmployeeName, salariedEmployee._EmployeeType, salariedEmployee.WeeklySalary.ToString("C"), salariedEmployee.GrossEarnings().ToString("C"), emp.Tax.ToString("C"), emp.netEarnings.ToString("C"));
                }
            }

            table.Write(Format.MarkDown);
        }//end of viewSalariedEmployee

        public void viewCommissionEmployee(List<Employee> myCommissionEmployee)
        {
            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "GrossSale", "CommissionRate", "GrossEarnings", "Tax", "Net Earning");

            foreach (Employee emp in myCommissionEmployee)
            {
                if (emp is CommissionEmployee commissionEmployee && !(emp is SalaryPlusCommissionEmployee))
                {
                    table.AddRow(commissionEmployee.EmployeeId, commissionEmployee.EmployeeName, commissionEmployee._EmployeeType, commissionEmployee.GrossSale.ToString("C"), $"{commissionEmployee.CommissionRate:P1}", commissionEmployee.GrossEarnings().ToString("C"), emp.Tax.ToString("C"), emp.netEarnings.ToString("C"));
                }
            }

            table.Write(Format.MarkDown);
        }//end of viewCommissionEmployee
        public void viewSalaryPlusCommissionEmployee(List<Employee> mySalaryPlusCommissionEmployee)
        {
            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "WeeklySalary", "GrossSale", "CommissionRate", "GrossEarnings", "Tax", "Net Earning");

            foreach (Employee emp in mySalaryPlusCommissionEmployee)
            {
                if (emp is SalaryPlusCommissionEmployee salaryPlusCommissionEmployee)
                {
                    table.AddRow(salaryPlusCommissionEmployee.EmployeeId, salaryPlusCommissionEmployee.EmployeeName, salaryPlusCommissionEmployee._EmployeeType, salaryPlusCommissionEmployee.WeeklySalary.ToString("C"), salaryPlusCommissionEmployee.GrossSale.ToString("C"), $"{salaryPlusCommissionEmployee.CommissionRate:P1}", salaryPlusCommissionEmployee.GrossEarnings().ToString("C"), emp.Tax.ToString("C"), emp.netEarnings.ToString("C"));
                }
            }

            table.Write(Format.MarkDown);
        }//end of viewSalaryPlusCommissionEmployee
        public void AddEmployee(List<Employee> myEmployee) //this method uses to create employees based on users input
        {
            int inp = 0;
            while (inp != 5)
            {
                inp = 0;
                double wage = 0.0;
                string name = "";
                double hour = 0.0;
                double grossSale = 0.0, comissionRate = 0.0, weeklySalary = 0.0;
                Console.WriteLine("1-Add Hourly Employee");
                Console.WriteLine("2-Add Commission Employee");
                Console.WriteLine("3-Add Salaried Employee");
                Console.WriteLine("4-Add Salary Plus Commission Employee");
                Console.WriteLine("5-Back to Main Menu\n");
                try
                {
                    inp = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input try again \n");
                    continue;
                }
                if ((inp < 1 || inp > 5))
                {
                    Console.WriteLine("The number is out of range please insert between 1 to 5 \n");
                    continue;
                }
                if (inp == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter the Employee Name: ");
                        name = Console.ReadLine();
                        if (int.TryParse(name, out int result))
                        {
                            Console.WriteLine("Name should not contain any number\n");
                            continue;
                        }
                        Console.WriteLine("Enter hours the Employee works");
                        hour = Double.Parse(Console.ReadLine());
                        if (hour < 0)
                        {
                            Console.WriteLine("Enter a number more than 0 ");
                            continue;
                        }
                        Console.WriteLine("Enter wage the Employee works per hour");
                        wage = Double.Parse(Console.ReadLine());
                        if (wage < 0)
                        {
                            Console.WriteLine("Enter a number more than 0 ");
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again \n");
                        continue;
                    }
                    myEmployee.Add(new HourlyEmployee(name, EmployeeType.HOURLY, hour, wage));
                    Console.WriteLine($"You have successfully added an employee {name}\n");
                    viewHourlyEmployee(myEmployee);
                }//end of if


                if (inp == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter the Employee Name: ");
                        name = Console.ReadLine();
                        if (int.TryParse(name, out int result))
                        {
                            Console.WriteLine("Name should not contain any number\n");
                            continue;
                        }
                        Console.WriteLine("Enter the gross sales of the Employee");
                        grossSale = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Commission Rate of the Employee ");
                        comissionRate = Double.Parse(Console.ReadLine());
                        if (grossSale < 0 || comissionRate < 0)
                        {
                            Console.WriteLine("Enter a number more than 0 ");
                            continue;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again \n");
                        continue;
                    }
                    myEmployee.Add(new CommissionEmployee(name, EmployeeType.COMMISSION, grossSale, comissionRate));
                    Console.WriteLine($"You have successfully added an employee {name}\n");
                    viewCommissionEmployee(myEmployee);
                }//end of if

                if (inp == 3)
                {
                    try
                    {
                        Console.WriteLine("Enter the Employee Name: ");
                        name = Console.ReadLine();
                        if (int.TryParse(name, out int result))
                        {
                            Console.WriteLine("Name should not contain any number\n");
                            continue;
                        }
                        Console.WriteLine("Enter Weekly Salary of the Employee");
                        weeklySalary = Double.Parse(Console.ReadLine());
                        if (weeklySalary < 0)
                        {
                            Console.WriteLine("Enter a number more than 0 ");
                            continue;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again \n");
                        continue;
                    }
                    myEmployee.Add(new SalariedEmployee(name, EmployeeType.SALARY, weeklySalary));
                    Console.WriteLine($"You have successfully added an employee {name}\n");
                    viewSalariedEmployee(myEmployee);
                }//end of if

                if (inp == 4)
                {
                    try
                    {
                        Console.WriteLine("Enter the Employee Name: ");
                        name = Console.ReadLine();
                        if (int.TryParse(name, out int result))
                        {
                            Console.WriteLine("Name should not contain any number\n");
                            continue;
                        }
                        Console.WriteLine("Enter Weekly Salary of the Employee");
                        weeklySalary = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the gross sales of the Employee");
                        grossSale = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Commission Rate of the Employee ");
                        comissionRate = Double.Parse(Console.ReadLine());
                        if (grossSale < 0 || comissionRate < 0)
                        {
                            Console.WriteLine("Enter a number more than 0 ");
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again \n");
                        continue;
                    }
                    myEmployee.Add(new SalaryPlusCommissionEmployee(name, EmployeeType.SALARYPLUSCOMMISSION, weeklySalary, grossSale, comissionRate));
                    Console.WriteLine($"You have successfully added an employee {name}\n");
                    viewSalaryPlusCommissionEmployee(myEmployee);
                }//end of if
            }//end of while
        }//end of AddEmployee method


        public void deleteEmployee(List<Employee> myEmployee)//to delete employee that the user want to
        {
            int inp = 0;
            int inp_1 = 0; //using this variable to take a second input 
            while (inp != 5)
            {
                Console.WriteLine("Please choose a type of employee you want to delete");
                Console.WriteLine("1-Delete Hourly Employee");
                Console.WriteLine("2-Delete Commission Employee");
                Console.WriteLine("3-Delete Salaried Employee");
                Console.WriteLine("4-Delete Salary Plus Commission Employee");
                Console.WriteLine("5-Back to Main Menu\n");
                try
                {
                    inp = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input try again \n");
                    continue;
                }
                if ((inp < 1 || inp > 5))
                {
                    Console.WriteLine("The number is out of range please insert between 1 to 5 \n");
                    continue;
                }
                if (inp == 1)
                {
                    viewHourlyEmployee(myEmployee);
                    Console.WriteLine("-----------");
                    Console.WriteLine("insert id of employee you want to delete");
                    try
                    {
                        inp_1 = Int32.Parse(Console.ReadLine());
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is HourlyEmployee))
                        {
                            Console.WriteLine("Id not found");
                            continue;
                        }
                        myEmployee.RemoveAll(i => i.EmployeeId == inp_1);
                        Console.WriteLine($"EmployeeID {inp_1} Deleted !\n");
                        viewHourlyEmployee(myEmployee);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again");
                        continue;
                    }

                }//end of if inp==1

                if (inp == 2)
                {
                    viewCommissionEmployee(myEmployee);
                    Console.WriteLine("-----------");
                    Console.WriteLine("insert id of employee you want to delete");
                    try
                    {
                        inp_1 = Int32.Parse(Console.ReadLine());
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is CommissionEmployee))
                        {
                            Console.WriteLine("Id not found");
                            continue;
                        }
                        myEmployee.RemoveAll(i => i.EmployeeId == inp_1);
                        Console.WriteLine($"EmployeeID {inp_1} Deleted !\n");
                        viewCommissionEmployee(myEmployee);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again");
                        continue;
                    }

                }//end of if inp==2

                if (inp == 3)
                {
                    viewSalariedEmployee(myEmployee);
                    Console.WriteLine("-----------");
                    Console.WriteLine("insert id of employee you want to delete");
                    try
                    {
                        inp_1 = Int32.Parse(Console.ReadLine());
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is SalariedEmployee))
                        {
                            Console.WriteLine("Id not found");
                            continue;
                        }
                        myEmployee.RemoveAll(i => i.EmployeeId == inp_1);
                        Console.WriteLine($"EmployeeID {inp_1} Deleted !\n");
                        viewSalariedEmployee(myEmployee);

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again");
                        continue;
                    }

                }//end of if inp==3

                if (inp == 4)
                {
                    viewSalaryPlusCommissionEmployee(myEmployee);
                    Console.WriteLine("-----------");
                    Console.WriteLine("insert id of employee you want to delete");
                    try
                    {
                        inp_1 = Int32.Parse(Console.ReadLine());
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is SalaryPlusCommissionEmployee))
                        {
                            Console.WriteLine("Id not found");
                            continue;
                        }
                        myEmployee.RemoveAll(i => i.EmployeeId == inp_1);
                        Console.WriteLine($"EmployeeID {inp_1} Deleted !\n");
                        viewSalaryPlusCommissionEmployee(myEmployee);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input try again");
                        continue;
                    }

                }//end of if inp==4
            }//end of while

        }//end of deleteEmployee method


        public void searchEmployee(List<Employee> myEmployee)
        {
            string inp = "";
            while (inp != "5")
            {
                Console.WriteLine("5-to go back to menu\n");
                Console.WriteLine("Enter employee name you want to search for");
                try
                {
                    inp = Console.ReadLine();
                    string firstLetter = inp.Substring(0, 1);
                    if (inp.Count() ==1)
                    {
                        var result = myEmployee
                        .Where(i => i.EmployeeName.StartsWith(inp, StringComparison.OrdinalIgnoreCase))
                        .OrderBy(i => i.EmployeeName)
                        .ToList();

                        if (inp != "5")
                        {
                            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "GrossEarnings");

                            foreach (Employee emp in result)
                            {
                                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp._EmployeeType, emp.GrossEarnings().ToString("C"));
                            }

                            Console.WriteLine("Search Results:");
                            table.Write(Format.MarkDown);
                        }
                    }
                
                    else
                    {
                        var result = myEmployee
                        .Where(i => i.EmployeeName.StartsWith(inp, StringComparison.OrdinalIgnoreCase) || i.EmployeeName.Contains(inp, StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(i => i.EmployeeName.StartsWith(firstLetter, StringComparison.OrdinalIgnoreCase))
                        .ThenBy(i => i.EmployeeName)
                        .ToList();
                        if (inp != "5")
                        {
                            ConsoleTable table = new ConsoleTable("Id", "NameType", "Employee Type", "GrossEarnings");

                            foreach (Employee emp in result)
                            {
                                table.AddRow(emp.EmployeeId, emp.EmployeeName, emp._EmployeeType, emp.GrossEarnings().ToString("C"));
                            }

                            Console.WriteLine("Search Results:");
                            table.Write(Format.MarkDown);
                        }
                    }
                }
                   
                catch (Exception)
                {

                }

            }//end of while
        }//end of searchEmployee method

        public void editEmployee(List<Employee> myEmployee) //this method for editing all info of a selected employee
        {
            int inp = 0;
            while (inp != 5)
            {
                inp = 0;
                double wage = 0.0;
                string name = "";
                double hour = 0.0;
                double grossSale = 0.0, comissionRate = 0.0, weeklySalary = 0.0;
                Console.WriteLine("Which Category of employee you want to edit? ");
                Console.WriteLine("1-Edit Hourly Employee");
                Console.WriteLine("2-Edit Commission Employee");
                Console.WriteLine("3-Edit Salaried Employee");
                Console.WriteLine("4-Edit Salary Plus Commission Employee");
                Console.WriteLine("5-Back to Main Menu\n");
                try
                {
                    inp = Int32.Parse(Console.ReadLine());
                    if (inp > 5 || inp < 1)
                    {
                        Console.WriteLine("The input is out of range please insert between 1 to 5");
                        continue;
                    }//end of if

                    if (inp == 1)
                    {
                        int inp_1 = 0;
                        viewHourlyEmployee(myEmployee);
                        Console.WriteLine("Enter an EmployeeID you want to change:\n");
                        try
                        {
                            inp_1 = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again\n");
                            continue;
                        }

                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is HourlyEmployee)) //to check if the employee id that user provide is exist and the employee id is of type HourlyEmployee
                        {
                            Console.WriteLine("This Id is not assigned to any employee\n");
                            continue;
                        }
                        Employee updateEmployee = myEmployee.Find(i => i.EmployeeId == inp_1);

                        try
                        {
                            Console.WriteLine("Enter the New Employee Name: ");
                            name = Console.ReadLine();
                            if (int.TryParse(name, out int result))
                            {
                                Console.WriteLine("Name should not contain any number\n");
                                continue;
                            }
                            Console.WriteLine("Enter new hours the Employee works");
                            hour = Double.Parse(Console.ReadLine());
                            if (hour < 0)
                            {
                                Console.WriteLine("Enter a number more than 0 ");
                                continue;
                            }
                            Console.WriteLine("Enter new wage the Employee works per hour");
                            wage = Double.Parse(Console.ReadLine());
                            if (wage < 0)
                            {
                                Console.WriteLine("Enter a number more than 0 ");
                                continue;
                            }

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again \n");
                            continue;
                        }
                        if (updateEmployee != null)
                        {
                            if (updateEmployee is HourlyEmployee)
                            {
                                ((HourlyEmployee)updateEmployee).EmployeeName = name;
                                ((HourlyEmployee)updateEmployee).Hours = hour;
                                ((HourlyEmployee)updateEmployee).Wage = wage;
                                Console.WriteLine("Employee updated successfuly!\n");
                            }
                        }
                        viewHourlyEmployee(myEmployee);

                    }//end of if inp==1

                    if (inp == 2)
                    {

                        int inp_1 = 0;
                        viewCommissionEmployee(myEmployee);
                        Console.WriteLine("Enter an EmployeeId you want to edit:\n");
                        try
                        {
                            inp_1 = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again");
                            continue;
                        }
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is CommissionEmployee)) //to check if the employee id that user provide is exist and the employee id is of type commission
                        {
                            Console.WriteLine("Id not found\n");
                            continue;
                        }

                        Employee updateEmployee = myEmployee.Find(i => i.EmployeeId == inp_1);
                        try
                        {

                            Console.WriteLine("Enter the new Employee Name: ");
                            name = Console.ReadLine();
                            if (int.TryParse(name, out int result))
                            {
                                Console.WriteLine("Name should not contain any number\n");
                                continue;
                            }
                            Console.WriteLine("Enter the new gross sales of the Employee");
                            grossSale = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the new Commission Rate of the Employee ");
                            comissionRate = Double.Parse(Console.ReadLine());
                            if (grossSale < 0 || comissionRate < 0)
                            {
                                Console.WriteLine("Enter a number more than 0 ");
                                continue;
                            }

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again \n");
                            continue;
                        }
                        if (updateEmployee != null)
                        {
                            if (updateEmployee is CommissionEmployee)
                            {
                                ((CommissionEmployee)updateEmployee).EmployeeName = name;
                                ((CommissionEmployee)updateEmployee).GrossSale = grossSale;
                                ((CommissionEmployee)updateEmployee).CommissionRate = comissionRate;
                                Console.WriteLine("Employee updated successfuly!");
                            }
                        }
                        viewCommissionEmployee(myEmployee);
                    }//end of if inp==2

                    if (inp == 3)
                    {

                        int inp_1 = 0;
                        viewSalariedEmployee(myEmployee);
                        Console.WriteLine("Enter an EmployeeId you want to edit:\n");
                        try
                        {
                            inp_1 = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again");
                            continue;
                        }
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is SalariedEmployee)) //to check if the employee id that user provide is exist and the employee id is of type Salaried
                        {
                            Console.WriteLine("Id not found\n");
                            continue;
                        }

                        Employee updateEmployee = myEmployee.Find(i => i.EmployeeId == inp_1);
                        try
                        {
                            Console.WriteLine("Enter a new Employee Name: ");
                            name = Console.ReadLine();
                            if (int.TryParse(name, out int result))
                            {
                                Console.WriteLine("Name should not contain any number\n");
                                continue;
                            }
                            Console.WriteLine("Enter a new Weekly Salary of the Employee");
                            weeklySalary = Double.Parse(Console.ReadLine());
                            if (weeklySalary < 0)
                            {
                                Console.WriteLine("Enter a number more than 0 ");
                                continue;
                            }

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again \n");
                            continue;
                        }
                        if (updateEmployee != null)
                        {
                            if (updateEmployee is SalariedEmployee)
                            {
                                ((SalariedEmployee)updateEmployee).EmployeeName = name;
                                ((SalariedEmployee)updateEmployee).WeeklySalary = weeklySalary;
                                Console.WriteLine("Employee updated successfuly!\n");
                            }
                        }
                        viewSalariedEmployee(myEmployee);
                    }//end of if inp==3

                    if (inp == 4)
                    {

                        int inp_1 = 0;
                        viewSalaryPlusCommissionEmployee(myEmployee);
                        Console.WriteLine("Enter an EmployeeId you want to edit:\n");
                        try
                        {
                            inp_1 = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again");
                            continue;
                        }
                        if (!myEmployee.Exists(i => i.EmployeeId == inp_1 && i is SalaryPlusCommissionEmployee)) //to check if the employee id that user provide is exist and the employee id is of type SalaryPlusCommisiion
                        {
                            Console.WriteLine("Id not found\n");
                            continue;
                        }

                        Employee updateEmployee = myEmployee.Find(i => i.EmployeeId == inp_1);
                        try
                        {
                            Console.WriteLine("Enter a new Employee Name: ");
                            name = Console.ReadLine();
                            if (int.TryParse(name, out int result))
                            {
                                Console.WriteLine("Name should not contain any number\n");
                                continue;
                            }
                            Console.WriteLine("Enter a new Weekly Salary of the Employee");
                            weeklySalary = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the new gross sales of the Employee");
                            grossSale = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the new Commission Rate of the Employee ");
                            comissionRate = Double.Parse(Console.ReadLine());
                            if (grossSale < 0 || comissionRate < 0)
                            {
                                Console.WriteLine("Enter a number more than 0 ");
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Invalid input try again \n");
                            continue;
                        }
                        if (updateEmployee != null)
                        {
                            if (updateEmployee is SalaryPlusCommissionEmployee)
                            {
                                ((SalaryPlusCommissionEmployee)updateEmployee).EmployeeName = name;
                                ((SalaryPlusCommissionEmployee)updateEmployee).WeeklySalary = weeklySalary;
                                ((SalaryPlusCommissionEmployee)updateEmployee).CommissionRate = comissionRate;
                                ((SalaryPlusCommissionEmployee)updateEmployee).GrossSale = grossSale;
                                Console.WriteLine("Employee updated successfuly!\n");
                            }
                        }
                        viewSalaryPlusCommissionEmployee(myEmployee);
                    }//end of if inp==4
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input try again\n");
                    continue;
                }
            }
        }//end of editEmployee method

    }//end of class
}
