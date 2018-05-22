using ToDoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using ToDoApi.Enums;
using Microsoft.AspNetCore.Http;

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

        [HttpPost]
        public IActionResult Create([FromBody] ToDoItem item)
        {
            if (item == null || !ModelState.IsValid)
                return BadRequest(ErrorCodeEnum.TodoItemNameAndDescriptionRequired.ToString());

            try
            {
                if (_toDoRepository.DoesItemExist(item.Id))
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCodeEnum.TodoItemIdInUse.ToString());

                _toDoRepository.Insert(item);
            }
            catch (System.Exception ex)
            {
                // TODO add logger
                return BadRequest(ErrorCodeEnum.CouldNotCreateItem.ToString());
            }

            return Ok(item);
        }

        [HttpPut]
        public IActionResult Modify([FromBody] ToDoItem item)
        {
            if (item == null || !ModelState.IsValid)
                return BadRequest(ErrorCodeEnum.TodoItemNameAndDescriptionRequired.ToString());

            try
            {
                var foundItem = _toDoRepository.Find(item.Id);

                if (foundItem == null)
                    return NotFound(ErrorCodeEnum.RecordNotFound.ToString());

                _toDoRepository.Update(item);
            }
            catch (System.Exception ex)
            {
                // TODO add logger
                return BadRequest(ErrorCodeEnum.CouldNotUpdateItem.ToString());
            }

            return NoContent();
        }
    }
}
