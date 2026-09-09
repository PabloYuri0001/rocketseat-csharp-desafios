using System.ComponentModel.DataAnnotations;

namespace Gerenciador.Communication.Requests.Task;

public class RequestUpdateTaskJson
{
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Deve ter entre 3 e 100 caracteres.")]
    public string? Name { get; set; }

    [StringLength(500, ErrorMessage = "Deve ter no maximo 500 caracteres.")]
    public string? Description { get; set; }

    public string? Priority { get; set; }
    public DateTime? DueDate { get; set; }

    public string? Status { get; set; }
}
