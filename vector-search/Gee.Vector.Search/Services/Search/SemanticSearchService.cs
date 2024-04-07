using Azure.Identity;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Gee.Vector.Search.Configurations;
using Gee.Vector.Search.Models;
using Microsoft.Extensions.Logging;

namespace Gee.Vector.Search.Services;

public class SemanticSearchService : SearchService, ISemanticSearchService
{
    private readonly ILogger<ISemanticSearchService> _logger;

    private readonly ResearcherConfiguration _configuration;

    public SemanticSearchService(ILogger<ISemanticSearchService> logger,
        ResearcherConfiguration configuration)
    {
        _logger = logger;

        _configuration = configuration;
    }

    public async Task<SearchResult> SearchAsync(string query, Models.Search.SemanticSearchOption options)
    {
        // remember to cut the query if it too long !
        _logger.LogInformation(@"Execute a search with the query: [{query}]", query);

        // override the ToString method to have a nice reading here !
        _logger.LogInformation("The search options are: [{options}]", options);

        _logger.LogDebug("Prepare the search options with the generic parameter");

        var searchOptions = new SearchOptions
        {
            Filter = options.Filter,
            Size = options.Size,
            IncludeTotalCount = true
        };


        _logger.LogDebug("Hybrid is enabled as default, so configure the vector search parameters");
        searchOptions.VectorSearch = new()
        {
            Queries = {
                        new VectorizableTextQuery(text: query)
                        {
                            KNearestNeighborsCount = options.Size,
                            Fields = { "vector" },
                            Exhaustive = true
                        }
                    },

        };


        _logger.LogDebug("Configure the semantic parameters");

        searchOptions.QueryType = SearchQueryType.Semantic;
        searchOptions.SemanticSearch = new SemanticSearchOptions
        {
            SemanticConfigurationName = options.SemantiSearchConfiguration,
            QueryCaption = new QueryCaption(QueryCaptionType.Extractive),
            QueryAnswer = new QueryAnswer(QueryAnswerType.Extractive)
        };


        _logger.LogInformation("Run the search according to the {searchOptions}", searchOptions);

        // ---
        var client = new SearchIndexClient(new Uri(_configuration.ServiceEndpoint), new DefaultAzureCredential());

        // create the search client
        var searchClient = client.GetSearchClient(indexName);

        SearchResults<SearchDocument> response =
            await searchClient.SearchAsync<SearchDocument>(query, searchOptions);

        _logger.LogInformation("Search executed. Starting the checks to prepare the answer");

        return await ParseResponseAsync(response);
    }
}