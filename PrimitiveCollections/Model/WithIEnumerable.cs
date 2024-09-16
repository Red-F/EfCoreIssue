using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demos.PrimitiveCollections.Model;

public class WithIEnumerable
{
    private WithIEnumerable()
    {
        Id = 0;
        Name = string.Empty;
        Tags = [];
    }
    
    public int Id { get; }
    public string Name { get; }
    public IEnumerable<string> Tags { get; }

    public WithIEnumerable(string name, IEnumerable<string> tags)
    {
        Name = name;
        Tags = tags;
    }
}

public class WithIEnumerableConfiguration : IEntityTypeConfiguration<WithIEnumerable>
{
    public void Configure(EntityTypeBuilder<WithIEnumerable> builder)
    {
        builder.ToTable("WithIEnumerable");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Tags);
    }
}
