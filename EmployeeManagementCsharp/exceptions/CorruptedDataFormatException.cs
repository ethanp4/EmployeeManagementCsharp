using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace EmployeeManagementCsharp.exceptions
{
    public class CorruptedDataFormatException : Exception
    {
        public CorruptedDataFormatException(String message) : base(message) { }
    }
}
