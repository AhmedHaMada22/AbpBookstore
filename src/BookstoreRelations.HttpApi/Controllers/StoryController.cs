using BookstoreRelations.Authors;
using BookstoreRelations.Books;
using BookstoreRelations.Categories;

using Microsoft.AspNetCore.Mvc;
using System;

using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace BookstoreRelations.Controllers
{
    [Route("api/books/Story")]
    public class StoryController : BookstoreRelationsController, IBookAppService
    {
        private readonly IBookAppService _bookAppService;
        public StoryController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }
        [HttpPost]
        public async Task CreateAsync(CreateUpdateBookDto input)
        {
           await _bookAppService.CreateAsync(input);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
        }

        [HttpGet("GetById/{id}")]
        public async Task<BookDto> GetAsync(Guid id)
        {
            return await _bookAppService.GetAsync(id);
        }

        [HttpGet("GetAuthorLookup")]
        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            return await _bookAppService.GetAuthorLookupAsync();
        }
        [HttpGet("GetCategoryLookup")]
        public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
        {
            return await _bookAppService.GetCategoryLookupAsync();
        }

        [HttpGet("GetList")]
        public async Task<PagedResultDto<BookDto>> GetListAsync(BookGetListInput input)
        {
            return await _bookAppService.GetListAsync(input);   
        }
        [HttpPut("{id}")]
        public async Task UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            await _bookAppService.UpdateAsync(id, input);
        }
    }
}
