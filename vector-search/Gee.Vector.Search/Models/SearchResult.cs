namespace Gee.Vector.Search.Models;

public class SearchResult
{
    public bool IsSuccess { get; init; }

    public long? TotalCount { get; init; }

    public IList<SemanticAnswer> SemanticResults { get; init; } 

    public IList<SearchAnswer> SearchResults { get; init; }

    public SearchResult(bool isSuccess, long? totalCount)
    {
        IsSuccess = isSuccess;
        TotalCount = totalCount;
        SemanticResults = new List<SemanticAnswer>();
        SearchResults = new List<SearchAnswer>();
    }
}
