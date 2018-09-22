using System;
using System.Runtime.CompilerServices;

[module: NonNullTypes]

namespace NewAndGloryLib
{
    public class NewAndGlory
    {
        public string? GetANullString() => null;

        public string GetAString() => "a string";

        public string PassAString(string s) => s.ToUpper();

        public string PassAString2(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            return s.ToUpper();
        }
    }

    public interface INewInterface
    {
        string Bar();
    }
}
