using BookstoreRelations.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BookstoreRelations.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BookstoreRelationsController : AbpControllerBase
{
    protected BookstoreRelationsController()
    {
        LocalizationResource = typeof(BookstoreRelationsResource);
    }
}
