using System;

namespace UsingDeclarationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TraditionalUsingStatement();
            NewWithUsingDeclaration();
            TraditionalMultipleUsingStatements();
            NewMultipleUsingDeclarations();
            UsingDeclarationWithScope();
            TraditionalResourceReturned();
        }

        private static void TraditionalResourceReturned()
        {
            using (GetTheResource())
            {
                // do something here
            }  // resource is disposed here
        }

        private static void NewResourceRetured()
        {
            using var _ = GetTheResource();
            // do something here
        }  // resource is disposed here

        private static void UsingDeclarationWithScope()
        {
            {
                using var r1 = new AResource();
                r1.UseIt();
            }  // r1 is disposed here!
            Console.WriteLine("r1 is already disposed");
        }

        private static void NewMultipleUsingDeclarations()
        {
            using var r1 = new AResource();
            using var r2 = new AResource();
            r1.UseIt();
            r2.UseIt();
        }

        private static void TraditionalMultipleUsingStatements()
        {
            using (var r1 = new AResource())
            {
                using (var r2 = new AResource())
                {
                    r1.UseIt();
                    r2.UseIt();
                }
            }
        }

        private static void TraditionalMultipleUsingStatements2()
        {
            using (var r1 = new AResource())
            using (var r2 = new AResource())
            {
                r1.UseIt();
                r2.UseIt();
            }
        }

        private static void NewWithUsingDeclaration()
        {
            using var r = new AResource();
            r.UseIt();
        }

        private static void TraditionalUsingStatementExpanded()
        {
            var r = new AResource();
            try
            {
                r.UseIt();
            }
            finally
            {
                r.Dispose();
            }
        }

        private static void TraditionalUsingStatement()
        {
            using (var r = new AResource())
            {
                r.UseIt();
            }  // r.Dispose is called
        }

        public static AResource GetTheResource() => new AResource();
    }
}
