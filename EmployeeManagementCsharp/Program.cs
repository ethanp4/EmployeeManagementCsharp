using System;
using System.Collections.Generic;
using System.Threading;
using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;
using EmployeeManagementCsharp.io;
using EmployeeManagementCsharp.model;

namespace EmployeeManagementCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Employee> employees = new List<Employee>();

                // Create a manager
                // Reason why Alice position is President is because assuming Manager role is null in this scenario
                Manager manager = new Manager(1,
                        "Alice",
                        "Smith",
                        new DateOnly(1980, 5, 15),
                        Position.PRESIDENT,
                        Department.ADMINISTRATION,
                        120000);

                // Full-time instructor
                FullTimeInstructor fullTimeInstructor = new FullTimeInstructor(2,
                        "Bob",
                        "Johnson",
                        new DateOnly(1985, 3, 10),
                        manager,
                        80000);
                manager.addDirectReport(fullTimeInstructor);

                // Part-time instructor
                PartTimeInstructor partTimeInstructor = new PartTimeInstructor(
                        3,
                        "Carol",
                        "Lee",
                        new DateOnly(1990, 7, 20),
                        manager,
                        60.0,
                        20
                );
                manager.addDirectReport(partTimeInstructor);

                employees.Add(manager);
                employees.Add(fullTimeInstructor);
                employees.Add(partTimeInstructor);

                // Dynamic binding
                foreach (Employee e in employees)
                {
                    e.getPaid();
                    e.reportToManager();
                    Console.WriteLine(e);
                    Console.WriteLine();
                }

                // Static binding
                // The compiler chooses this overloaded method at compile time
                employees[1].getPaid(500.0);

                // Multithreading with Runnable (ThreadStart in C#)
                string filePath = "employees.csv";

                // Save in a background thread
                FileHandler saveTask = new FileHandler(filePath, employees, true);
                Thread saveThread = new Thread(new ThreadStart(saveTask.Run));
                saveThread.Start();
                saveThread.Join();

                // Load in another background thread
                FileHandler loadTask = new FileHandler(filePath, employees, false);
                Thread loadThread = new Thread(new ThreadStart(loadTask.Run));
                loadThread.Start();
            }
            catch (InvalidIdException e)
            {
                Console.Error.WriteLine("Validation error: " + e.Message);
            }
            catch (InvalidAgeException e)
            {
                Console.Error.WriteLine("Validation error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Unexpected error in main: " + e.Message);
            }
        }
    }
}
