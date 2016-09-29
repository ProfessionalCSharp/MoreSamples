using Prism.Mvvm;

namespace DeepLinkingSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _path;

        public string Path
        {
            get { return _path; }
            set { SetProperty(ref _path, value); }
        }

    }
}
