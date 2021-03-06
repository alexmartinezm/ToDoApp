﻿using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Classes;
using ToDoApi.Enums;
using ToDoApi.Services.Interfaces;

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
            catch (Exception)
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
            catch (Exception)
            {
                // TODO add logger
                return BadRequest(ErrorCodeEnum.CouldNotUpdateItem.ToString());
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] string id)
        {
            try
            {
                var item = _toDoRepository.Find(id);

                if (item == null)
                    return NotFound(ErrorCodeEnum.RecordNotFound.ToString());

                _toDoRepository.Delete(id);
            }
            catch (Exception)
            {
                // TODO add logger
                return BadRequest(ErrorCodeEnum.CouldNotDeleteItem.ToString());
            }

            return NoContent();
        }
    }
}
