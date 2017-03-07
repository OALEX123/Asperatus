using System.Linq;
using System.Reflection;
using NTextCat;
using Shukratar.Domain.Language;

namespace Shukratar.Shared.Language
{
    public class LanguageIdentifier : ILanguageIdentifier
    {
        private const string LanguageModelProfile = "Shukratar.Shared.Language.Core14.profile.xml";
        private readonly RankedLanguageIdentifier _identifier;

        public LanguageIdentifier()
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(LanguageModelProfile);

            _identifier = new RankedLanguageIdentifierFactory().Load(stream);
        }

        public Domain.Language.Language Identify(string text)
        {
            var languages = _identifier.Identify(text);

            var mostCertainLanguage = languages.FirstOrDefault();

            var language = mostCertainLanguage?.Item1;

            if (language == null) return null;

            return new Domain.Language.Language(language.Iso639_3);
        }
    }
}