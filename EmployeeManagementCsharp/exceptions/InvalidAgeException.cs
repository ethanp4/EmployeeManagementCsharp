using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementCsharp.exceptions
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(String message) : base(message) { }
    }
}
