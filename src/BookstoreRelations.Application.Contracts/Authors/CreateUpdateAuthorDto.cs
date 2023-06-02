using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreRelations.Authors
{
    public class CreateUpdateAuthorDto
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}
