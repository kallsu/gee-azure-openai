using Azure.Search.Documents.Models;
using Gee.Vector.Search.Models;

namespace Gee.Vector.Search.Services;

public class SearchService : ISearchService
{

    protected async Task<SearchResult> ParseResponseAsync(SearchResults<SearchDocument> response)
    {
        if (response == null)
        {
            return new SearchResult(false, 0);
        }

        var myResult = new SearchResult(true, response.TotalCount);

        if (response.SemanticSearch?.Answers?.Count > 0)
        {
            foreach (QueryAnswerResult answer in response.SemanticSearch.Answers)
            {
                myResult.SemanticResults.Add(
                    new SemanticAnswer(answer.Text, answer.Highlights, answer.Score)
                );
            }
        }

        await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
        {
            var current = new SearchAnswer();

            current.Score = result.Score;

            // Need a dynamic object to traverse the document
            //
            //Console.WriteLine($"Title: {result.Document["title"]}");
            //Console.WriteLine($"Content: {result.Document["chunk"]}");

            if (result.SemanticSearch?.Captions?.Count > 0)
            {
                QueryCaptionResult firstCaption = result.SemanticSearch.Captions[0];

                current.SemanticAnswer = new SemanticAnswer(firstCaption.Text, firstCaption.Highlights, null);
            }

            myResult.SearchResults.Add(current);
        }

        return myResult;
    }
}