using BookstoreRelations.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BookstoreRelations.Permissions;

public class BookstoreRelationsPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BookstoreRelationsPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BookstoreRelationsPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BookstoreRelationsResource>(name);
    }
}
