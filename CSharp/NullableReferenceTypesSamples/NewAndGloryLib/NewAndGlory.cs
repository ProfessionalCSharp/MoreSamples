namespace NewAndGloryLib
{
    public class NewAndGlory
    {
        public string? GetANullString() => null;

        public string GetAString() => "a string";

        public string PassAString(string s) => s.ToUpper();
    }

    public interface INewInterface
    {
        string Bar();
    }
}
