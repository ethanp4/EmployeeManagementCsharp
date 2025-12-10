using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagementCsharp.exceptions
{
    public class InvalidIdException : Exception
    {
        public InvalidIdException(String message) : base(message) { }
    }
}
