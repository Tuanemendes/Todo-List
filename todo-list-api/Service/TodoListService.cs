
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

            try
            {
                var alltodos = await _todoListRepository.GetAllTodo();
                if (alltodos == null || !alltodos.Any())
                {
                    throw new NoTodoFoundException("Não foram encontradas listas de tarefas");
                }
                return alltodos;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Erro ao obter todas as tarefas:{exception.Message} ");
                throw;
            }
        }
        public Task<bool> AddNewTodo(TodoList todoList)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTodoById(int id)
        {
            throw new NotImplementedException();
        }


        public Task<TodoList> GetTodoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateExistingTodo(int id, TodoList todoList)
        {
            throw new NotImplementedException();
        }
    }
}