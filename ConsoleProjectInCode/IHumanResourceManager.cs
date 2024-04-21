using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectInCode
{
    internal interface IHumanResourceManager
    {
        int ITEmployeeCount { get; }
        int ManagementEmployeeCount { get; }
        int FinanceEmployeeCount { get; }
        int MaxEmployeeCountForPerDepartment { get; }

        List<Employee> employees { get; }
        void AddEmployee(Employee employee);

        void RemoveEmployee(string employeeNo);

        void EditEmployee(string employeeNo, double salary);

        List<Employee> SearchEmployee(string str);
    }
}
