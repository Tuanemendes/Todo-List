using todo_list_api.Model;

namespace todo_list_api.Data.Repository
{
    public interface ITodoListRepository
    {
        Task<IEnumerable<TodoList>> GetAllTodo();
        Task<TodoList> GeByIdTodo(int id);

        void AddTodo(TodoList todoList);

        void SaveTodo(TodoList todoList);

        void Delete(int id);

        Task<bool> SaveChangeAsync();
        
    }
}