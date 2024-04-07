using System.Text.Json;

namespace Gee.Vector.Search.Models.Search;

public class ResearcherOption
{
    // The number of search results to retrieve. This can be used in conjunction with
    // Azure.Search.Documents.SearchOptions.Skip to implement client-side paging of
    // search results. If results are truncated due to server-side paging, the response
    // will include a continuation token that can be used to issue another Search request
    // for the next page of results.
    public int Size { get; set; } = 3;

    // The OData $filter expression to apply to the search query. 
    // You can use Azure.Search.Documents.SearchFilter.Create(System.FormattableString) 
    // to help construct the filter expression.
    public string? Filter { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
