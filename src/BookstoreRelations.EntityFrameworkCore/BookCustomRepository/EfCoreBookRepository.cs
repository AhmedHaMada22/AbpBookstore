using BookstoreRelations.Authors;
using BookstoreRelations.Books;
using BookstoreRelations.Categories;
using BookstoreRelations.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BookstoreRelations.BookCustomRepository
{
    public class EfCoreBookRepository : EfCoreRepository<BookstoreRelationsDbContext, BookEntity, Guid>, IBookRepository
    {
        public EfCoreBookRepository(IDbContextProvider<BookstoreRelationsDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<BookWithDetails>> GetListAsync( string sorting,int skipCount, int maxResultCount,CancellationToken cancellationToken = default )
        {
            var query = await ApplyFilterAsync();

            return await query
                .OrderBy(m=>m.Name)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<BookWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = await ApplyFilterAsync();

            return await query
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        private async Task<IQueryable<BookWithDetails>> ApplyFilterAsync()
        {
            var dbContext = await GetDbContextAsync();

            return (await GetDbSetAsync())
                .Include(x => x.BookCategoriesCollection)
                .Join(dbContext.Set<AuthorEntity>(), book => book.AuthorId, author => author.Id,
                    (book, author) => new { book, author })
                .Select(x => new BookWithDetails
                {
                    Id = x.book.Id,
                    Name = x.book.Name,
                    Price = x.book.Price,
                    PublishDate = x.book.PublishDate,
                    CreationTime = x.book.CreationTime,
                    AuthorName = x.author.Name,
                    CategoryNames = (from bookCategories in x.book.BookCategoriesCollection
                                     join category in dbContext.Set<CategoryEntity>() on bookCategories.CategoryId equals category.Id
                                     select category.Name).ToArray()
                });
        }

        public override Task<IQueryable<BookEntity>> WithDetailsAsync()
        {
            return base.WithDetailsAsync(x => x.BookCategoriesCollection);
        }
    }
}
