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
        public async Task<IActionResult> Get(){
            var todoLists = await _todoListRepository.GetAllTodo();
            return todoLists.Any() ? Ok(todoLists) : NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoList todoList)
        {
            _todoListRepository.AddTodo(todoList);
            return await _todoListRepository.SaveChangeAsync() ? Ok ("Tarefa adicionada com sucesso!") : BadRequest("Erro ao salvar a tarefa");
        }
    }
}