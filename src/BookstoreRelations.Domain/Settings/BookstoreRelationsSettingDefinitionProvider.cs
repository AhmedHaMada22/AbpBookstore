using Volo.Abp.Settings;

namespace BookstoreRelations.Settings;

public class BookstoreRelationsSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(BookstoreRelationsSettings.MySetting1));
    }
}
