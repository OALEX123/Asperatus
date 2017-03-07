using System.Linq;
using System.Text.RegularExpressions;

namespace Shukratar.Domain.Language.Ngram
{
    public class NgramTokenizer
    {
        private static readonly Regex WordTokenizerRegex = new Regex("[\\w]+");

        public static string[] Tokenize(string text)
        {
            var matches = WordTokenizerRegex.Matches(text);

            return matches.Cast<Match>().Select(x => x.Value.ToLower())
                .Where(x => x.Length > 0 && x.Length <= NgramToken.MaxLenght)
                .ToArray();
        }
    }
}