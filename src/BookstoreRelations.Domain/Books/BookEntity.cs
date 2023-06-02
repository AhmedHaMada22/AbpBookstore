using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookstoreRelations.Books
{
    public class BookEntity : FullAuditedAggregateRoot<Guid>
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }
        public ICollection<BookCategoryEntity> BookCategoriesCollection { get; set; }

        private BookEntity()
        {
        }

        public BookEntity(Guid id, Guid authorId, string name, DateTime publishDate, float price)
            : base(id)
        {
            AuthorId = authorId;
            Name = name;
            PublishDate = publishDate;
            Price = price;

            BookCategoriesCollection = new Collection<BookCategoryEntity>();
        }

        public bool IsExistInBookCategoryAsync(Guid categoryId)
        {
            return  BookCategoriesCollection.Any(c => c.CategoryId == categoryId);
        }

        public bool AddInBookCategory(Guid categoryId)
        {
            if (IsExistInBookCategoryAsync(categoryId))
            {
                return false;
            }              
            
                BookCategoriesCollection.Add(new BookCategoryEntity(Id, categoryId));
            return true;
        }

        public bool RemoveFromBookCategory(Guid categoryId)
        {
            if(!IsExistInBookCategoryAsync(categoryId))
            {
                return false;
            }
            BookCategoriesCollection.RemoveAll(c =>c.CategoryId==categoryId);
            return true;
        }

        public bool RemoveAllBookCategoriesExceptGivenIds(List<Guid> categoryIds)
        {
            Check.NotNullOrEmpty(categoryIds, nameof(categoryIds));

            BookCategoriesCollection.RemoveAll(x => !categoryIds.Contains(x.CategoryId));
            return true;
        }

        public bool RemoveAllCategories()
        {
            BookCategoriesCollection.RemoveAll(x => x.BookId == Id);
            return true;
        }

        //#region Add or update bookcategory in one method in case more than propertes in BookCategories
        //public BookEntity AddOrUpdateBookCategoryCollection(ICollection<BookCategoryEntity> bookCategoryEntities)
        //{
        //    var CategoryIds = bookCategoryEntities.Select(o => o.CategoryId).ToList();
        //    BookCategoriesCollection.RemoveAll(o => !CategoryIds.Contains(o.CategoryId));
        //    foreach (var item in bookCategoryEntities)
        //    {
        //        var ExistBookCategory = BookCategoriesCollection.Where(o => o.CategoryId == item.CategoryId).FirstOrDefault();
        //        if (ExistBookCategory is not null)
        //        {

        //            ExistBookCategory.N = item.IsActive;
        //            ExistTestInstrument.QCActive = item.QCActive;
        //            ExistTestInstrument.AVActive = item.AVActive;
        //            ExistTestInstrument.LinearityMin = item.LinearityMin;
        //            ExistTestInstrument.LinearityMax = item.LinearityMax;
        //            ExistTestInstrument.FlagsCheck = item.FlagsCheck;
        //        }

        //        else
        //            TestInstrumentCollection.Add(item);
        //    }
        //    return this;
        //}

        //#endregion

    }
}
