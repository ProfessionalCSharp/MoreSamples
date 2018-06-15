using NewAndGloryLib;
using System;

namespace TheOldApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var glory = new NewAndGlory();
            string s1 = glory.GetANullString();
            string s2 = glory.GetAString();
            string s3 = glory.PassAString(null);
        }
    }
}
