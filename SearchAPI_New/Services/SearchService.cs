// SearchService.cs
using Microsoft.EntityFrameworkCore;

public class SearchService
{
    private readonly SearchContext _context;

    public SearchService(SearchContext context)
    {
        _context = context;
    }
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }
    public async Task<List<SearchResult>> SearchAsync(string query)
    {
        //var results = await _context.SearchResults
        //    .Where(s => s.Title.Contains(query) || s.Description.Contains(query))
        //    .OrderByDescending(s => s.Date)
        //    .ToListAsync
        //    
        if (string.IsNullOrWhiteSpace(query))
        {
            throw new CustomException("Query is required.");
        }
        var results = await _context.SearchResults
                .Where(s => s.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            s.Description.Contains(query, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(s => s.Date)
                .ToListAsync();

        return results;
    }
    }
