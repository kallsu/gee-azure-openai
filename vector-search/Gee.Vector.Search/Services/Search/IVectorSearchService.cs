using Gee.Vector.Search.Models;
using Gee.Vector.Search.Models.Search;

namespace Gee.Vector.Search.Services;

public interface IVectorSearchService
{
    Task<SearchResult> SearchAsync(string query, VectorSearchOption options);
}
