using System.ComponentModel.DataAnnotations;

namespace Gerenciador.Communication.Requests.Task;

public class RequestRegisterTaskJson
{
    [Required]
    [StringLength(100,MinimumLength = 3,ErrorMessage = "Deve ter entre 3 e 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Deve ter no maximo 500 caracteres.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string Priority { get; set; } = string.Empty;

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;
}
