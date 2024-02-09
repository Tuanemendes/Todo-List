using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todo_list_api.Exceptions
{
    public class NoTodoFoundException : Exception
    {
        public NoTodoFoundException(string message) : base(message) { }
    }
}