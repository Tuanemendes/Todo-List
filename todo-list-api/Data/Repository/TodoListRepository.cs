using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TodoList>> GetAllTodo()
        {
            return await _todoListContext.TodoLists.ToListAsync();
        }

        public async Task<TodoList> GeByIdTodo(int id)
        {
            return await _todoListContext.TodoLists.Where(todo => todo.Id == id).FirstOrDefaultAsync();
        }

        public void AddTodo(TodoList todoList)
        {
            _todoListContext.Add(todoList);
        }

        public void UpdateTodo(TodoList todoList)
        {
            _todoListContext.Update(todoList);
        }

        public void DeleteTodo(TodoList todoList)
        {
            _todoListContext.Remove(todoList);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _todoListContext.SaveChangesAsync() > 0;
        }

    }
}