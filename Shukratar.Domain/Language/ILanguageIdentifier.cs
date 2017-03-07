namespace Shukratar.Domain.Language
{
    public interface ILanguageIdentifier
    {
        Language Identify(string text);
    }
}