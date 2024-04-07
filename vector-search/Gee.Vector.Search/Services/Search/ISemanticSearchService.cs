using Gee.Vector.Search.Models;

namespace Gee.Vector.Search.Services;

public interface ISemanticSearchService
{
    Task<SearchResult> SearchAsync(string query, Models.Search.SemanticSearchOption options);
}
