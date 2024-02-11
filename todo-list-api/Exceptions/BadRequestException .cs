namespace todo_list_api.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException (string message) : base(message) { }
    }
}