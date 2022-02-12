using System.Threading.Tasks;
using Xunit;

namespace RefactorMe.Tests;

public class IncrementExternalIdStrategyTests
{
    [Fact]
    public async Task Should_Return_External_Id_Test()
    {
        const string attribute = "increment";
        
        IExternalIdStrategy strategy = new IncrementExternalIdStrategy(attribute);

        var result = await strategy.GetExternalIdAsync();
        
        Assert.Equal(2, result.Length);
    }
}