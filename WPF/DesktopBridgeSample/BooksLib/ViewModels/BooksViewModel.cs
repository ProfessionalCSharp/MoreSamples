using BooksLib.Models;
using BooksLib.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace BooksLib.ViewModels
{
    public class BooksViewModel : BindableBase
    {
        private readonly IBooksService _booksService;
        private readonly ILaunchProtocolService _launchProtocolService;
        private readonly IPackageNameService _packageNameService;
        private readonly (string packageName, string id) _package;

        public BooksViewModel(IBooksService booksService, ILaunchProtocolService launchProtocolService, IPackageNameService packageNameService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            _launchProtocolService = launchProtocolService ?? throw new ArgumentNullException(nameof(launchProtocolService));
            _packageNameService = packageNameService ?? throw new ArgumentNullException(nameof(packageNameService));

            _package = packageNameService.GetPackageName();
            LaunchUWPCommand = new DelegateCommand(OnLaunchUWP);
        }

        public DelegateCommand LaunchUWPCommand {get; }

        public IEnumerable<Book> Books => _booksService.Books;

        public async void OnLaunchUWP()
        {
            await _launchProtocolService.LaunchAppAsync("sampleapp");
        }

        public string PackageName => _package.packageName;
        public string PackageId => _package.id;

    }
}
