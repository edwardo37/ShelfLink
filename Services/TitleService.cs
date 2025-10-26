using ShelfLink.Repositories;
using ShelfLink.Models;
using ShelfLink.DTOs;
using Microsoft.EntityFrameworkCore;

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
            Title? title = _titleRepo.Query().Include(t => t.Authors).FirstOrDefault(t => t.TitleId == id);

            if (title == null)
            {
                throw new KeyNotFoundException("Could not find the title specified");
            }

            return new TitleResponse
            {
                TitleId = title.TitleId,
                Name = title.Name,
                Description = title.Description,
                ISBN = title.ISBN,
                PublishDate = title.PublishDate,
                Authors = title.Authors.Select(a => new AuthorResponse
                {
                    TitleAuthorId = a.TitleAuthorId,
                    Name = a.Name
                }).ToList(),
                Publisher = title.Publisher?.Name ?? "",
                Genre = title.Genre?.Name ?? "",
                CategoryName = title.CategoryName
            };
        }

        /// <summary>
        /// Get a list of titles using a filter with optional properties, paged
        /// </summary>
        /// <param name="titleFilter">The filter to apply. Null properties will be ignored</param>
        /// <param name="page">The page to skip to</param>
        /// <param name="pageSize">The size of each page</param>
        /// <returns></returns>
        public List<TitleResponse> GetByFilterPaged(TitleFilterRequest titleFilter, int page, int pageSize)
        {
            var query = _titleRepo.Query();

            // Basic queries
            query = query
                .Where(title => title.Name.Contains(titleFilter.Name ?? ""))
                .Where(title => title.ISBN != null && title.ISBN.Contains(titleFilter.ISBN ?? ""))
            // Nav properties
                .Include(title => title.Publisher)
                .Include(title => title.Genre)
                .Include(title => title.Category)
                .Where(title => titleFilter.PublisherName == null || title.Publisher != null && title.Publisher.Name.Contains(titleFilter.PublisherName))
                .Where(title => titleFilter.GenreName == null || title.Genre != null && title.Genre.Name.Contains(titleFilter.GenreName))
                .Where(title => titleFilter.CategoryName == null || title.Category != null && title.Category.Name.Contains(titleFilter.CategoryName));

            if (titleFilter.PublishYear > 0)
            {
                query = query.Where(title => title.PublishDate.Year % titleFilter.PublishYear == 0);
            }

            if (titleFilter.AuthorIds.Count > 0)
            {
                query = query
                    .Include(title => title.Authors)
                    .Where(title => title.Authors.Any(author => titleFilter.AuthorIds.Contains(author.TitleAuthorId)));
            }

            List<Title> titleList = query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            List<TitleResponse> responses = new List<TitleResponse>();


            foreach (var title in titleList)
            {
                TitleResponse response = new TitleResponse();

                response.Authors = title.Authors.Select(a => new AuthorResponse
                {
                    TitleAuthorId = a.TitleAuthorId,
                    Name = a.Name
                }).ToList();

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

        /// <summary>
        /// Create a new title in the repository
        /// </summary>
        /// <param name="titleCreateRequest">The title to create</param>
        /// <returns>A response object of the title</returns>
        /// <exception cref="KeyNotFoundException">One of the authorIds specified could not be found</exception>
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

            foreach (int authorId in titleCreateRequest.AuthorIds)
            {
                TitleAuthor? authorToAdd = _authorRepo.GetById(authorId);

                if (authorToAdd == null)
                {
                    throw new KeyNotFoundException($"The author with Id {authorId} to append to the title could not be found");
                }

                newTitle.Authors.Add(authorToAdd);
            }

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

        /// <summary>
        /// Update the title specified by it's Id. Null properties will be ignored
        /// </summary>
        /// <param name="id">The Id of the title to update</param>
        /// <param name="titleUpdateRequest">The updated object request</param>
        /// <returns>A response of the newly-updated title</returns>
        /// <exception cref="KeyNotFoundException">The Title to update or replacement author Ids could not be found</exception>
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

            if (titleUpdateRequest.AuthorIds != null)
            {
                foreach (int authorId in titleUpdateRequest.AuthorIds)
                {
                    TitleAuthor? authorToAdd = _authorRepo.GetById(authorId);

                    if (authorToAdd == null)
                    {
                        throw new KeyNotFoundException($"The author with Id {authorId} to append to the title could not be found");
                    }

                    titleToUpdate.Authors.Add(authorToAdd);
                }
            }


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

                Authors = titleToUpdate.Authors.Select(a => new AuthorResponse
                {
                    TitleAuthorId = a.TitleAuthorId,
                    Name = a.Name
                }).ToList()
            };
        }

        /// <summary>
        /// Overwrite an existing Title in the repo. All properties will be overwritten
        /// </summary>
        /// <param name="id">The Id of the title to overwrite</param>
        /// <param name="titleReplacement">The create request object to overwrite with</param>
        /// <returns>A response reflecting the new title</returns>
        /// <exception cref="KeyNotFoundException">The Id of the title could not be found</exception>
        public TitleResponse Overwrite(int id, TitleCreateRequest titleReplacement)
        {
            Title? titleToOverwrite = _titleRepo.GetById(id);

            if (titleToOverwrite == null)
            {
                throw new KeyNotFoundException("The title to overwrite could not be found.");
            }

            titleToOverwrite.Name = titleReplacement.Name;
            titleToOverwrite.Description = titleReplacement.Description;
            titleToOverwrite.ISBN = titleReplacement.Description;
            titleToOverwrite.PublishDate = titleReplacement.PublishDate;
            titleToOverwrite.PublisherName = titleReplacement.PublisherName;
            titleToOverwrite.GenreName = titleReplacement.GenreName;
            titleToOverwrite.CategoryName = titleReplacement.CategoryName;

            _titleRepo.SaveChanges();

            return new TitleResponse
            {
                TitleId = titleToOverwrite.TitleId,
                Name = titleToOverwrite.Name,
                Description = titleToOverwrite.Description,
                ISBN = titleToOverwrite.ISBN,
                PublishDate = titleToOverwrite.PublishDate,
                Publisher = titleToOverwrite.PublisherName,
                Genre = titleToOverwrite.GenreName,
                CategoryName = titleToOverwrite.CategoryName,

                Authors = titleToOverwrite.Authors.Select(a => new AuthorResponse
                {
                    TitleAuthorId = a.TitleAuthorId,
                    Name = a.Name
                }).ToList()
            };
        }

        /// <summary>
        /// Delete a title in the repository
        /// </summary>
        /// <param name="id">The Id of the Title to delete</param>
        /// <exception cref="KeyNotFoundException">The Id of the title could not be found</exception>
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
