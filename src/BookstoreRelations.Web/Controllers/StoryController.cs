using BookstoreRelations.Books;
using BookstoreRelations.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BookstoreRelations.Web.Controllers
{
    public class StoryController : Controller
    {
        private readonly IBookAppService bookAppService;

        public StoryController(IBookAppService BookAppService)
        {
            bookAppService = BookAppService;
        }
        public async Task <IActionResult> IndexAsync(BookGetListInput input)
        {
            var books = await bookAppService.GetListAsync(input);
            return View(books);
        }
        
    }
}
