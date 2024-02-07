using todo_list_api.Model;

namespace todo_list_api.Data.Repository
{
    public class TodoListRepository : ITodoListRepository
    {
        private readonly TodoListContext _todoListContext;

        public TodoListRepository(TodoListContext todoListContext)
        {
            _todoListContext = todoListContext;
        }

        public Task<IEnumerable<TodoList>> GetAllTodo()
        {
            throw new NotImplementedException();
        }

         public Task<TodoList> GeByIdTodo(int id)
        {
            throw new NotImplementedException();
        }

        public void AddTodo(TodoList todoList)
        {
            _todoListContext.Add(todoList);
        }

        public void SaveTodo(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<bool> SaveChangeAsync()
        {
            return await _todoListContext.SaveChangesAsync() > 0;
        }

    }
}