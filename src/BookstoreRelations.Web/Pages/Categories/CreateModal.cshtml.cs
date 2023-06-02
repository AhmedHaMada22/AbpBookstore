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

namespace BookstoreRelations.Web.Pages.Categories
{
    public class CreateModal : BookstoreRelationsPageModel
    {
        [BindProperty]
        public CreateUpdateCategoryDto Category { get; set; }

      
        private readonly ICategoryAppService _categoryAppService;

        public CreateModal(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task OnGetAsync()
        {
       
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            await _categoryAppService.CreateAsync(Category);
            return NoContent();
        }
    }
}
