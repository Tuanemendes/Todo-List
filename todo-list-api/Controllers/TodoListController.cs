using Microsoft.AspNetCore.Mvc;
using todo_list_api.Data.Repository;
using todo_list_api.Model;

namespace todo_list_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListController(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todoLists = await _todoListRepository.GetAllTodo();
            return todoLists.Any()
                    ? Ok(todoLists)
                    : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoListRepository.GeByIdTodo(id);

            return todo != null
                    ? Ok(todo)
                    : NotFound("Tarefa não encontrada!");
        }
        [HttpPost]
        public async Task<IActionResult> Post(TodoList todoList)
        {
            _todoListRepository.AddTodo(todoList);
            return await _todoListRepository.SaveChangeAsync()
                ? Ok("Tarefa adicionada com sucesso!")
                : BadRequest("Erro ao salvar a tarefa");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutById(int id, TodoList todoList)
        {
            var todoDatabase = await _todoListRepository.GeByIdTodo(id);

            if (todoDatabase == null) return NotFound("Tarefa não encontrada!");

            todoDatabase.Description = todoList.Description ?? todoDatabase.Description;
            todoDatabase.TodoStatus = todoList.TodoStatus != new Status() ? todoList.TodoStatus : todoDatabase.TodoStatus;

            _todoListRepository.UpdateTodo(todoDatabase);

            return await _todoListRepository.SaveChangeAsync()
               ? Ok("Tarefa atualizada com sucesso!")
               : BadRequest("Erro ao Atualizar a tarefa");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var todoDatabase = await _todoListRepository.GeByIdTodo(id);

            if (todoDatabase == null) return NotFound("Tarefa não encontrada!");

            _todoListRepository .DeleteTodo(todoDatabase);

            return await _todoListRepository.SaveChangeAsync()
               ? Ok("Tarefa excluída com sucesso!")
               : BadRequest("Erro ao deletar a tarefa");
        }

    }
}