using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;

namespace EmployeeManagementCsharp.model
{
    internal class PartTimeEmployee : Employee
    {
        private double hourlyRate;
        private double hoursWorked;

        public PartTimeEmployee(int id, string firstName, string lastName, DateOnly dateOfBirth, Position currentPosition, Department department, Employee manager, double hourlyRate, double hoursWorked)
            : base(id, firstName, lastName, dateOfBirth, currentPosition, department, manager)
        {
            this.hourlyRate = hourlyRate;
            this.hoursWorked = hoursWorked;
        }

        public double getHourlyRate()
        {
            return hourlyRate;
        }

        public void setHourlyRate(double hourlyRate)
        {
            if (hourlyRate < 0)
            {
                throw new ArgumentException("Hourly rate must be non-negative.");
            }

            this.hourlyRate = hourlyRate;
        }

        public double getHoursWorked()
        {
            return hoursWorked;
        }

        public void setHoursWorked(double hoursWorked)
        {
            if (hoursWorked < 0)
            {
                throw new ArgumentException("Hours worked must be non-negative.");
            }

            this.hoursWorked = hoursWorked;
        }

        public override void getPaid()
        {
            double amount = hourlyRate * hoursWorked;
            Console.WriteLine($"Part-time employee {getFirstName()} {getLastName()} is paid {amount:F2} ({hourlyRate:F2} x {hoursWorked:F2} hours)");
        }
    }
}
