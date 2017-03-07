namespace Shukratar.Domain.Html
{
    public interface IHtmlConverter
    {
        string ToPlainText(string html);
    }
}