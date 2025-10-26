using ShelfLink.Repositories;
using ShelfLink.Models;
using ShelfLink.DTOs;

namespace ShelfLink.Services
{
    public class TitleService
    {
        private readonly IShelfLinkRepository<Title> _titleRepo;
        private readonly IShelfLinkRepository<TitleAuthor> _authorRepo;

        public TitleService(IShelfLinkRepository<Title> titleRepo, IShelfLinkRepository<TitleAuthor> authorRepo)
        {
            _titleRepo = titleRepo;
            _authorRepo = authorRepo;
        }


        /// <summary>
        /// Get a title by its Id
        /// </summary>
        /// <param name="id">The Id of the title to fetch</param>
        /// <returns>The title response. Exception if not found.</returns>
        /// <exception cref="KeyNotFoundException">The title was not found in the database.</exception>
        public TitleResponse? GetById(int id)
        {
            Title? title = _titleRepo.GetById(id);

            if (title == null)
            {
                throw new KeyNotFoundException("Could not find the title specified");
            }

            TitleResponse response = new()
            {
                TitleId = title.TitleId,
                Name = title.Name,
                Description = title.Description,
                ISBN = title.ISBN,
                PublishDate = title.PublishDate,
                Publisher = title.Publisher?.Name ?? "",
                Genre = title.Genre?.Name ?? "",
                CategoryName = title.CategoryName
            };

            response.AuthorIds = title.Authors?.Select(author => author.TitleAuthorId).ToList();
            response.AuthorNames = title.Authors?.Select(author => author.Name).ToList();

            return response;
        }

        public List<TitleResponse> GetByFilterPaged(TitleFilterRequest titleFilter, int page, int pageSize)
        {
            var query = _titleRepo.Query();

            // Basic queries
            query = query
                .Where(title => title.Name.Contains(titleFilter.Name))
                .Where(title => (title.ISBN != null && title.ISBN.Contains(titleFilter.ISBN)))
                .Where(title => (title.Publisher != null && title.Publisher.Name == titleFilter.PublisherName))
                .Where(title => (title.Genre != null && title.Genre.Name == titleFilter.GenreName))
                .Where(title => title.Category != null && title.Category.Name.Contains(titleFilter.CategoryName ?? ""));


            if (titleFilter.AuthorIds.Count > 0)
            {
                query = query
                    .Where(title => title.Authors != null && title.Authors.Any(author => titleFilter.AuthorIds.Contains(author.TitleAuthorId)));
            }

            if (titleFilter.PublishYear != null)
            {
                query = query.Where(title => title.PublishDate.Year == titleFilter.PublishYear);
            }

            List<Title> titleList = query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            List<TitleResponse> responses = new List<TitleResponse>();

            // How do I map a list of models to a list of response objects
            foreach (var title in titleList)
            {
                TitleResponse response = new TitleResponse();

                response.AuthorIds = title.Authors?.Select(author => author.TitleAuthorId).ToList();
                response.AuthorNames = title.Authors?.Select(author => author.Name).ToList();

                // Map the rest of the data
                response.TitleId = title.TitleId;
                response.Name = title.Name;
                response.ISBN = title.ISBN;
                response.PublishDate = title.PublishDate;
                response.Publisher = title.Publisher?.Name ?? "";
                response.Genre = title.Genre?.Name ?? "";
                response.CategoryName = title.CategoryName;


                responses.Add(response);
            }

            return responses;
        }


        public TitleResponse Create(TitleCreateRequest titleCreateRequest)
        {
            Title newTitle = new()
            {
                Name = titleCreateRequest.Name,
                Description = titleCreateRequest.Description,
                ISBN = titleCreateRequest.ISBN,
                PublishDate = titleCreateRequest.PublishDate,
                PublisherName = titleCreateRequest.PublisherName,
                GenreName = titleCreateRequest.GenreName,
                CategoryName = titleCreateRequest.CategoryName
                
            };

            // TODO: Search for AuthorIds after service is created

            _titleRepo.Add(newTitle);

            _titleRepo.SaveChanges();

            return new TitleResponse
            {
                TitleId = newTitle.TitleId,
                Name = newTitle.Name,
                ISBN = newTitle.ISBN,
                PublishDate = newTitle.PublishDate,
                Publisher = newTitle.Publisher?.Name ?? "",
                Genre = newTitle.Genre?.Name ?? "",
                CategoryName = newTitle.CategoryName
            };
        }

        public TitleResponse Update(int id, TitleUpdateRequest titleUpdateRequest)
        {
            Title? titleToUpdate = _titleRepo.GetById(id);
            if (titleToUpdate == null)
            {
                throw new KeyNotFoundException("The title to update could not be found.");
            }

            if (titleUpdateRequest.Name != null)
            {
                titleToUpdate.Name = titleUpdateRequest.Name;
            }

            if (titleUpdateRequest.Description != null)
            {
                titleToUpdate.Description = titleUpdateRequest.Description;
            }

            if (titleUpdateRequest.ISBN != null)
            {
                titleToUpdate.ISBN = titleUpdateRequest.ISBN;
            }

            if (titleUpdateRequest.PublishDate.HasValue)
            { 
                titleToUpdate.PublishDate = titleUpdateRequest.PublishDate.Value;
            }

            // TODO: Add AuthorIds after service is made


            if (titleUpdateRequest.PublisherName != null)
            {
                // TODO: Add check if exists for this and below methods

                titleToUpdate.PublisherName = titleUpdateRequest.PublisherName;
            }

            if (titleUpdateRequest.GenreName != null)
            {
                titleToUpdate.GenreName = titleUpdateRequest.GenreName;
            }

            if (titleUpdateRequest.CategoryName != null)
            {
                titleToUpdate.CategoryName = titleUpdateRequest.CategoryName;
            }


            _titleRepo.SaveChanges();

            return new TitleResponse
            {
                Name = titleToUpdate.Name,
                Description = titleToUpdate.Description,
                ISBN = titleToUpdate.ISBN,
                PublishDate = titleToUpdate.PublishDate,
                Publisher = titleToUpdate.PublisherName,
                Genre = titleToUpdate.GenreName,
                CategoryName = titleToUpdate.CategoryName,
                // TODO: Add authors
                AuthorIds = titleToUpdate.Authors?.Select(a => a.TitleAuthorId).ToList(),
                AuthorNames = titleToUpdate.Authors?.Select(a => a.Name).ToList()
            };
        }

        public void Delete(int id)
        {
            Title? titleToDelete = _titleRepo.GetById(id);
            if (titleToDelete == null)
            {
                throw new KeyNotFoundException("The title to delete could not be found.");
            }

            _titleRepo.Delete(titleToDelete);

            _titleRepo.SaveChanges();
        }
    }
}
