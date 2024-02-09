namespace todo_list_api.Exceptions
{
    public class NoTodoFoundException : Exception
    {
        public NoTodoFoundException(string message) : base(message) { }


    }
}