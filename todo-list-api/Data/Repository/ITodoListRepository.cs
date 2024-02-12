using todo_list_api.Model;

namespace todo_list_api.Data.Repository
{
    public interface ITodoListRepository
    {
        Task<IEnumerable<TodoList>> GetAllTodo();
        Task<TodoList> GeByIdTodo(int id);
        Task<IEnumerable<TodoList>> GetByStatus(Status status);
        void AddTodo(TodoList todoList);
        void UpdateTodo(TodoList todoList);
        void DeleteTodo(TodoList todoList);
        Task<bool> SaveChangeAsync();
        
    }
}