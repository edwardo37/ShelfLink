using Microsoft.AspNetCore.Mvc;
using ShelfLink.Models;

namespace ShelfLink.Controllers
{
    [ApiController]
    [Route("/title")]
    public class TitleController : Controller
    {
        List<Title> TITLES = new List<Title>
        {
            new Title
            {
                Name = "The Great Gatsby",
                ISBN = "9780743273565",
                PublishDate = new DateOnly(1925, 4, 10),
                Publisher = new TitlePublisher { Id = 1, Name = "Scribner" },
                Author = new TitleAuthor { Id = 1, Name = "F. Scott Fitzgerald" },
                Category = new TitleCategory { Id = 1, Name = "Book" },
                Genre = new TitleGenre { Id = 1, Name = "Fiction" },
            },
            new Title
            {
                Name = "To Kill a Mockingbird",
                ISBN = "9780061120084",
                PublishDate = new DateOnly(1960, 7, 11),
                Publisher = new TitlePublisher { Id = 2, Name = "J.B. Lippincott & Co." },
                Author = new TitleAuthor { Id = 2, Name = "Harper Lee" },
                Category = new TitleCategory { Id = 1, Name = "Book" },
                Genre = new TitleGenre { Id = 1, Name = "Fiction" },
            }
        };

        [HttpGet("", Name = "Titles")]
        public List<Title> GetTitles()
        {
            return TITLES;
        }
    }
}
