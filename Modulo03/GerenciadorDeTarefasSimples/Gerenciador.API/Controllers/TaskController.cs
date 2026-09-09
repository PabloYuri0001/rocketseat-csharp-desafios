using Gerenciador.Aplication.UseCases.Taks.Delete;
using Gerenciador.Aplication.UseCases.Taks.GetAll;
using Gerenciador.Aplication.UseCases.Taks.GetById;
using Gerenciador.Aplication.UseCases.Taks.Register;
using Gerenciador.Aplication.UseCases.Taks.Update;
using Gerenciador.Communication.Requests.Task;
using Gerenciador.Communication.Responses.Errors;
using Gerenciador.Communication.Responses.Task;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciador.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly RegisterTaskUseCase registerTaskUseCase;
    private readonly GetAllTaskUseCase getAllTaskUseCase;
    private readonly GetByIdUseCase getByIdUseCase;
    private readonly UpdateTaskUseCase updateTaskUseCase;
    private readonly DeleteTaskUseCase deleteTaskUseCase;

    public TaskController(
            RegisterTaskUseCase registerTaskUseCase,
            GetAllTaskUseCase getAllTaskUseCase,
            GetByIdUseCase getByIdUseCase,
            UpdateTaskUseCase updateTaskUseCase,
            DeleteTaskUseCase deleteTaskUseCase
         )
    {
        this.registerTaskUseCase = registerTaskUseCase;
        this.getAllTaskUseCase = getAllTaskUseCase;
        this.getByIdUseCase = getByIdUseCase;
        this.updateTaskUseCase = updateTaskUseCase;
        this.deleteTaskUseCase = deleteTaskUseCase;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult CreateTask(RequestRegisterTaskJson request)
    {
        var result = registerTaskUseCase.Execute(request);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Errors);
        }

        return Created(string.Empty, result.Data);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status204NoContent)]
    public IActionResult GetAllTasks()
    {
        var result = getAllTaskUseCase.Execute();

        if (!result.IsSuccess)
        {
            return NoContent();
        }

        return Ok(result.Data);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseAllTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetAllTasks(Guid id)
    {
        var result = getByIdUseCase.Execute(id);

        if (!result.IsSuccess)
        {
            return StatusCode(result.StatusCode.Value, result.Errors);
        }

        return Ok(result.Data);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult UpdateTask(Guid id, RequestUpdateTaskJson request)
    {
        var result = updateTaskUseCase.Execute(id,request);

        if (!result.IsSuccess)
        {
            return StatusCode(result.StatusCode.Value, result.Errors);
        }

        return Ok(result.Data);
    }


    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult DeleteTask(Guid id)
    {
        var result = deleteTaskUseCase.Execute(id);

        if (!result.IsSuccess)
        {
            return StatusCode(result.StatusCode.Value, result.Errors);
        }

        return NoContent();
    }


}
