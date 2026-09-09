using Gerenciador.Aplication.Repositories;
using Gerenciador.Aplication.Results;
using Gerenciador.Communication.Responses.Errors;
using Gerenciador.Communication.Responses.Task;

namespace Gerenciador.Aplication.UseCases.Taks.GetAll;

public class GetAllTaskUseCase
{
    private readonly TaskRepository repository;

    public GetAllTaskUseCase(TaskRepository repository)
    {
        this.repository = repository;
    }

    public ServiceResult<ResponseAllTaskJson> Execute()
    {
        var errors = new ResponseErrorsJson();

        if(repository.Tasks.Count == 0)
        {
            errors.Errors.Add("Não Tarefas registradas no momento");
        }

        if(errors.Errors.Count > 0)
        {
            return new ServiceResult<ResponseAllTaskJson>
            {
                IsSuccess = false,
                Errors = errors
            };
        }

        var dataList = repository.Tasks.Select(task => new ResponseShortTaskJson
        {
            Id = task.Id,
            Name = task.Name,
            DueDate = task.DueDate,
            Priority = task.Priority,
            Status = task.Status,

        }).ToList();


        return new ServiceResult<ResponseAllTaskJson>
        {
            IsSuccess = true,
            Data = new ResponseAllTaskJson
            {
                Tasks = dataList
            }
        };

        
    }
}
