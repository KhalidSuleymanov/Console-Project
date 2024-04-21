using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectInCode
{
    internal class HumanResourceManager : IHumanResourceManager
    {
        List<Employee> _employees = new List<Employee>();

        public List<Employee> Employees { get { return _employees; } }

        public int ITEmployeeCount => _getEmployeeCount(x => x.Department == Department.IT);
        public int ManagementEmployeeCount => _getEmployeeCount(x => x.Department == Department.Management);
        public int FinanceEmployeeCount => _getEmployeeCount(x => x.Department == Department.Finance);

        private int _maxEmployeeCountForPerDepartment = 20;
        public int MaxEmployeeCountForPerDepartment { get { return _maxEmployeeCountForPerDepartment; } }

        public List<Employee> employees => _employees;

        public void AddEmployee(Employee employee)
        {
            if (_hasEmployeeNo(employee.No))
            {
                throw new Exception1();
            }

            if (employee.Department == Department.IT)
            {
                if (ITEmployeeCount <= _maxEmployeeCountForPerDepartment)
                {
                    _employees.Add(employee);
                }
                else
                {
                    throw new Exception3();
                }
            }
            else if (employee.Department == Department.Management)
            {
                if (ManagementEmployeeCount <= _maxEmployeeCountForPerDepartment)
                {
                    _employees.Add(employee);
                }

                else
                {
                    throw new Exception3();
                }
            }
            else
            {
                if (FinanceEmployeeCount <= _maxEmployeeCountForPerDepartment)
                {
                    _employees.Add(employee);
                }
                else
                {
                    throw new Exception3();
                }
            }

        }


        private int _getEmployeeCount(Predicate<Employee> predicate)
        {
            int count = 0;
            foreach (var item in _employees)
            {
                if (predicate(item))
                {
                    count++;
                }
            }
            return count;
        }

        private bool _hasEmployeeNo(string employeeNo)
        {
            foreach (var item in _employees)
            {
                if (item.No == employeeNo)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveEmployee(string employeeNo)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(string employeeNo, double salary)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SearchEmployee(string str)
        {
            throw new NotImplementedException();
        }
    }
}
