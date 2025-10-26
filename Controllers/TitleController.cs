using Microsoft.AspNetCore.Mvc;
using ShelfLink.DTOs;
using ShelfLink.Services;

namespace ShelfLink.Controllers
{
    [ApiController]
    [Route("api/title")]
    public class TitleController : Controller
    {
        private readonly TitleService _titleService;

        public TitleController(TitleService titleService)
        {
            _titleService = titleService;
        }


        [HttpGet("{id}")]
        public TitleResponse? GetTitleById(int id)
        {
            return _titleService.GetById(id);
        }

        [HttpPost("search")]
        public List<TitleResponse> GetTitleByFilter([FromBody] TitleFilterRequest titleFilter, [FromQuery] int page, [FromQuery] int pageSize = 20)
        {
            return _titleService.GetByFilterPaged(titleFilter, page, pageSize);
        }

        [HttpPost()]
        public TitleResponse CreateTitle([FromBody] TitleCreateRequest titleCreateRequest)
        {
            return _titleService.Create(titleCreateRequest);
        }

        [HttpPut("{id}")]
        public TitleResponse? UpdateTitle(int id, [FromBody] TitleUpdateRequest updatedTitle)
        {
            return _titleService.Update(id, updatedTitle);
        }

        [HttpDelete("{id}")]
        public bool DeleteTitle(int id)
        {
            _titleService.Delete(id);

            return true;
        }
    }
}
