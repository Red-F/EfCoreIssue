using System.Threading.Tasks;
using Demos.PrimitiveCollections.Model;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Demos.PrimitiveCollections;

public class PrimitiveCollectionDemos
{
    [Fact]
    public async Task StringIEnumerable_IsStoredSuccessful()
    {
        await using var writeDbContext = DemoDbContext.Create();
        writeDbContext.Set<WithIEnumerable>().Add(new WithIEnumerable("aName", ["aTag1", "aTag2"]));
        await writeDbContext.SaveChangesAsync();

        await using var readDbContext = DemoDbContext.Create();
        var result = await readDbContext.Set<WithIEnumerable>().FirstAsync();

        using var scope = new AssertionScope();
        result.Should().NotBeNull();
        result.Tags.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task StringList_IsStoredSuccessful()
    {
        await using var writeDbContext = DemoDbContext.Create();
        writeDbContext.Set<WithList>().Add(new WithList("aName", ["aTag1", "aTag2"]));
        await writeDbContext.SaveChangesAsync();

        await using var readDbContext = DemoDbContext.Create();
        var result = await readDbContext.Set < WithList>().FirstAsync();

        using var scope = new AssertionScope();
        result.Should().NotBeNull();
        result.Tags.Should().HaveCount(2);
    }
}