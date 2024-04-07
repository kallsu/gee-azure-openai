namespace Gee.Vector.Search.Models;

public class SemanticAnswer
{
    public string Text { get; init; }

    public string Highlights { get; init; }

    public double? Score { get; init; }

    public SemanticAnswer(string text, string highlights, double? score)
    {
        Text = text;
        Highlights = highlights;
        Score = score;
    }
}
