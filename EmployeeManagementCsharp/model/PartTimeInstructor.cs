using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;

namespace EmployeeManagementCsharp.model
{
    internal class PartTimeInstructor : PartTimeEmployee
    {
        // Constructor
        public PartTimeInstructor(int id, string firstName, string lastName, DateOnly dateOfBirth, Employee manager, double hourlyRate, double hoursWorked)
            : base(id, firstName, lastName, dateOfBirth, Position.ADJUNCT_INSTRUCTOR, Department.STAFF, manager, hourlyRate, hoursWorked)
        {
        }

        public override void getPaid()
        {
            base.getPaid();
        }
    }
}
