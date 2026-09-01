namespace GerenciadorDeLivraria.Communication.Requests;
using System.ComponentModel.DataAnnotations;

public class RequestRegisterBookJson
{
    [Required(ErrorMessage = " O Titulo é obrigatório. ")]
    [StringLength(120,MinimumLength = 2, ErrorMessage = "Deve ter entre 2 e 120 caracteres.")]    
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = " O Author é obrigatório. ")]
    [StringLength(120, MinimumLength = 2, ErrorMessage = "Deve ter entre 2 e 120 caracteres.")]
    public string Author { get; set; } = string.Empty;

    [Required(ErrorMessage = " O Genre é obrigatório. ")]
    public string Genre { get; set; } = string.Empty;

    [Required(ErrorMessage = " O Price é obrigatório. ")]
    [Range(0,double.MaxValue)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = " O Stock é obrigatório. ")]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

}
