using GerenciadorDeLivraria.Communication.Requests;
using GerenciadorDeLivraria.Communication.Responses;
using GerenciadorDeLivraria.Entity;
using GerenciadorDeLivraria.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeLivraria.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private static List<Book> books = new();

    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAllBook()
    {
        return Ok(books);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(Guid id)
    {
        if(id == Guid.Empty)
        {
            return BadRequest("O Id é obrigatorio");
        }

        var book = books.FirstOrDefault(bookA =>  bookA.Id == id);

        if(book == null)
        {
            return NotFound("Livro não encontrado.");
        }

        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateBook([FromBody] RequestRegisterBookJson book)
    {
        if (!Enum.TryParse<GenreEnum>(book.Genre, true, out var genre) || !Enum.IsDefined(typeof(GenreEnum),genre))
        {
            return BadRequest("Gênero inválido.");

        }

        foreach (var item in books)
        {
            if(item.Title.Equals(book.Title) && item.Author.Equals(book.Author))
            {

                return Conflict("Esse livro já existe no sistema");
                
            }
        }

        var novoBook = new Book()
        {
            Id = Guid.NewGuid(),
            Title = book.Title,
            Author = book.Author,
            Genre = book.Genre,
            Price = book.Price,
            Stock = book.Stock,
            CreatedAt = DateTime.Now
        };

        books.Add(novoBook);

        var response = new ResponseRegisterBookJson()
        {
            Id = novoBook.Id,
            Title = novoBook.Title,
            Author = novoBook.Author,
            Genre = novoBook.Genre,
            Price = novoBook.Price,
            Stock = novoBook.Stock,
            CreatedAt = novoBook.CreatedAt
        };

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(Book),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public IActionResult UpdateBook(Guid id, [FromBody] RequestUpdateBookJason request)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("O Id é obrigatorio");
        }

        if (!Enum.TryParse<GenreEnum>(request.Genre, true, out var genre) || !Enum.IsDefined(typeof(GenreEnum), genre))
        {
            return BadRequest("Gênero inválido.");

        }

        var book = books.FirstOrDefault(bookA => bookA.Id == id);

        if (book == null)
        {
            return NotFound("Livro não encontrado.");
        }

        if(request.Title != null)
        {
            book.Title = request.Title;
        }

        if(request.Author != null)
        {
            book.Author = request.Author;
        }

        if (request.Genre != null)
        {
            book.Genre = request.Genre;
        }

        if(request.Price != null)
        {
            book.Price = request.Price.Value;
        }

        if(request.Stock != null)
        {
            book.Stock = request.Stock.Value;
        }

        book.UpdatedAt = DateTime.Now;

        return Ok(book);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteById(Guid id)
    {
        if (id == Guid.Empty)
        {
            return BadRequest("O Id é obrigatorio");
        }

        var book = books.FirstOrDefault(bookA => bookA.Id == id);

        if (book == null)
        {
            return NotFound("Livro não encontrado.");
        }

        books.Remove(book);

        return NoContent();

    }


}
