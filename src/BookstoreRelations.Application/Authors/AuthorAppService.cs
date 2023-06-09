﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookstoreRelations.Authors
{
    public class AuthorAppService :
         CrudAppService<AuthorEntity, AuthorDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateAuthorDto, CreateUpdateAuthorDto>,
         IAuthorAppService
    {
        public AuthorAppService(IRepository<AuthorEntity, Guid> repository) : base(repository)
        {
        }
    }
}
