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
            var todoList = await _todoListContext.TodoLists.ToListAsync();
            return todoList;
        }

        public async Task<TodoList> GeByIdTodo(int id)
        {
            var todoId = await _todoListContext.TodoLists.FindAsync(id);
            return todoId!; 
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