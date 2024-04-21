using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProjectInCode
{
    internal class Employee
    {
        static int _totalCount = 1000;
        private int _no;
        private double _salary;

        public string No
        {
            get
            {
                return (Department.ToString()).Substring(0, 2) + _no.ToString();
            }
        }
        public string FullName;
        public string Position;
        public double Salary
        {
            set
            {
                if (value >= 1000)
                {
                    _salary = value;
                }
                else
                {
                    throw new Exception("Salary can not less than 1000 azn");
                }
            }
            get
            {
                return _salary;
            }
        }
        public Department Department { get; internal set; }
        public DateTime StartDate;


        public Employee()
        {
            _no = _totalCount + 1;
            _totalCount = _no;
        }

        public override string ToString()
        {
            return $"No: {No}\nFullName: {FullName}\nSalary: {Salary}\nPosition: {Position}\nDepartment: {Department.ToString()}\nStartdate: {StartDate}";
        }
    }
}
