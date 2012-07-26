using System.Text.RegularExpressions;

namespace Dem0n13.Replacer.Lib
{
    public class TextMatch
    {
        public TextListneningCoordinate Coordinate { get; private set; }
        public int Length { get; private set; }
        public bool Success { get; private set; }

        public string MatchString
        {
            get { return Groups[0].Value; }
        }

        public GroupCollection Groups { get; private set; }

        public TextMatch(Match match, Text text)
        {
            Coordinate = new TextListneningCoordinate(match.Index, text);
            Success = match.Success;
            Length = match.Length;
            Groups = match.Groups;
        }

        public new string ToString()
        {
            if (Success)
                if (Groups.Count > 1)
                    return string.Format("Success: {0} groups", Groups.Count);
                else
                    return "Success: " + MatchString;
            return "Fail";
        }
    }
}