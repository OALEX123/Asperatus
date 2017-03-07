using System.Collections.Generic;

namespace Shukratar.Domain.Language
{
    public interface ILanguageProvider
    {
        List<string> Get();
    }
}