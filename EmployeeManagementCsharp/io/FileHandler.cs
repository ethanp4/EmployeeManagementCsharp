using EmployeeManagementCsharp.enums;
using EmployeeManagementCsharp.exceptions;
using EmployeeManagementCsharp.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using InvalidDataException = EmployeeManagementCsharp.exceptions.InvalidDataException;

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

                    loaded.Add(e);
                }
            }
            catch (Exception ex)
            {
                throw new CorruptedDataFormatException("Error parsing line: " + " => " + ex.Message);
            }
            return loaded;
        }

        public void saveEmployees()
        {
            using (StreamWriter streamWriter = new StreamWriter(FILE_PATH, false))
            {
                foreach (Employee e in employees)
                {
                    StringBuilder sb = new StringBuilder();

                    if (e is FullTimeEmployee f)
                    {
                        sb.Append("FULL_TIME").Append(',');
                        sb.Append(f.getId()).Append(',');
                        sb.Append(f.getFirstName()).Append(',');
                        sb.Append(f.getLastName()).Append(',');
                        sb.Append(f.getDateOfBirth()).Append(',');
                        sb.Append(f.getCurrentPosition()).Append(',');
                        sb.Append(f.getDepartment()).Append(',');
                        sb.Append(f.getSalary());
                    }
                    else if (e is PartTimeEmployee p)
                    {
                        sb.Append("PART_TIME").Append(',');
                        sb.Append(p.getId()).Append(',');
                        sb.Append(p.getFirstName()).Append(',');
                        sb.Append(p.getLastName()).Append(',');
                        sb.Append(p.getDateOfBirth()).Append(',');
                        sb.Append(p.getCurrentPosition()).Append(',');
                        sb.Append(p.getDepartment()).Append(',');
                        sb.Append(p.getHourlyRate()).Append(',');
                        sb.Append(p.getHoursWorked());
                    }

                    streamWriter.WriteLine(sb.ToString());
                }
            }
        }

        public void Run()
        {
            try
            {
                if (saveMode)
                {
                    saveEmployees();
                }
                else
                {
                    this.employees = loadEmployees();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("FileHandler thread error: " + e.Message);
            }
        }
    }
}
