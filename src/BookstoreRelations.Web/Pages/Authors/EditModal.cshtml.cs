using BookstoreRelations.Books;
using BookstoreRelations.Categories;
using BookstoreRelations.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using BookstoreRelations.Authors;

namespace BookstoreRelations.Web.Pages.Authors
{
    public class EditModal : BookstoreRelationsPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateAuthorDto EditingAuthor { get; set; }

        

        private readonly IAuthorAppService _authorAppService;

        public EditModal(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task OnGetAsync()
        {
            var authorDto = await _authorAppService.GetAsync(Id);
            EditingAuthor = ObjectMapper.Map<AuthorDto, CreateUpdateAuthorDto>(authorDto);
                    
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();          

            await _authorAppService.UpdateAsync(Id, EditingAuthor);
            return NoContent();
        }
    }
}
