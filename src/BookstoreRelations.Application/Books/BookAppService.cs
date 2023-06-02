using BookstoreRelations.Authors;
using BookstoreRelations.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace BookstoreRelations.Books
{
    public class BookAppService : BookstoreRelationsAppService, IBookAppService
    {
        private readonly IBookRepository _bookRepository;
        private readonly BookManager _bookManager;
        private readonly IRepository<AuthorEntity, Guid> _authorRepository;
        private readonly IRepository<CategoryEntity, Guid> _categoryRepository;

        public BookAppService(
            IBookRepository bookRepository,
            BookManager bookManager,
            IRepository<AuthorEntity, Guid> authorRepository,
            IRepository<CategoryEntity, Guid> categoryRepository
            )
        {
            _bookRepository = bookRepository;
            _bookManager = bookManager;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(CreateUpdateBookDto input)
        {
            await _bookManager.CreateAsync(
               input.AuthorId,
                input.Name,
                input.PublishDate,
                input.Price,
                input.CategoryNames
            );
        }

        public async Task UpdateAsync(Guid id, CreateUpdateBookDto input)
        {
            var book = await _bookRepository.GetAsync(id, includeDetails: true);

            await _bookManager.UpdateAsync(
                book,
                input.AuthorId,
                input.Name,
                input.PublishDate,
                input.Price,
                input.CategoryNames
            );
        }
        public async Task DeleteAsync(Guid id)
        {
            await _bookRepository.DeleteAsync( id );
        }

        public async Task<BookDto> GetAsync(Guid id)
        {
           var bookWithdetails= await _bookRepository.GetAsync(id);
            return ObjectMapper.Map<BookWithDetails, BookDto>(bookWithdetails);
        }

        public async Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync()
        {
            var authorEntity = await _authorRepository.GetListAsync();

            return new ListResultDto<AuthorLookupDto>(
                ObjectMapper.Map<List<AuthorEntity>, List<AuthorLookupDto>>(authorEntity)
            );
        }

        public async Task<ListResultDto<CategoryLookupDto>> GetCategoryLookupAsync()
        {
            var categoryEntity=await _categoryRepository.GetListAsync();
            return new ListResultDto<CategoryLookupDto>(
                ObjectMapper.Map<List<CategoryEntity>, List<CategoryLookupDto>>(categoryEntity) 
                );
        }

        public async Task<PagedResultDto<BookDto>> GetListAsync(BookGetListInput input)
        {
            var books = await _bookRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
            var totalCount = await _bookRepository.CountAsync();

            return new PagedResultDto<BookDto>(totalCount, ObjectMapper.Map<List<BookWithDetails>, List<BookDto>>(books));
        }


    }
}
