using System;
using System.Linq;

namespace ConsoleProjectInCode
{
    internal class Program
    {
        static IHumanResourceManager humanResourceManager = new HumanResourceManager();
        static void Main(string[] args)
        {
            string operation;
            do
            {
                Console.WriteLine("<=======================================> MENU <=======================================>");
                Console.WriteLine("\n     1: Show list of employees");
                Console.WriteLine("     2: Show a list of employees according to the department");
                Console.WriteLine("     3: To add workers");
                Console.WriteLine("     4: Make changes on the employee");
                Console.WriteLine("     5: Remove employee");
                Console.WriteLine("     6: Search the employee");
                Console.WriteLine("     7: Employees who started work during the entered date range");
                Console.WriteLine("     8: Show the average salary of the employees in the selected department");
                Console.WriteLine("     0: Out menu");
                Console.WriteLine("\n<=======================================> MENU <=======================================>");
                Console.WriteLine("\nPlease select an operation and click Enter button:");
                operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        #region case1
                        Console.Clear();

                        ShowEmployeesInfo(humanResourceManager);

                        Console.ReadLine();
                        break;
                    #endregion
                    case "2":
                        #region case2
                        Console.Clear();

                        Console.WriteLine("Please enter departament");
                        string departmentName = Console.ReadLine();
                        object departmentObject;

                        if (Enum.TryParse(typeof(Department), departmentName, true, out departmentObject))
                        {
                            Department department1 = (Department)departmentObject;
                            var departmentEmployee = humanResourceManager.employees
                                .Where(x => x.Department == department1)
                                .ToList();
                            departmentEmployee.ForEach(x =>
                            {
                                Console.WriteLine(x.ToString());
                            });
                        }
                        else
                        {
                            Console.WriteLine("You did not choose the right department!!!");
                        }
                        Console.ReadLine();
                        break;
                    #endregion
                    case "3":
                        #region case3
                        Console.Clear();
                        string fullname;
                        do
                        {
                            Console.WriteLine("Please enter Fullname");
                            fullname = Console.ReadLine();
                        } while (!FullName(fullname));

                        Console.WriteLine("Please enter Department");
                        foreach (var item in Enum.GetValues(typeof(Department)))
                        {
                            Console.WriteLine($"{(byte)item} - {item}");
                        }
                        byte typeByte;
                        string typeStr;
                        do
                        {
                            typeStr = Console.ReadLine();
                            typeByte = Convert.ToByte(typeStr);
                        } while (!Enum.IsDefined(typeof(Department), typeByte));

                        double salary;
                        do
                        {
                            Console.WriteLine("Please enter salary");
                            salary = Convert.ToDouble(Console.ReadLine());
                        } while (salary <= 1000);

                        string position;
                        do
                        {
                            Console.WriteLine("Please enter position");
                            position = Console.ReadLine();
                        } while (position.Length < 2);


                        bool trueOrFalse2 = false;
                        DateTime wantedDate = new DateTime();
                        do
                        {
                            Console.WriteLine("Please enter Start Date:\nThe date must be in this format:\nDay-Month-Year");
                            string startDate1 = Console.ReadLine();
                            try
                            {
                                wantedDate = Convert.ToDateTime(startDate1);
                                trueOrFalse2 = true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Tarix duzgun deyil");
                                trueOrFalse2 = false;
                            }
                        } while (trueOrFalse2 == false);

                        AddEmployee(fullname, position, salary, (Department)Enum.Parse(typeof(Department), typeStr), wantedDate);
                        Console.ReadLine();
                        break;
                    #endregion
                    case "4":
                        #region case4
                        Console.Clear();
                        string employeeNo;
                        bool trueOrFalse = false;
                        do
                        {
                            Console.WriteLine("Please enter the employee no which you want to change");
                            employeeNo = Console.ReadLine();
                            var employee = humanResourceManager.employees.FirstOrDefault(x => x.No == employeeNo);
                            if (employee is null)
                            {
                                trueOrFalse = false;
                                Console.WriteLine("There is no employee with such number");
                                Console.WriteLine("The employee number must be on form AA1035.\n(AA - The first two letters of the department.)");
                            }
                            else
                            {
                                trueOrFalse = true;
                                Console.WriteLine($"Employee FullName: {employee.FullName}\nEmployee Salary: {employee.Salary}\nEmployee Position: {employee.Position}");
                                Console.WriteLine();
                                Console.WriteLine("Enter the salary: ");
                                double editedSalary = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("Enter the Position: ");
                                string editedPosition = Console.ReadLine();

                                employee.Salary = editedSalary;
                                employee.Position = editedPosition;
                            }
                        } while (!trueOrFalse);
                        Console.ReadLine();
                        break;
                    #endregion
                    case "5":
                        #region case5
                        Console.Clear();
                        bool trueOrFalse1 = false;
                        do
                        {
                            Console.WriteLine("Please enter the employee no which you want to remove");
                            employeeNo = Console.ReadLine();
                            var employee = humanResourceManager.employees.FirstOrDefault(x => x.No == employeeNo);
                            if (employee is null)
                            {
                                trueOrFalse1 = false;
                                Console.WriteLine("There is no employee with such number");
                                Console.WriteLine("The employee number must be on form AA1035.\n(AA - The first two letters of the department.)");
                            }
                            else
                            {
                                trueOrFalse1 = true;
                                string responseMessage = $"Removed {employee.FullName}";
                                responseMessage = humanResourceManager.employees.Remove(employee) ? responseMessage : "Invalid error. System cannnot deleted employee";
                                Console.WriteLine(responseMessage);
                            }
                        } while (!trueOrFalse1);
                        Console.ReadLine();
                        break;
                    #endregion
                    case "6":
                        #region case6
                        Console.Clear();

                        ShowEmployeesForName();

                        Console.ReadLine();
                        break;
                    #endregion
                    case "7":
                        #region case7
                        Console.Clear();

                        FoundEmployeeForDate(humanResourceManager);

                        Console.ReadLine();
                        break;
                    #endregion
                    case "8":
                        #region case8
                        Console.Clear();

                        var average = AverageOfEmployee();
                        if (average == -1)
                        {
                            Console.WriteLine("System error");
                        }
                        else
                        {
                            Console.WriteLine($"Average salary is {average}");
                        }

                        Console.ReadLine();
                        break;
                    #endregion
                    case "0":
                        #region case0
                        Console.Clear();
                        Console.WriteLine("\n\n<=======================================> Thank You <=======================================>");
                        Console.ReadLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("\n     You choose the wrong selection");

                        Console.ReadLine();
                        break;
                        #endregion
                }
            } while (operation != "0");
        }

        static void AddEmployee(string fullName, string position, double salary, Department department, DateTime startDate)
        {
            Employee employee = new Employee
            {
                FullName = fullName,
                Position = position,
                Salary = salary,
                Department = department,
                StartDate = startDate,
            };
            humanResourceManager.AddEmployee(employee);
        }

        static void ShowEmployeesInfo(IHumanResourceManager info)
        {
            foreach (var item in info.employees)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static double AverageOfEmployee()
        {
            Console.WriteLine("Please enter department:");

            string departmentName = Console.ReadLine();
            object departmentObject;
            if (Enum.TryParse(typeof(Department), departmentName, true, out departmentObject))
            {
                Department department1 = (Department)departmentObject;

                double sum = 0;
                int count = 0;

                foreach (var item in humanResourceManager.employees)
                {
                    if (item.Department == department1)
                    {
                        sum += item.Salary;
                        count++;
                    }
                }
                if (count == 0)
                {
                    return -1;
                }
                double average = sum / count;
                return average;
            }
            else
            {
                Console.WriteLine("You have not selected the correct department!!!");
            }
            return -1;
        }

        static void FoundEmployeeForDate(IHumanResourceManager date)
        {
            Console.WriteLine("Enter the first Date");
            var startDate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the second date");
            var lastDate = Convert.ToDateTime(Console.ReadLine());
            int searchCount = 0;

            foreach (var item in date.employees)
            {
                if (item.StartDate >= startDate && item.StartDate <= lastDate)
                {
                    searchCount++;
                    Console.WriteLine(item.ToString());
                }
            }
            if (searchCount == 0)
            {
                Console.WriteLine("There is not user in system");
            }
        }
        static void ShowEmployeesForName()
        {
            Console.WriteLine("Please enter word which you found the employees");
            string name1 = Console.ReadLine();

            int searchCount = 0;

            foreach (var item in humanResourceManager.employees)
            {
                if (item.FullName.Contains(name1))
                {
                    searchCount++;
                    Console.WriteLine($"No: {item.No}\nFullName: {item.FullName}\nSalary: {item.Salary}\nPosition: {item.Position}\nDepartment: {item.Department}\nStartdate: {item.StartDate}");
                }
            }
            if (searchCount == 0)
            {
                Console.WriteLine("There is not user in System");
            }
        }
        static bool IsName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (!char.IsUpper(name[0]))
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLower(name[i]))
                {
                    return false;
                }
            }
            return true;
        }

        static bool FullName(string name)
        {
            var fullName = name.Split(' ');
            if(fullName.Length < 2 )
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!IsName(fullName[1]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
