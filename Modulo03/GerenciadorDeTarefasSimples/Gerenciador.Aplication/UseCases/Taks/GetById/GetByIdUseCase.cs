using Gerenciador.Aplication.Repositories;
using Gerenciador.Aplication.Results;
using Gerenciador.Communication.Responses.Errors;
using Gerenciador.Communication.Responses.Task;


namespace Gerenciador.Aplication.UseCases.Taks.GetById;

public class GetByIdUseCase
{
    private readonly TaskRepository repository;

    public GetByIdUseCase(TaskRepository repository)
    {
        this.repository = repository;
    }

    public ServiceResult<ResponseTaskJson> Execute(Guid id)
    {
        var errors = new ResponseErrorsJson();

        if(id == Guid.Empty)
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

        if(data == null)
        {
            errors.Errors.Add("Não foi possivel encontrar a tarefa");
        }

        if(errors.Errors.Count > 0)
        {
            return new ServiceResult<ResponseTaskJson>
            {
                IsSuccess = false,
                Errors = errors,
                StatusCode = 404
            };
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
            Data = task
        };
    }

}
