using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace BookstoreRelations.Web;

[Dependency(ReplaceServices = true)]
public class BookstoreRelationsBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BookstoreRelations";
}
