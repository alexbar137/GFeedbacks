public enum SourceType { Body, Static, Subject}
public interface IParsingItem
{
    int? Group { get; set; }
    string Pattern { get; set; }
    SourceType Source { get; set; }
}