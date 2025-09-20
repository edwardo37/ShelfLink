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
                Id = 1,
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
                Id = 2,
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

        [HttpGet("{id}", Name = "TitleById")]
        public Title? GetTitleById(int id)
        {
            return TITLES.FirstOrDefault(t => t.Id == id);
        }

        [HttpPost("", Name = "CreateTitle")]
        public Title CreateTitle([FromBody] Title newTitle)
        {
            newTitle.Id = TITLES.Count + 1;
            TITLES.Add(newTitle);
            return newTitle;
        }

        [HttpPut("{id}", Name = "UpdateTitle")]
        public Title? UpdateTitle(int id, [FromBody] Title updatedTitle)
        {
            var existingTitle = TITLES.FirstOrDefault(t => t.Id == id);
            if (existingTitle == null)
            {
                return null;
            }
            existingTitle.Name = updatedTitle.Name;
            existingTitle.ISBN = updatedTitle.ISBN;
            existingTitle.PublishDate = updatedTitle.PublishDate;
            existingTitle.Publisher = updatedTitle.Publisher;
            existingTitle.Author = updatedTitle.Author;
            existingTitle.Category = updatedTitle.Category;
            existingTitle.Genre = updatedTitle.Genre;
            return existingTitle;
        }

        [HttpDelete("{id}", Name = "DeleteTitle")]
        public bool DeleteTitle(int id)
        {
            var titleToRemove = TITLES.FirstOrDefault(t => t.Id == id);
            if (titleToRemove == null)
            {
                return false;
            }
            TITLES.Remove(titleToRemove);
            return true;
        }
    }
}
