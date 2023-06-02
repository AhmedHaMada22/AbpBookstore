using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace BookstoreRelations.Categories
{
    public class CategoryEntity : AuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }

        /* This constructor is for deserialization / ORM purpose */
        private CategoryEntity()
        {
        }

        public CategoryEntity(Guid id, string name) : base(id)
        {
            Name = name;
        }

       
    }
}
