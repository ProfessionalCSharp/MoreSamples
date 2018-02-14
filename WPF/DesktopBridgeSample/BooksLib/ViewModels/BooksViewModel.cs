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
        private readonly IUpdateTileService _updateTileService;


        public BooksViewModel(IBooksService booksService, ILaunchProtocolService launchProtocolService, IPackageNameService packageNameService, IUpdateTileService updateTileService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            _launchProtocolService = launchProtocolService ?? throw new ArgumentNullException(nameof(launchProtocolService));
            _updateTileService = updateTileService ?? throw new ArgumentNullException(nameof(updateTileService));
            _package = packageNameService?.GetPackageName() ?? throw new ArgumentNullException(nameof(packageNameService));
            LaunchUWPCommand = new DelegateCommand(OnLaunchUWP);
            UpdateTileCommand = new DelegateCommand(OnUpdateTile);
            ConnectCommand = new DelegateCommand(OnConnect);
        }

        public DelegateCommand LaunchUWPCommand { get; }
        public DelegateCommand UpdateTileCommand { get; }
        public DelegateCommand ConnectCommand { get; }

        public IEnumerable<Book> Books => _booksService.Books;

        public async void OnLaunchUWP()
        {
            await _launchProtocolService.LaunchAppAsync("sampleapp");
        }

        public void OnUpdateTile()
        {
            _updateTileService.UpdateTile();
        }

        public void OnConnect()
        {

        }

        public string PackageName => Package.name;
        public string PackageId => Package.id;

        private readonly (string name, string id) _package;
        public (string name, string id) Package => _package;
    }
}
