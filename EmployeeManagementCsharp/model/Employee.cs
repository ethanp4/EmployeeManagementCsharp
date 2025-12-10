using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementCsharp.model
{
    public abstract class Employee
    {
        private int id;
        private String firstName;
        private String lastName;
        private DateOnly dateOfBirth;
        private Position currentPosition;
        private Department department;
        private Employee manager;

        public Employee(int id, string firstName, string lastName, DateOnly dateOfBirth, Position currentPosition, Department department, Employee manager)
        {
            setId(id);
            setDateOfBirth(dateOfBirth);

            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.currentPosition = currentPosition;
            this.department = department;
            this.manager = manager;
        }

        public int getId() { return id; }

        public void setId(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException("ID must be positive");
            }

            this.id = id;
        }

        public String getFirstName() { return firstName; }

        public void setFirstName(String firstName) { this.firstName = firstName; }

        public String getLastName() { return lastName; }

        public void setLastName(String lastName) { this.lastName = lastName; }

        public DateOnly getDateOfBirth()
        {
            return dateOfBirth;
        }

        public void setDateOfBirth(DateOnly dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;

            if (age < 18 || age > 75)
            {
                throw new InvalidAgeException("Employee age must be between 18 and 75.");
            }

            this.dateOfBirth = dateOfBirth;
        }

        public Position getCurrentPosition() { return currentPosition; }

        public void setCurrentPosition(Position currentPosition) { this.currentPosition = currentPosition; }

        public Department getDepartment()
        {
            return department;
        }

        public void setDepartment(Department department)
        {
            this.department = department;
        }

        public Employee getManager()
        {
            return manager;
        }

        public void setManager(Employee manager)
        {
            this.manager = manager;
        }

        // Polymorphism/Binding
        public abstract void getPaid();

        // Static binding: overloaded version (compile-time binding)
        public void getPaid(double bonus)
        {
            Console.WriteLine($"{firstName} {lastName} received a bonus of {bonus:F2}");
        }

        // Dynamic binding: subclasses may override reporting behavior if needed
        virtual public void reportToManager()
        {
            if (manager != null)
            {
                Console.WriteLine($"{firstName} {lastName} is reporting to manager {manager.getFirstName()} {manager.getLastName()}");
            }
            else
            {
                Console.WriteLine($"{firstName} {lastName} has no manager assigned.");
            }
        }

        public override string ToString()
        {
            return "Employee{" +
                    "id=" + id +
                    ", firstName='" + firstName + '\'' +
                    ", lastName='" + lastName + '\'' +
                    ", dateOfBirth=" + dateOfBirth +
                    ", currentPosition=" + currentPosition +
                    ", department=" + department +
                    ", manager=" + manager +
                    '}';
        }
    }
}
