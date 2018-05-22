using ToDoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoItemsController(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        [HttpGet]
        public IActionResult List() => Ok(_toDoRepository.All);
    }
}
