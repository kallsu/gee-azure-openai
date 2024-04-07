namespace Gee.Vector.Search.Models.Search;

public class VectorSearchOption : ResearcherOption
{
    public bool Exhaustive { get; set; } = true;

    // hybrid: on
    
    // should be read by configuration could not be so random
    public string SemantiSearchConfiguration { get; set; } = string.Empty;

    public bool IsSemantic {get; set; } = true;
}
