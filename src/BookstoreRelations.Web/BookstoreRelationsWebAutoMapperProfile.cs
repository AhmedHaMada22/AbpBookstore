using AutoMapper;
using BookstoreRelations.Authors;
using BookstoreRelations.Books;
using BookstoreRelations.Categories;
using BookstoreRelations.Web.Models;
using Volo.Abp.AutoMapper;

namespace BookstoreRelations.Web;

public class BookstoreRelationsWebAutoMapperProfile : Profile
{
    public BookstoreRelationsWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CategoryLookupDto, CategoryViewModel>()
               .Ignore(x => x.IsSelected);

        CreateMap<BookDto, CreateUpdateBookDto>();

        CreateMap<AuthorDto, CreateUpdateAuthorDto>();

        CreateMap<CategoryDto, CreateUpdateCategoryDto>();
    }
}
