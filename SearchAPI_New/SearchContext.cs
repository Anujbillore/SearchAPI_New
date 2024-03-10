// SearchContext.cs
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class SearchContext : DbContext
{
    public SearchContext(DbContextOptions<SearchContext> options) : base(options) { }

    public DbSet<SearchResult> SearchResults { get; set; }
}
