using System;
using System.Collections.Generic;
using System.Reflection;
using Shukratar.Domain.Language.Lemma;

namespace Shukratar.Shared.Language.Lemma
{
    public class Lemmatizer : ILemmatizer
    {
        private static readonly Lazy<Dictionary<Domain.Language.Language, LemmaSharp.Classes.Lemmatizer>> Lemmatizers =
            new Lazy<Dictionary<Domain.Language.Language, LemmaSharp.Classes.Lemmatizer>>(Build);

        private static Dictionary<Domain.Language.Language, LemmaSharp.Classes.Lemmatizer> Build()
        {
            var assembly = Assembly.GetExecutingAssembly();

            const string path = "Shukratar.Shared.Language.Lemma.full7z-mlteast-{0}.lem";

            return new Dictionary<Domain.Language.Language, LemmaSharp.Classes.Lemmatizer>
            {
                {
                    new Domain.Language.Language("rus"),
                    new LemmaSharp.Classes.Lemmatizer(assembly.GetManifestResourceStream(string.Format(path, "ru")))
                },
                {
                    new Domain.Language.Language("eng"),
                    new LemmaSharp.Classes.Lemmatizer(assembly.GetManifestResourceStream(string.Format(path, "en")))
                }
            };
        }

        public string Lemmatize(string word, Domain.Language.Language language)
        {
            return Lemmatizers.Value.ContainsKey(language)
                ? Lemmatizers.Value[language].Lemmatize(word)
                : word;
        }
    }
}