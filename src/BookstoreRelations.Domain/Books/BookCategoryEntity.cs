using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookstoreRelations.Books
{
    public class BookCategoryEntity : FullAuditedEntity
    {
        public Guid BookId { get; protected set; }
        public Guid CategoryId { get; protected set; }

        private BookCategoryEntity()
        {
        }

        public BookCategoryEntity(Guid bookId, Guid categoryId)
        {
            BookId = bookId;
            CategoryId = categoryId;
        }

        public override object[] GetKeys()
        {
            return new object[] { BookId, CategoryId };
        }

       
    }
}
