namespace Shukratar.Domain.Language
{
    public class Language
    {
        private string _code;

        public Language()
        {
        }

        public Language(string code)
        {
            Code = code;
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public override bool Equals(object obj)
        {
            return string.Equals(Code, (obj as Language)?.Code);
        }

        public override int GetHashCode()
        {
            return Code?.GetHashCode() ?? 0;
        }
    }
}