
using todo_list_api.Data.Repository;
using todo_list_api.Exceptions;
using todo_list_api.Model;

namespace todo_list_api.Service
{
    public class TodoListService : ITodoListService
    {
        protected readonly ITodoListRepository _todoListRepository;

        public TodoListService(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public async Task<IEnumerable<TodoList>> GetAllTodos()
        {

            var allTodos = await _todoListRepository.GetAllTodo();
            return allTodos == null || !allTodos.Any() ? throw new NoTodoFoundException("Não foram encontradas listas de tarefas") : allTodos;

        }

        public async Task<TodoList> GetTodoById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id inválido!");
            }
            var todoId = await _todoListRepository.GeByIdTodo(id) ?? throw new ResourceNotFoundException($"Id não encontrado!");
            return todoId;
        }

        public Task<bool> AddNewTodo(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTodoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExistingTodo(int id, TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}