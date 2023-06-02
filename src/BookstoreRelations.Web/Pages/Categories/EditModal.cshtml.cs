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

namespace BookstoreRelations.Web.Pages.Categories
{
    public class EditModal : BookstoreRelationsPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateCategoryDto EditingCategory { get; set; }

        

        private readonly ICategoryAppService _categoryAppService;

        public EditModal(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task OnGetAsync()
        {
            var categoryDto = await _categoryAppService.GetAsync(Id);
            EditingCategory = ObjectMapper.Map<CategoryDto, CreateUpdateCategoryDto>(categoryDto);
                    
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();          

            await _categoryAppService.UpdateAsync(Id, EditingCategory);
            return NoContent();
        }
    }
}
