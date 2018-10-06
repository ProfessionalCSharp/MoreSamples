using BooksLib.Models;
using BooksLib.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BooksLib.ViewModels
{
    public class BooksViewModel : BindableBase
    {
        private readonly IBooksService _booksService;
        private readonly ILaunchProtocolService _launchProtocolService;
        private readonly IUpdateTileService _updateTileService;
        private readonly IAppServiceClientService _appServiceClientService;
        private readonly IRunOnUIThreadService _runOnUIThreadService;

        public ObservableCollection<string> Messages { get; } = new ObservableCollection<string>();

        public BooksViewModel(
            IBooksService booksService, 
            ILaunchProtocolService launchProtocolService, 
            IPackageNameService packageNameService, 
            IUpdateTileService updateTileService, 
            IAppServiceClientService appServiceClientService,
            IRunOnUIThreadService runOnUIThreadService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            _launchProtocolService = launchProtocolService ?? throw new ArgumentNullException(nameof(launchProtocolService));
            _updateTileService = updateTileService ?? throw new ArgumentNullException(nameof(updateTileService));
            _appServiceClientService = appServiceClientService ?? throw new ArgumentNullException(nameof(appServiceClientService));
            _runOnUIThreadService = runOnUIThreadService ?? throw new ArgumentNullException(nameof(runOnUIThreadService));
            Package = packageNameService?.GetPackageName() ?? throw new ArgumentNullException(nameof(packageNameService));

            _appServiceClientService.MessageReceived += (sender, e) =>
            {
                // app service event is coming on a different thread, switch thread
                _runOnUIThreadService.RunOnUIThreadAsync(() => Messages.Add(e));
            };

            LaunchUWPCommand = new DelegateCommand(OnLaunchUWP);
            UpdateTileCommand = new DelegateCommand(OnUpdateTile);
            AppServiceCommand = new DelegateCommand(OnAppService);
        }

        public DelegateCommand LaunchUWPCommand { get; }
        public DelegateCommand UpdateTileCommand { get; }
        public DelegateCommand AppServiceCommand { get; }

        public IEnumerable<Book> Books => _booksService.Books;

        public async void OnLaunchUWP()
        {
            await _launchProtocolService.LaunchAppAsync("sampleapp");
        }

        public void OnUpdateTile()
        {
            _updateTileService.UpdateTile();
        }

        public void OnAppService()
        {
            _appServiceClientService.SendMessageAsync("StartEvents");
        }

        public string PackageName => Package.name;
        public string PackageId => Package.id;
        public (string name, string id) Package { get; }
    }
}
