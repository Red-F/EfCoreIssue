using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demos.PrimitiveCollections.Model;

public class WithList
{
    private WithList()
    {
        Id = 0;
        Name = string.Empty;
        Tags = [];
    }
    
    public int Id { get; }
    public string Name { get; }
    public List<string> Tags { get; }

    public WithList(string name, List<string> tags)
    {
        Name = name;
        Tags = tags;
    }
}

public class WithListConfiguration : IEntityTypeConfiguration<WithList>
{
    public void Configure(EntityTypeBuilder<WithList> builder)
    {
        builder.ToTable("WithList");
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(o => o.Name).IsRequired().HasMaxLength(100);
        builder.Property(o => o.Tags);
    }
}
