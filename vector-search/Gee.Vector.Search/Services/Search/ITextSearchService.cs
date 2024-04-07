using Gee.Vector.Search.Models;
using Gee.Vector.Search.Models.Search;

namespace Gee.Vector.Search.Services;

public interface ITextSearchService
{
    Task<SearchResult> SearchAsync(string query, TextSearchOption options);
}
