namespace GFeedbacks.Implementations
{
    public interface IResultParser
    {
        string Pass { get; set; }
        string Fail { get; set; }
        string Recall { get; set; }
    }
}