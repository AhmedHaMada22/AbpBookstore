using System;
using System.Collections.Generic;
using System.Text;
using BookstoreRelations.Localization;
using Volo.Abp.Application.Services;

namespace BookstoreRelations;

/* Inherit your application services from this class.
 */
public abstract class BookstoreRelationsAppService : ApplicationService
{
    protected BookstoreRelationsAppService()
    {
        LocalizationResource = typeof(BookstoreRelationsResource);
    }
}
