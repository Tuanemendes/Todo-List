using todo_list_api.Model;

namespace todo_list_api.Service
{
    public interface ITodoListService
    {
        Task<IEnumerable<TodoList>> GetAllTodos();
        Task<TodoList> GetTodoById(int id);
        Task<IEnumerable<TodoList>>GetByStatus(Status status); 
        Task<bool> AddNewTodo(TodoList todoList);
        Task<bool> UpdateExistingTodo(int id, TodoList todoList);
        Task<bool> DeleteTodoById(int id);

    }


}