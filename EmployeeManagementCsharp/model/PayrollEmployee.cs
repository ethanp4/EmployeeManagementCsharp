using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;

namespace EmployeeManagementCsharp.model
{
    internal class PayrollEmployee : FullTimeEmployee
    {
        public PayrollEmployee(int id, string firstName, string lastName, DateOnly dateOfBirth, Employee manager, double salary)
            : base(id, firstName, lastName, dateOfBirth, Position.ACCOUNTANT, Department.PAYROLL, manager, salary)
        {
        }

        public override void getPaid()
        {
            Console.WriteLine($"Payroll employee {getFirstName()} {getLastName()} processes their own salary of {getSalary():F2}");
        }
    }
}
