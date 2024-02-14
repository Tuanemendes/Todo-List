
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

            if (allTodos == null || !allTodos.Any())
            {
                throw new ResourceNotFoundException("Lista de tarefas não encontrada!");
            }

            return allTodos;

        }

        public async Task<TodoList> GetTodoById(int id)
        {

            if (id < 0)
            {
                throw new ArgumentException("Id inválido!");
            }
            var todoId = await _todoListRepository.GeByIdTodo(id) ?? throw new ResourceNotFoundException("Id da Lista de tarefas não encontrado!");
            return todoId;
        }

        public async Task<IEnumerable<TodoList>> GetByStatus(Status status)
        {
            if (status != Status.Pendente && status != Status.EmAndamento && status != Status.Concluido)
            {
                throw new ArgumentException("Status Inválido!");
            }

            var todoListsFilterStatus = await _todoListRepository.GetByStatus(status);

            if (todoListsFilterStatus == null || !todoListsFilterStatus.Any())
            {

                throw new ResourceNotFoundException("Não foram encontradas tarafas com status");
            }

            return todoListsFilterStatus;
        }

        public async Task<bool> AddNewTodo(TodoList todoList)
        {
            // if (string.IsNullOrWhiteSpace(todoList.Description))
            // {
            //     throw new BadRequestException("O nome da tarefa é obrigatório.");
            // }

            _todoListRepository.AddTodo(todoList);
            return await _todoListRepository.SaveChangeAsync();
        }

        public async Task<bool> UpdateExistingTodo(int id, TodoList todoList)
        {
            var todoDatabase = await _todoListRepository.GeByIdTodo(id);
            if (todoDatabase != null)
            {
                todoDatabase.Description = todoList.Description ?? todoDatabase.Description;
                todoDatabase.TodoStatus = todoList.TodoStatus != new Status() ? todoList.TodoStatus : todoDatabase.TodoStatus;

                _todoListRepository.UpdateTodo(todoDatabase);

                return await _todoListRepository.SaveChangeAsync();
            }

            throw new ResourceNotFoundException("Tarefa não encontrada!");


        }
        public async Task<bool> DeleteTodoById(int id)
        {
            var todoDatabase = await _todoListRepository.GeByIdTodo(id);

            if (todoDatabase != null)
            {
                _todoListRepository.DeleteTodo(todoDatabase);
                return await _todoListRepository.SaveChangeAsync();
            }

            throw new ResourceNotFoundException("Tarefa não encontrada!");

        }

        // public string GetStatusAsString(Status status)
        // {
        //     return status.ToStatusString();
        // }

    }
}