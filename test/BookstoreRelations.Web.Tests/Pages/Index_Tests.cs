using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace BookstoreRelations.Pages;

public class Index_Tests : BookstoreRelationsWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
