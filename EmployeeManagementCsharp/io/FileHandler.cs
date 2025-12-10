using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;
using EmployeeManagementCsharp.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace EmployeeManagementCsharp.io
{
    public class FileHandler //difference: runnable isnt an interface in c#
    {
        private readonly string FILE_PATH; //difference: paths are strings in c#
        private List<Employee> employees;
        private readonly bool saveMode;

        public FileHandler(string FILE_PATH, List<Employee> employees, Boolean saveMode)
        {
            this.FILE_PATH = FILE_PATH;
            this.employees = employees;
            this.saveMode = saveMode;
        }

        public List<Employee> loadEmployees() //difference: "throws" keyword doesnt exist in c#
        {
            List<Employee> loaded = new();

            if (!File.Exists(FILE_PATH))
            {
                return loaded;
            }

            try
            {
                StreamReader streamReader = new StreamReader(FILE_PATH);
                string? line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    String[] parts = line.Split(',');

                    if (parts.Length < 7)
                    {
                        throw new CorruptedDataFormatException("Not enough fields: " + line);
                    }

                    String type = parts[0];
                    int id = int.Parse(parts[1]);
                    String firstName = parts[2];
                    String lastName = parts[3];
                    DateOnly dob = DateOnly.Parse(parts[4]);
                    Position position = Enum.Parse<Position>(parts[5]);
                    Department dept = Enum.Parse<Department>(parts[6]);

                    Employee e;

                    switch (type)
                    {
                        case "FULL_TIME":
                            double salary = Double.Parse(parts[7]);
                            e = new FullTimeEmployee(id, firstName, lastName, dob, position, dept, null, salary);
                            break;

                        case "PART_TIME":
                            double rate = Double.Parse(parts[7]);
                            double hours = Double.Parse(parts[8]);
                            e = new PartTimeEmployee(id, firstName, lastName, dob, position, dept, null, rate, hours);
                            break;

                        default:
                            throw new InvalidDataException("Unknown employee type: " + type);
                    }

                    loaded.Append(e);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
                return loaded;
            }
            return loaded;
        }

        public void saveEmployees()
        {
            StreamWriter streamWriter = new StreamWriter(FILE_PATH, false);

            foreach (Employee e in employees)
            {
                StringBuilder sb = new StringBuilder();

                if (e is FullTimeEmployee)
                {

                }
            }
        }
    }
}
