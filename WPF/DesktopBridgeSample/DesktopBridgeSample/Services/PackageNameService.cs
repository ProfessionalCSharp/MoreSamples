using BooksLib.Services;
using System;
using Windows.ApplicationModel;

namespace DesktopBridgeSample.Services
{
    public class PackageNameService : IPackageNameService
    {
        public (string name, string id) GetPackageName()
        {
            try
            {
                Package package = Package.Current;
                return (package.DisplayName, package.Id.FullName);
            }
            catch (InvalidOperationException)
            {
                return ("no package", "");
            }
        }
    }
}
