using Gerenciador.Aplication.Repositories;
using Gerenciador.Aplication.Results;
using Gerenciador.Communication.Responses.Errors;

namespace Gerenciador.Aplication.UseCases.Taks.Delete;

public class DeleteTaskUseCase
{
    private readonly TaskRepository repository;

    public DeleteTaskUseCase(TaskRepository repository)
    {
        this.repository = repository;
    }

    public ServiceResult<object> Execute(Guid id)
    {
        var errors = new ResponseErrorsJson();

        if (id == Guid.Empty)
        {
            errors.Errors.Add("O Id é obrigatorio");
        }

        if (errors.Errors.Count > 0)
        {
            return new ServiceResult<object>
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
            return new ServiceResult<object>
            {
                IsSuccess = false,
                Errors = errors,
                StatusCode = 404
            };
        }

        repository.Tasks.Remove(data);

        return new ServiceResult<object>
        {

            IsSuccess = true
        };

    }
}
