namespace safnet.Common.Utility
{
    public interface ISanitizer
    {
        string RemoveAllHtml(string input);
        string RemoveBadHtml(string input);
    }
}