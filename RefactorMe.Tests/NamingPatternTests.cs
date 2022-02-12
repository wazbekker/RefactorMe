using System.Collections.Generic;
using RefactorMe.Factory;
using Xunit;

namespace RefactorMe.Tests;

public class NamingPatternTests
{
    [Fact]
    public void Should_Return_Order_Template_Test()
    {
        const string expected = "ORD-{date:ddMMyyyy}-{increment:order}";

        var namingPattern = NamingPattern.NamingPatterns["Order"];
        
        Assert.Equal(namingPattern, expected);
    }
    
    [Fact]
    public void Should_Return_Site_Template_Test()
    {
        const string expected = "ST-{entity:location.address.postalOrZipCode}-{increment:site}";

        var namingPattern = NamingPattern.NamingPatterns["Site"];
        
        Assert.Equal(namingPattern, expected);
    }
    
    [Fact]
    public void Should_Return_Product_Template_Test()
    {
        const string expected = "PRD-{increment:product}";

        var namingPattern = NamingPattern.NamingPatterns["Product"];
        
        Assert.Equal(namingPattern, expected);
    }
    
    [Fact]
    public void Should_Throw_KeyNotFoundException_Test()
    {
        Assert.Throws<KeyNotFoundException>(() => NamingPattern.NamingPatterns[""]);
    }
}