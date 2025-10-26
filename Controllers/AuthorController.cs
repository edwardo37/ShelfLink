using Microsoft.AspNetCore.Mvc;
using ShelfLink.DTOs;
using ShelfLink.Models;
using ShelfLink.Services;

namespace ShelfLink.Controllers
{
    /// <summary>
    /// Basic author controller
    /// </summary>
    [ApiController]
    [Route("api/author")]
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{id}")]
        public AuthorResponse? GetAuthorById(int id)
        {
            return _authorService.GetById(id);
        }

        [HttpPost("search")]
        public List<AuthorResponse> GetAuthorByFilterPaged(
            [FromBody] AuthorFilterRequest authorFilter,
            [FromQuery] int page, [FromQuery] int pageSize=20)
        {
            return _authorService.GetByFilterPaged(authorFilter, page, pageSize);
        }

        [HttpPost]
        public AuthorResponse CreateAuthor([FromBody] AuthorCreateRequest authorCreate)
        {
            return _authorService.Create(authorCreate);
        }

        [HttpPatch("{id}")]
        public AuthorResponse UpdateAuthor(int id, [FromBody] AuthorUpdateRequest authorUpdate)
        {
            return _authorService.Update(id, authorUpdate);
        }

        [HttpPut("{id}")]
        public AuthorResponse ReplaceAuthor(int id, [FromBody] AuthorCreateRequest authorCreate)
        {
            return _authorService.Overwrite(id, authorCreate);
        }

        [HttpDelete("{id}")]
        public bool DeleteAuthor(int id)
        {
            _authorService.Delete(id);

            return true;
        }
    }
}
