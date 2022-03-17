using System.Text.RegularExpressions;

namespace Lab_5.Models
{
    public class RegexFunction
    {

        public static string? FindRegexInText(string text, string reg)
        {
            Regex r = new Regex(reg);
            string answer = "";
            
            MatchCollection m = r.Matches(text);
            foreach (Match x in m) answer += (x.Value + "\n");
            return answer;
        }
    }
}
