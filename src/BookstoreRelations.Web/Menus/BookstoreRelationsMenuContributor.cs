using System.Threading.Tasks;
using BookstoreRelations.Localization;
using BookstoreRelations.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace BookstoreRelations.Web.Menus;

public class BookstoreRelationsMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<BookstoreRelationsResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                BookstoreRelationsMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "BooksStore",
        l["Menu"],
        icon: "fa fa-book"
    ).AddItem(
        new ApplicationMenuItem(
            "BookstoreRelations.Books",
            l["Books"],
            url: "/Books"
        )
    )

    .AddItem(
        new ApplicationMenuItem(
            "BookstoreRelations.Authors",
            l["Authors"],
            url: "/Authors"
        )
    )

    .AddItem(
        new ApplicationMenuItem(
            "BookstoreRelations.Categories",
            l["Categories"],
            url: "/Categories"
        )
    )

    .AddItem(
        new ApplicationMenuItem(
            "BookstoreRelations.Test",
            l["Test"],
            url: "/Test"
        )
    )

);




        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);
    }
}
