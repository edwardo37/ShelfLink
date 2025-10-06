using ShelfLink.Repositories;
using ShelfLink.Models;

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
    }
}
