using Microsoft.AspNetCore.Mvc;
using todo_list_api.Exceptions;
using todo_list_api.Model;
using todo_list_api.Service;

namespace todo_list_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoListController : ControllerBase
    {

        protected readonly ITodoListService _itodoListService;

        public TodoListController(ITodoListService itodoListService)
        {
            _itodoListService = itodoListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todoLists = await _itodoListService.GetAllTodos();
            return Ok(todoLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todoId = await _itodoListService.GetTodoById(id);
            return Ok(todoId);
        }

        [HttpGet("filter/{status}")]
        public async Task<IActionResult> GetByFilterStatus(Status status){

            var todoFilterStatus = await _itodoListService.GetByStatus(status);
            return Ok(todoFilterStatus);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TodoList todoList)
        {
            var newTodoList = await _itodoListService.AddNewTodo(todoList);
            return newTodoList
                ? CreatedAtAction(nameof(GetById), new {id= todoList.Id},"Tarefa adicionada com sucesso!")
                : throw new BadRequestException("Erro ao salvar a tarefa");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutById(int id, TodoList todoList)
        {
            var updateTodo =  await _itodoListService.UpdateExistingTodo(id,todoList);
            return updateTodo
               ? Ok("Tarefa atualizada com sucesso!")
               : throw new BadRequestException("Erro ao atualizar a tarefa");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var deleteTodo = await _itodoListService.DeleteTodoById(id);
            return deleteTodo
               ? Ok("Tarefa excluída com sucesso!")
               : throw new BadRequestException("Erro ao deletar a tarefa");
        }

    }
}