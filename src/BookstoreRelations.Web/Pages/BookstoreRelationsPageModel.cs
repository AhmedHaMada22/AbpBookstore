using BookstoreRelations.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BookstoreRelations.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BookstoreRelationsPageModel : AbpPageModel
{
    protected BookstoreRelationsPageModel()
    {
        LocalizationResourceType = typeof(BookstoreRelationsResource);
    }
}
