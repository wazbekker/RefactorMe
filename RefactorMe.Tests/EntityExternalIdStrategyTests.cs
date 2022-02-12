using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RefactorMe.Tests;

public class EntityExternalIdStrategyTests
{
    [Fact]
    public async Task Should_Return_External_Id_Test()
    {
        const string expected = "0042";
        const string attribute = "location.address.postalOrZipCode";
        var entity = new Dictionary<string, object>
        {
            { "id", 1 },
            {
                "location", new Dictionary<string, object>
                {
                    { "address", new Dictionary<string, object> { { "postalOrZipCode", "0042" } } }
                }
            }
        };
        
        IExternalIdStrategy strategy = new EntityExternalIdStrategy(attribute, entity);

        var result = await strategy.GetExternalIdAsync();
        
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public async Task Should_Return_Empty_String_If_Attributes_Not_Found_Test()
    {
        var expected = string.Empty;
        const string attribute = "location.address.postalOrZipCode";
        var entity = new Dictionary<string, object>
        {
            { "id", 2 },
        };
        
        IExternalIdStrategy strategy = new EntityExternalIdStrategy(attribute, entity);

        var result = await strategy.GetExternalIdAsync();
        
        Assert.Equal(expected, result);
    }
}