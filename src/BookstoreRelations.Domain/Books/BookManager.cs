using BookstoreRelations.Categories;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BookstoreRelations.Books
{
    public class BookManager: DomainService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRepository<CategoryEntity, Guid> _categoryRepository;

        //add new categoryIds in bookCategory table
        public BookManager(IBookRepository bookRepository, IRepository<CategoryEntity, Guid> categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }
        private async Task SetCategoriesAsync(BookEntity book, [CanBeNull] string[] categoryNames)
        {
            if (categoryNames == null || !categoryNames.Any())
            {
                book.RemoveAllCategories();
                return;
            }

            var query = (await _categoryRepository.GetQueryableAsync())
                .Where(x => categoryNames.Contains(x.Name))
                .Select(x => x.Id)
                .Distinct();

            var categoryIds = await AsyncExecuter.ToListAsync(query);
            if (!categoryIds.Any())
            {
                return;
            }

            book.RemoveAllBookCategoriesExceptGivenIds(categoryIds);

            foreach (var categoryId in categoryIds)
            {
                book.AddInBookCategory(categoryId);
            }
        }

        public async Task CreateAsync(Guid authorId, string name, DateTime publishDate, float price, [CanBeNull] string[] categoryNames)
        {
            var book = new BookEntity(GuidGenerator.Create(), authorId, name, publishDate, price);

            await SetCategoriesAsync(book, categoryNames);

            await _bookRepository.InsertAsync(book);
        }

        public async Task UpdateAsync(
            BookEntity book,
            Guid authorId,
            string name,
            DateTime publishDate,
            float price,
            [CanBeNull] string[] categoryNames
        )
        {
            book.AuthorId = authorId;
            book.Name=name;
            book.PublishDate = publishDate;
            book.Price = price;

            await SetCategoriesAsync(book, categoryNames);

            await _bookRepository.UpdateAsync(book);
        }
    }
  
    
}
