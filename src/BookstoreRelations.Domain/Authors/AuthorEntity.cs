using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookstoreRelations.Authors
{
    public class AuthorEntity: FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string ShortBio { get; set; }

        private AuthorEntity()
        {

        }

        public AuthorEntity(Guid id,string name, DateTime birthDate,string shortBio = null)
           : base(id)
        {
            Name = name;
            BirthDate = birthDate;
            ShortBio = shortBio;
        }

    }


}
