using AutoMapper;
using BookstoreRelations.Authors;
using BookstoreRelations.Books;
using BookstoreRelations.Categories;

namespace BookstoreRelations;

public class BookstoreRelationsApplicationAutoMapperProfile : Profile
{
    public BookstoreRelationsApplicationAutoMapperProfile()
    {
        CreateMap<CategoryEntity, CategoryDto>();
        CreateMap<CategoryEntity, CategoryLookupDto>();
        CreateMap<CreateUpdateCategoryDto, CategoryEntity>();

        CreateMap<AuthorEntity, AuthorDto>();
        CreateMap<AuthorEntity, AuthorLookupDto>();
        CreateMap<CreateUpdateAuthorDto, AuthorEntity>();

        CreateMap<BookWithDetails, BookDto>();
    }
}
