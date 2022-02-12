using System;
using RefactorMe.Factory;
using Xunit;

namespace RefactorMe.Tests;

public class ExternalIdFactoryTests
{
    [Fact]
    public void Should_Return_Date_External_Id_Strategy_Test()
    {
        var strategy = ExternalIdFactory.CreateExternalIdStrategy("date", string.Empty, new object());
        
        Assert.IsType<DateExternalIdStrategy>(strategy);
    }
    
    [Fact]
    public void Should_Return_Entity_External_Id_Strategy_Test()
    {
        var strategy = ExternalIdFactory.CreateExternalIdStrategy("entity", string.Empty, new object());
        
        Assert.IsType<EntityExternalIdStrategy>(strategy);
    }
    
    [Fact]
    public void Should_Return_Increment_External_Id_Strategy_Test()
    {
        var strategy = ExternalIdFactory.CreateExternalIdStrategy("increment", string.Empty, new object());
        
        Assert.IsType<IncrementExternalIdStrategy>(strategy);
    }
    
    [Fact]
    public void Should_Return_Reference_External_Id_Strategy_Test()
    {
        var strategy = ExternalIdFactory.CreateExternalIdStrategy("reference", string.Empty, new object());
        
        Assert.IsType<ReferenceExternalIdStrategy>(strategy);
    }
    
    [Fact]
    public void Should_Throw_ArgumentException_Test()
    {
        Assert.Throws<ArgumentException>(() => ExternalIdFactory.CreateExternalIdStrategy("", string.Empty, new object()));
    }
}