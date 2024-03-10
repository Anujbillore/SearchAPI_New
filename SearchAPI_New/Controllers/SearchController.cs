// SearchController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[ValidateAntiForgeryToken]
public class SearchController : ControllerBase
{
    private readonly SearchService _searchService;

    public SearchController(SearchService searchService)
    {
        _searchService = searchService;
    }

    [HttpPost("search")]
    public async Task<IActionResult> PerformSearch(SearchQuery searchQuery)
    {
        var results = await _searchService.SearchAsync(searchQuery.Query);
        return Ok(results);
    }
}
