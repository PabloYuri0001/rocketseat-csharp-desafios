using Gerenciador.Communication.Responses.Errors;

namespace Gerenciador.Aplication.Results;

public class ServiceResult<T>
{
    public T? Data { get; set; }
    public ResponseErrorsJson? Errors { get; set; }

    public bool IsSuccess { get; set; }
    public int? StatusCode { get; set; }

}
