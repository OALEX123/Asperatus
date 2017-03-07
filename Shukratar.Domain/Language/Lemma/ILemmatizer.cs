namespace Shukratar.Domain.Language.Lemma
{
    public interface ILemmatizer
    {
        string Lemmatize(string word, Language language);
    }
}