using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;

namespace EmployeeManagementCsharp.model
{
    internal class FullTimeInstructor : FullTimeEmployee
    {
        public FullTimeInstructor(int id, string firstName, string lastName, DateOnly dateOfBirth, Employee manager, double salary)
            : base(id, firstName, lastName, dateOfBirth, Position.SENIOR_INSTRUCTOR, Department.STAFF, manager, salary)
        {
        }

        public override void getPaid()
        {
            Console.WriteLine($"Full-time instructor {getFirstName()} {getLastName()} is paid salary {getSalary():F2}");
        }
    }
}
