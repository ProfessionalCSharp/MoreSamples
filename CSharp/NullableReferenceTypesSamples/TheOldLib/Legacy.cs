using System;

namespace TheOldLib
{
    public class Legacy
    {
        public string GetANullString() => null;
        public string PassAString(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            return s.ToUpper();
        }
    }

    public interface ILegacyInterface
    {
        string Foo();
    }
}
    