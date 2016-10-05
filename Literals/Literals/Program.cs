using System;

namespace Literals
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryLiterals();
            DigitSeparators();
            BooleanLiterals();
            IntegerLiterals();
            RealLiterals();
            CharacterLiterals();
            StringLiterals();
            NullLiterals();
        }

        private static void DigitSeparators()
        {
            Console.WriteLine(nameof(DigitSeparators));
            ushort s1 = 0b1011_1100_1011_0011;
            ushort s2 = 0b1_111_000_111_000_111;
            int x1 = 0x44aa_abcd;
            Console.WriteLine($"{s1} {s2} {x1}");
            Console.WriteLine();
        }

        private static void NullLiterals()
        {
            object o = null;
        }

        private static void StringLiterals()
        {
            Console.WriteLine(nameof(StringLiterals));
            string s1 = "Hello!";
            string s2 = "Hello\tWorld";
            string s3 = @"Hello\tWorld";
            string s4 = "enter a \"string\"";
            string s5 = @"enter a ""string""";
            Console.WriteLine($"{s1} {s2} {s3} {s4} {s5}");
            Console.WriteLine();
        }

        private static void CharacterLiterals()
        {
            Console.WriteLine(nameof(CharacterLiterals));
            char c1 = 'a';
            char tab = '\t'; // Tab
            char hex = '\x05c';  // \
            char unicode = '\u0066'; // f
            Console.WriteLine($"{c1} {tab} {hex} {unicode}");
            Console.WriteLine();
        }

        private static void RealLiterals()
        {
            Console.WriteLine(nameof(RealLiterals));
            float f1 = 1.1F;
            double d1 = 2.2;
            decimal d2 = 3.30M;
            Console.WriteLine($"{f1} {d1} {d2}");
            Console.WriteLine();
        }

        private static void IntegerLiterals()
        {
            Console.WriteLine(nameof(IntegerLiterals));
            int n1 = 1;
            int n2 = 0xA;
            uint n3 = 3;
            long n4 = 4;
            ulong n5 = 5;
            uint n6 = 6u;
            ulong n7 = 7u;
            long n8 = 8L;
            ulong n9 = 9L;
            ulong n10 = 10uL;
            Console.WriteLine($"{n1} {n2} {n3} {n4} {n5} {n6} {n7} {n8} {n9} {n10}");
            Console.WriteLine();
        }

        private static void BooleanLiterals()
        {
            Console.WriteLine(nameof(BooleanLiterals));
            bool flag1 = true;
            bool flag2 = false;
            Console.WriteLine(flag1);
            Console.WriteLine(flag2);
            Console.WriteLine();
        }

        private static void BinaryLiterals()
        {
            Console.WriteLine(nameof(BinaryLiterals));
            byte b1 = 0b00001111;
            byte b2 = 0b10101010;
            ushort s1 = 0b1111000011110000;
            Console.WriteLine($"{b1:X}");
            Console.WriteLine($"{b2:X}");
            Console.WriteLine($"{s1:X}");
            Console.WriteLine();
        }
    }
}
