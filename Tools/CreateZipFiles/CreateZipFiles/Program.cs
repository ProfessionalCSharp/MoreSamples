using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace CreateZipFiles
{
    class Program
    {
        private const string SourceArchive = @"C:\Users\chris\Downloads\ProfessionalCSharp6-master.zip";
        private const string VS2015SourceArchive = @"c:\users\chris\downloads\ProfessionalCSharp6-vs2015.zip";
        private const string SourceTempFolder = @"c:\temp\procsharp";

        private readonly static string VS2015SourcesFolder = Path.Combine(SourceTempFolder, "ProfessionalCSharp6-vs2015");
        private readonly static string VS2017SourcesFolder = Path.Combine(SourceTempFolder, "ProfessionalCSharp6-master");

        private const string ZipFolder = @"c:\temp\zipchapters";

        private const string ResultFolder = @"c:\temp\results";


        private static Dictionary<string, string> ZipFileMapping;

        static void Main(string[] args)
        {
            InitZipFileMapping();
            Run();
        }

        private static void Run()
        {
            if (!UncompressFiles()) return;
            ChapterZipFiles();


            if (!Directory.Exists(ResultFolder))
            {
                Directory.CreateDirectory(ResultFolder);
            }

            foreach (var zipFile in ZipFileMapping.Keys)
            {
                string zipPath = Path.Combine(ResultFolder, zipFile);

                string file1 = Path.Combine(ZipFolder, $"{ZipFileMapping[zipFile]}-vs2015.zip");
                string file2 = Path.Combine(ZipFolder, $"{ZipFileMapping[zipFile]}-vs2017.zip");

                using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    if (File.Exists(file1))
                    {
                        archive.CreateEntryFromFile(file1, Path.GetFileName(file1));
                    }
                    else
                    {
                        Console.WriteLine($"{file1} does not exist");
                    }

                    if (File.Exists(file2))
                    {
                        archive.CreateEntryFromFile(file2, Path.GetFileName(file2));
                    }
                    else
                    {
                        Console.WriteLine($"{file2} does not exist");
                    }
                }

                Console.WriteLine($"created {zipPath}");

            }
        }

        private static void ChapterZipFiles()
        {
            if (!Directory.Exists(ZipFolder))
            {
                Directory.CreateDirectory(ZipFolder);
            }

            void CreateZipFile(string sourceFolder, string zipFile)
            {
                if (!Directory.Exists(sourceFolder))
                {
                    Console.WriteLine($"{sourceFolder} does not exist");
                    return;
                }
                string zipPath = Path.Combine(ZipFolder, zipFile);
                ZipFile.CreateFromDirectory(sourceFolder, zipPath);
                Console.WriteLine($"created {zipPath}");
            }

            foreach (var zipFile in ZipFileMapping.Keys)
            {
                string chapterFolder = ZipFileMapping[zipFile];
                string sourceFolder = Path.Combine(VS2015SourcesFolder, chapterFolder);

                CreateZipFile(sourceFolder, $"{chapterFolder}-vs2015.zip");
                sourceFolder = Path.Combine(VS2017SourcesFolder, ZipFileMapping[zipFile]);
                CreateZipFile(sourceFolder, $"{chapterFolder}-vs2017.zip");
            }

        }

        private static bool UncompressFiles()
        {
            Console.WriteLine("Uncompressing files...");
            if (Directory.Exists(SourceTempFolder))
            {
                Console.WriteLine($"delete {SourceTempFolder} before running this app");
                return false;
            }

            Directory.CreateDirectory(SourceTempFolder);

            Console.WriteLine("extracting VS2017 zip...");
            ZipFile.ExtractToDirectory(SourceArchive, SourceTempFolder);
            Console.WriteLine("extracting VS2015 zip...");
            ZipFile.ExtractToDirectory(VS2015SourceArchive, SourceTempFolder);

            Console.WriteLine($"Uncompressed files to {SourceTempFolder}");
            return true;
        }

        private static void InitZipFileMapping()
        {
            ZipFileMapping = new Dictionary<string, string>()
            {
                ["01_code.zip"] = "HelloWorld",
                ["02_code.zip"] = "CoreCSharp",
                ["03_code.zip"] = "ObjectsAndTypes",
                ["04_code.zip"] = "Inheritance",
                ["05_code.zip"] = "Resources",
                ["06_code.zip"] = "Generics",
                ["07_code.zip"] = "Arrays",
                ["08_code.zip"] = "OperatorsAndCasts",
                ["09_code.zip"] = "Delegates",
                ["10_code.zip"] = "StringsAndRegularExpressions",
                ["11_code.zip"] = "Collections",
                ["12_code.zip"] = "SpecialCollections",
                ["13_code.zip"] = "LINQ",
                ["14_code.zip"] = "ErrorsAndExceptions",
                ["15_code.zip"] = "Async",
                ["16_code.zip"] = "ReflectionAndDynamic",
                ["17_code.zip"] = "VisualStudio2015",
                ["18_code.zip"] = "CompilerPlatform",
                ["19_code.zip"] = "Testing",
                ["20_code.zip"] = "Diagnostics",
                ["21_code.zip"] = "Parallel",
                ["22_code.zip"] = "Synchronization",
                ["23_code.zip"] = "FilesAndStreams",
                ["24_code.zip"] = "Security",
                ["25_code.zip"] = "Networking",
                ["26_code.zip"] = "Composition",
                ["27_code.zip"] = "XMLandJSON",
                ["28_code.zip"] = "Localization",
                ["29_code.zip"] = "XAML",
                ["30_code.zip"] = "StylesAndResources",
                ["31_code.zip"] = "Patterns",
                ["32_code.zip"] = "WindowsApps",
                ["33_code.zip"] = "AdvancedWindowsApps",
                ["34_code.zip"] = "WPF",
                ["35_code.zip"] = "WPFDocuments",
                ["36_code.zip"] = "DeploymentWindows",
                ["37_code.zip"] = "ADONET",
                ["38_code.zip"] = "EntityFramework",
                ["39_code.zip"] = "Services",
                ["40_code.zip"] = "ASPNET",
                ["41_code.zip"] = "ASPNETMVC",
                ["42_code.zip"] = "WebAPI",
                ["43_code.zip"] = "SignalRAndWebHooks",
                ["44_code.zip"] = "WCF",
                ["45_code.zip"] = "DeploymentWeb",
                ["46_code.zip"] = "csproj",
                ["47_code.zip"] = "CSharp7"
            };
        }
    }
}
