using System;
using System.Threading.Tasks;
using RefactorMe.Factory;
using Xunit;

namespace RefactorMe.Tests;

public class DateExternalIdStrategyTests
{
    [Fact]
    public async Task Should_Return_External_Id_Test()
    {
        IExternalIdStrategy strategy = new DateExternalIdStrategy("ddMMyyyy");

        var result = await strategy.GetExternalIdAsync();
        
        //cant compare actual date value to an expected value due to DateTime.Now being called in the 
        //GetExternalIdAsync method.  Getting the Date and Time should be abstracted
        //into a class that can be mocked for unit tests
        
        Assert.Equal(8, result.Length);
    }
}