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

        public BooksViewModel(IBooksService booksService, ILaunchProtocolService launchProtocolService)
        {
            _booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
            _launchProtocolService = launchProtocolService ?? throw new ArgumentNullException(nameof(launchProtocolService));

            LaunchUWPCommand = new DelegateCommand(OnLaunchUWP);
        }

        public DelegateCommand LaunchUWPCommand {get; }

        public IEnumerable<Book> Books => _booksService.Books;

        public async void OnLaunchUWP()
        {
            await _launchProtocolService.LaunchAppAsync("sampleapp");
        }

        private string _packageInformation;

        public string PackageInformation
        {
            get => _packageInformation;
            set => _packageInformation = value;
        }

    }
}
