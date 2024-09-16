# EF Core 8 Issue using IEnumerable<>

According to https://learn.microsoft.com/en-us/ef/core/what-is-new/ef-core-8.0/whatsnew#primitive-collection-properties IEnumerable<> with a primitive type should be supported.

This demo shows how EFCore 8 will create the table and write the IEnumerable<string> property to it, but will throw an exception when retrieving the data from the table.