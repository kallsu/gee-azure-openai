namespace Gee.Vector.Search.Configurations;

public class ResearcherConfiguration
{
    public string ServiceEndpoint { get; set; } = string.Empty;

    public List<string> IndexNames { get; set; } = new List<string>();

    //
    // Vector search parameters
    //

    public string VectorSearchHnswProfile { get; set; } = string.Empty;

    public string VectorSearchExhasutiveKnnProfile { get; set; } = string.Empty;

    public string VectorSearchHnswConfig { get; set; } = string.Empty;

    public string VectorSearchExhaustiveKnnConfig { get; set; } = string.Empty;

    public string VectorSearchVectorizer { get; set; } = string.Empty;

    //
    // Semantic search parameters
    //

    public string SemanticSearchConfig { get; set; } = string.Empty;
}