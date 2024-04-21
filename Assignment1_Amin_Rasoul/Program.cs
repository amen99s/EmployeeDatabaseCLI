namespace MainApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeeModification emp = new EmployeeModification();
            List<Employee> myList = new List<Employee>();
            myList.Add(new HourlyEmployee("Liam Johnson ", EmployeeType.HOURLY, 40.0, 10.0));
            myList.Add(new HourlyEmployee("Sophia Williams", EmployeeType.HOURLY, 40.0, 20.0));
            myList.Add(new HourlyEmployee("Ethan Davis", EmployeeType.HOURLY, 40.0, 10.0));
            myList.Add(new CommissionEmployee("Olivia Anderson", EmployeeType.COMMISSION, 1000, 5));
            myList.Add(new CommissionEmployee("John Cena", EmployeeType.COMMISSION, 20000, 10));
            myList.Add(new CommissionEmployee("Donald Trump", EmployeeType.COMMISSION, 100000, 10));
            myList.Add(new CommissionEmployee("Jake Paul", EmployeeType.COMMISSION, 2000, 20));
            myList.Add(new SalariedEmployee("Mason Thompson", EmployeeType.SALARY, 2000));
            myList.Add(new SalariedEmployee("Ana Claricson", EmployeeType.SALARY, 1300));
            myList.Add(new SalariedEmployee("Marco Smith", EmployeeType.SALARY, 800));
            myList.Add(new SalaryPlusCommissionEmployee("Vanisa Reyes", EmployeeType.SALARYPLUSCOMMISSION, 1200, 2000, 10));
            myList.Add(new SalaryPlusCommissionEmployee("Cathrine Jacob", EmployeeType.SALARYPLUSCOMMISSION, 1200, 2000, 10));
            myList.Add(new SalaryPlusCommissionEmployee("Houston Lucas", EmployeeType.SALARYPLUSCOMMISSION, 1400, 1000, 25));

            int inp = 0;
            while (inp != 6)
            {
                inp = 0;
                Console.WriteLine("Welcome to Employee database");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("1-Add Employee");
                Console.WriteLine("2-Edit Employee");
                Console.WriteLine("3-Delete Employee");
                Console.WriteLine("4-View Employee");
                Console.WriteLine("5-Search Employee");
                Console.WriteLine("6-Exit\n");
                try
                {
                    inp = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input try again \n");
                    continue;
                }
                if ((inp < 1 || inp > 6))
                {
                    Console.WriteLine("The number is out of range please insert between 1 to 6 \n");
                    continue;
                }

                if (inp == 1)
                {
                    emp.AddEmployee(myList);
                }//end of if inp == 1
                if (inp == 2)
                {
                    emp.editEmployee(myList);
                }//end of if inp ==2
                if (inp == 3)
                {
                    emp.deleteEmployee(myList);
                }//end of if inp == 3
                if (inp == 4)
                {
                    int inp_1 = 0;
                    while (inp_1 != 6)
                    {
                        Console.WriteLine("Select How You want to view the table of employees");
                        Console.WriteLine("1-All Employees");
                        Console.WriteLine("2-Hourly Employees");
                        Console.WriteLine("3-Salaried Employees");
                        Console.WriteLine("4-Commission Employees");
                        Console.WriteLine("5-Salary Plus Commission Employees");
                        Console.WriteLine("6-Return to Back menu");
                        try
                        {
                            inp_1 = Int32.Parse(Console.ReadLine());
                        }
                        catch (Exception) { Console.WriteLine("Please use only number"); continue; }

                        if (inp_1 < 0 || inp_1 > 6)
                        {
                            Console.WriteLine("input is out of range please insert between 1 to 6");
                            continue;
                        }
                        if (inp_1 == 1)
                        {
                            emp.viewEmployee(myList);
                        }
                        if (inp_1 == 2)
                        {
                            emp.viewHourlyEmployee(myList);
                        }
                        if (inp_1 == 3)
                        {
                            emp.viewSalariedEmployee(myList);
                        }
                        if (inp_1 == 4)
                        {
                            emp.viewCommissionEmployee(myList);
                        }
                        if (inp_1 == 5)
                        {
                            emp.viewSalaryPlusCommissionEmployee(myList);
                        }

                    }


                }//end oi if inp == 4

                if (inp == 5)
                {
                    emp.searchEmployee(myList);
                }

            }
        }//end of main
    }
}
