using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementCsharp.exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(String message) : base(message) { }
    }
}
