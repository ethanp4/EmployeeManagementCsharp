using System;
using System.Collections.Generic;
using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;

namespace EmployeeManagementCsharp.model
{
    internal class Manager : FullTimeEmployee
    {
        private List<Employee> directReports = new List<Employee>();

        public Manager(int id, string firstName, string lastName, DateOnly dateOfBirth, Position currentPosition, Department department, double salary)
            : base(id, firstName, lastName, dateOfBirth, currentPosition, department, null, salary)
        {
        }

        public List<Employee> getDirectReports()
        {
            return directReports;
        }

        public void addDirectReport(Employee employee)
        {
            directReports.Add(employee);
            employee.setManager(this);
        }

        public override void reportToManager()
        {
            Console.WriteLine($"Manager {getFirstName()} {getLastName()} reports directly to the President / Board.");
        }

        public override void getPaid()
        {
            Console.WriteLine($"Manager {getFirstName()} {getLastName()} is paid a managerial salary of {getSalary():F2}");
        }
    }
}
