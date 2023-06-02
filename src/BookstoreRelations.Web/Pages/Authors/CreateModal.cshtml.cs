using BookstoreRelations.Authors;
using BookstoreRelations.Books;
using BookstoreRelations.Categories;
using BookstoreRelations.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreRelations.Web.Pages.Authors
{
    public class CreateModal : BookstoreRelationsPageModel
    {
        [BindProperty]
        public CreateUpdateAuthorDto Author { get; set; }

      
        private readonly IAuthorAppService _authorAppService;

        public CreateModal(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }

        public async Task OnGetAsync()
        {
       
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            await _authorAppService.CreateAsync(Author);
            return NoContent();
        }
    }
}
