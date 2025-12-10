using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementCsharp.model
{
    public class FullTimeEmployee : Employee
    {
        private double salary;
        private List<String> benefits = new();

        public FullTimeEmployee(int id, string firstName, string lastName, DateOnly dateOfBirth, enums.Position currentPosition, enums.Department department, Employee manager, double salary) : base(id, firstName, lastName, dateOfBirth, currentPosition, department, manager)
        {
            setSalary(salary);
        }

        public double getSalary() { return salary; }

        public void setSalary(double salary)
        {
            if (salary < 0)
            {
                throw new InvalidDataException("Salary must be non-negative");
            }
            this.salary = salary;
        }

        public List<String> getBenefits() { return benefits; }

        public void setBenefits(String benefit) { benefits.Add(benefit); }

        public void getPaid()
        {
            Console.Write("Full-time employee %s %s is paid a salary of %.2f%n", getFirstName(), getLastName(), salary);
        }
    }
}
