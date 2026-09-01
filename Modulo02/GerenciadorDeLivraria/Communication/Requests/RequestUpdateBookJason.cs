using System.ComponentModel.DataAnnotations;
namespace GerenciadorDeLivraria.Communication.Requests;

public class RequestUpdateBookJason
{
    [StringLength(120, MinimumLength = 2, ErrorMessage = "Deve ter entre 2 e 120 caracteres.")]
    public string? Title { get; set; }

    [StringLength(120, MinimumLength = 2, ErrorMessage = "Deve ter entre 2 e 120 caracteres.")]
    public string? Author { get; set; }
    public string? Genre { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? Price { get; set; }

    [Range(0, int.MaxValue)]
    public int? Stock { get; set; }
}
