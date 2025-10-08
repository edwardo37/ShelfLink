using ShelfLink.Repositories;
using ShelfLink.Models;
using ShelfLink.DTOs;

namespace ShelfLink.Services
{
    public class TitleService
    {
        private readonly IShelfLinkRepository<Title> _titleRepo;
        private readonly IShelfLinkRepository<TitleAuthor> _authorRepo;

        private readonly IShelfLinkRepository<TitlePublisher> _publisherRepo;
        private readonly IShelfLinkRepository<TitleGenre> _genreRepo;
        private readonly IShelfLinkRepository<TitleCategory> _categoryRepo;

        private readonly IShelfLinkRepository<TitleCopy> _copyRepo;
        private readonly IShelfLinkRepository<CopyCheckout> _checkoutRepo;
        private readonly IShelfLinkRepository<TitleHold> _holdRepo;

        public TitleService(
            IShelfLinkRepository<Title> titleRepo,
            IShelfLinkRepository<TitleAuthor> authorRepo,
            IShelfLinkRepository<TitlePublisher> publisherRepo,
            IShelfLinkRepository<TitleGenre> genreRepo,
            IShelfLinkRepository<TitleCategory> categoryRepo,
            IShelfLinkRepository<TitleCopy> copyRepo,
            IShelfLinkRepository<CopyCheckout> checkoutRepo,
            IShelfLinkRepository<TitleHold> holdRepo
        )
        {
            _titleRepo = titleRepo;
            _authorRepo = authorRepo;
            _publisherRepo = publisherRepo;
            _genreRepo = genreRepo;
            _categoryRepo = categoryRepo;
            _copyRepo = copyRepo;
            _checkoutRepo = checkoutRepo;
            _holdRepo = holdRepo;
        }


        /// <summary>
        /// Get a title by its Id
        /// </summary>
        /// <param name="id">The Id of the title to fetch</param>
        /// <returns>The title. Exception if not found.</returns>
        /// <exception cref="KeyNotFoundException">The title was not found in the database.</exception>
        public Title GetById(int id)
        {
            return _titleRepo.GetById(id) ?? throw new KeyNotFoundException($"Title with id {id} not found");
        }

        public List<Title> GetByFilterPaged(TitleFilterRequest titleFilter, int page, int pageSize)
        {
            var query = _titleRepo.Query();

            // Basic string queries
            query = query
                .Where(title => title.Name.Contains(titleFilter.Name))
                .Where(title => title.ISBN.Contains(titleFilter.ISBN))
                .Where(title => title.Publisher.Name.Contains(titleFilter.Publisher))
                .Where(title => title.Genre.Name.Contains(titleFilter.Genre))
                .Where(title => title.Category.Name.Contains(titleFilter.Category))
                // List of authors matches any
                // TODO: only accept Ids based on dynamic content in the front-end
                .Where(title => title.Authors.Any(author => titleFilter.Authors.Contains(author.Name)));

            if (titleFilter.PublishYear != null)
            {
                query = query.Where(title => title.PublishDate.Year == titleFilter.PublishYear);
            }

            return query
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
