using Ganss.XSS;

namespace safnet.Common.Utility
{
    public class Sanitizer : ISanitizer
    {
        public string RemoveAllHtml(string input)
        {
            return new HtmlSanitizer(allowedTags: new string[0], allowedAttributes: new string[0], allowedCssProperties: new string[0], allowedSchemes: new string[0])
                .Sanitize(input);
        }

        public string RemoveBadHtml(string input)
        {
            return new HtmlSanitizer()
                .Sanitize(input);
        }
    }
}
