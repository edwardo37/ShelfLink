using ShelfLink.DTOs;
using ShelfLink.Models;
using ShelfLink.Repositories;

namespace ShelfLink.Services
{
    /// <summary>
    /// A very simple author service. It seems redundant but easier to work with in other services, plus if other features like aliases get added later
    /// </summary>
    public class AuthorService
    {
        private readonly IShelfLinkRepository<TitleAuthor> _authorRepo;

        public AuthorService(
            IShelfLinkRepository<TitleAuthor> authorRepo)
        {
            _authorRepo = authorRepo;
        }

        /// <summary>
        /// Get an author by its Id
        /// </summary>
        /// <param name="id">The Id of the author to fetch</param>
        /// <returns>An author response object</returns>
        /// <exception cref="KeyNotFoundException">The Id could not be found</exception>
        public AuthorResponse GetById(int id)
        {
            TitleAuthor? authorToGet = _authorRepo.GetById(id);

            if (authorToGet == null)
            {
                throw new KeyNotFoundException("The key of the author could not be found.");
            }

            return new AuthorResponse
            {
                TitleAuthorId = authorToGet.TitleAuthorId,
                Name = authorToGet.Name
            };
        }

        /// <summary>
        /// Get a list of author responses, by a filter, paged
        /// </summary>
        /// <param name="authorFilter">The filter object of the author</param>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">The size of each page</param>
        /// <returns>A list of author response objects, empty if none</returns>
        public List<AuthorResponse> GetByFilterPaged(AuthorFilterRequest authorFilter, int page, int pageSize)
        {
            var query = _authorRepo.Query()
                .Where(author => author.Name.Contains(authorFilter.Name ?? ""));

            List<TitleAuthor> authorList = query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();

            List<AuthorResponse> responses = new List<AuthorResponse>();

            foreach (var author in authorList)
            {
                AuthorResponse response = new AuthorResponse
                {
                    TitleAuthorId = author.TitleAuthorId,
                    Name = author.Name
                };

                responses.Add(response);
            }

            return responses;
        }

        /// <summary>
        /// Create a new author, with a request object
        /// </summary>
        /// <param name="authorCreateRequest">The DTO of the new author</param>
        /// <returns>The newly created author, as a response object</returns>
        public AuthorResponse Create(AuthorCreateRequest authorCreateRequest)
        {
            TitleAuthor newAuthor = new TitleAuthor
            {
                Name = authorCreateRequest.Name
            };

            _authorRepo.Add(newAuthor);

            _authorRepo.SaveChanges();

            return new AuthorResponse
            {
                TitleAuthorId = newAuthor.TitleAuthorId,
                Name = newAuthor.Name
            };
        }

        /// <summary>
        /// Update an author, with a request object
        /// </summary>
        /// <param name="id">The Id of the author to update</param>
        /// <param name="authorUpdateRequest">The request object to apply. If properties are null, they are ignored.</param>
        /// <returns>The newly updated author, as a response object</returns>
        /// <exception cref="KeyNotFoundException">The author to update could not be found</exception>
        public AuthorResponse Update(int id, AuthorUpdateRequest authorUpdateRequest)
        {
            TitleAuthor? authorToUpdate = _authorRepo.GetById(id);
            if (authorToUpdate == null)
            {
                throw new KeyNotFoundException("The author to update could not be found");
            }

            if (authorUpdateRequest.Name != null)
            {
                authorToUpdate.Name = authorUpdateRequest.Name;
            }

            _authorRepo.SaveChanges();

            return new AuthorResponse
            {
                Name = authorToUpdate.Name
            };
        }

        /// <summary>
        /// Overwrite an author at an Id with a create request object. All properties (except Id) are overwritten
        /// </summary>
        /// <param name="id">The Id of the author to overwrite</param>
        /// <param name="authorReplacement">The new create object to overwrite with</param>
        /// <returns>The newly-written author response</returns>
        /// <exception cref="KeyNotFoundException">The author to overwrite could not be found</exception>
        public AuthorResponse Overwrite(int id, AuthorCreateRequest authorReplacement)
        {
            TitleAuthor? authorToOverwrite = _authorRepo.GetById(id);
            if (authorToOverwrite == null)
            {
                throw new KeyNotFoundException("The author to overwrite could not be found");
            }

            authorToOverwrite.Name = authorReplacement.Name;

            _authorRepo.SaveChanges();

            return new AuthorResponse
            {
                Name = authorToOverwrite.Name
            };
        }

        /// <summary>
        /// Delete an author, by its Id
        /// </summary>
        /// <param name="id">The Id of the author to delete</param>
        /// <exception cref="KeyNotFoundException">The author to delete could not be found</exception>
        public void Delete(int id)
        {
            TitleAuthor? authorToDelete = _authorRepo.GetById(id);
            if (authorToDelete == null)
            {
                throw new KeyNotFoundException("The author to delete could not be found");
            }

            _authorRepo.Delete(authorToDelete);

            _authorRepo.SaveChanges();
        }
    }
}
