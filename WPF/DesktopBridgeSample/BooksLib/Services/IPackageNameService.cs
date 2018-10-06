namespace BooksLib.Services
{
    public interface IPackageNameService
    {
        (string name, string id) GetPackageName();
    }
}
