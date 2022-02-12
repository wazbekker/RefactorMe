using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RefactorMe.Tests;

public class ReferenceExternalIdStrategyTests
{
    [Fact]
    public async Task Should_Return_External_Id_Test()
    {
        const string attribute = "reference";
        var entity = new Dictionary<string, object>
        {
            { "id", 1 },
            {
                "reference", new Dictionary<string, object>
                {
                }
            }
        };

        IExternalIdStrategy strategy = new ReferenceExternalIdStrategy(attribute, entity);

        var result = await strategy.GetExternalIdAsync();

        Assert.Null(result);
    }
}