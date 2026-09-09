using Gerenciador.Aplication.Repositories;
using Gerenciador.Aplication.Results;
using Gerenciador.Communication.Enums;
using Gerenciador.Communication.Requests.Task;
using Gerenciador.Communication.Responses.Errors;
using Gerenciador.Communication.Responses.Task;

namespace Gerenciador.Aplication.UseCases.Taks.Update;

public class UpdateTaskUseCase
{
    private readonly TaskRepository repository;

    public UpdateTaskUseCase(TaskRepository repository)
    {
        this.repository = repository;
    }

    public ServiceResult<ResponseTaskJson> Execute(Guid id, RequestUpdateTaskJson request)
    {
        var errors = new ResponseErrorsJson();

        if (id == Guid.Empty)
        {
            errors.Errors.Add("O Id é obrigatorio");
        }

        if (errors.Errors.Count > 0)
        {
            return new ServiceResult<ResponseTaskJson>
            {
                IsSuccess = false,
                Errors = errors,
                StatusCode = 400
            };
        }

        var data = repository.Tasks.FirstOrDefault(t => t.Id == id);

        if (data == null)
        {
            errors.Errors.Add("Não foi possivel encontrar a tarefa");
        }

        if (errors.Errors.Count > 0)
        {
            return new ServiceResult<ResponseTaskJson>
            {
                IsSuccess = false,
                Errors = errors,
                StatusCode = 404
            };
        }

        if (request.DueDate != null && request.DueDate < DateTime.Now)
        {
            errors.Errors.Add("A data limite não pode ser anterior à data atual.");
        }

        if (request.Priority != null && (!Enum.TryParse<EnumPriority>(request.Priority, true, out var priority) || !Enum.IsDefined(typeof(EnumPriority), priority)))
        {
            errors.Errors.Add("A prioridade informada é inválida.");
        }

        if (request.Status != null && (!Enum.TryParse<EnumStatus>(request.Status, true, out var status) || !Enum.IsDefined(typeof(EnumStatus), status)))
        {
            errors.Errors.Add("O status informado é inválido.");
        }

        if (errors.Errors.Count > 0)
        {
            return new ServiceResult<ResponseTaskJson>
            {
                IsSuccess = false,
                Errors = errors,
                StatusCode = 400
            };
        }

        if(request.Name != null)
        {
            data.Name = request.Name;
        }

        if (request.Description != null)
        {
            data.Description = request.Description;
        }

        if (request.DueDate != null)
        {
            data.DueDate = request.DueDate.Value;
        }

        if (request.Priority != null)
        {
            data.Priority = request.Priority;
        }

        if (request.Status != null)
        {
            data.Status = request.Status;
        }

        var task = new ResponseTaskJson
        {
            Id = data.Id,
            Name = data.Name,
            Description = data.Description,
            DueDate = data.DueDate,
            Priority = data.Priority,
            Status = data.Status,

        };

        return new ServiceResult<ResponseTaskJson>
        {
            IsSuccess = true,
            Data = task,
        };

    }
}
