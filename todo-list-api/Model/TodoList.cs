namespace todo_list_api.Model
{
    public class TodoList
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Status TodoStatus { get; set; }
    }
}