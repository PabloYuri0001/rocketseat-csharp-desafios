using Gerenciador.Aplication.Entity;
using Gerenciador.Aplication.Repositories;
using Gerenciador.Aplication.Results;
using Gerenciador.Communication.Enums;
using Gerenciador.Communication.Requests.Task;
using Gerenciador.Communication.Responses.Errors;
using Gerenciador.Communication.Responses.Task;


namespace Gerenciador.Aplication.UseCases.Taks.Register;

public class RegisterTaskUseCase
{
    private readonly TaskRepository repository;

    public RegisterTaskUseCase(TaskRepository repository)
    {
        this.repository = repository;
    }

    public ServiceResult<ResponseTaskJson> Execute(RequestRegisterTaskJson request)
    {
        var errors = new ResponseErrorsJson();

        if (request.DueDate < DateTime.Now)
        {
            errors.Errors.Add("A data limite não pode ser anterior à data atual.");
        }

        if (!Enum.TryParse<EnumPriority>(request.Priority,true, out var priority) || !Enum.IsDefined(typeof(EnumPriority), priority))
        {
            errors.Errors.Add("A prioridade informada é inválida.");
        }

        if (!Enum.TryParse<EnumStatus>(request.Status, true, out var status) || !Enum.IsDefined(typeof(EnumStatus), status))
        {
            errors.Errors.Add("O status informado é inválido.");
        }

        if (errors.Errors.Count > 0)
        {
            return new ServiceResult<ResponseTaskJson>
            {
                IsSuccess = false,
                Errors = errors
            };
        }

        var task = new TaskBase
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            Status = request.Status,
        };

        repository.Tasks.Add(task);

        return new ServiceResult<ResponseTaskJson>
        {
            IsSuccess = true,
            Data = new ResponseTaskJson
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Priority = task.Priority,
                DueDate = task.DueDate,
                Status = task.Status
            }
        };

    }
}
