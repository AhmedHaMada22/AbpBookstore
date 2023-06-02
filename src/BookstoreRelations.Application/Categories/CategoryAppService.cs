using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BookstoreRelations.Categories
{
    public class CategoryAppService :
        CrudAppService<CategoryEntity, CategoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto, CreateUpdateCategoryDto>,
        ICategoryAppService
    {
        public CategoryAppService(IRepository<CategoryEntity, Guid> repository) : base(repository)
        {
        }
    }
}
