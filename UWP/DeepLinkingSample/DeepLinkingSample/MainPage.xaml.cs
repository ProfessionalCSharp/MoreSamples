using DeepLinkingSample.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DeepLinkingSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            ViewModel = new MainPageViewModel();
            this.InitializeComponent();
        }

        MainPageViewModel ViewModel { get; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Path = e.Parameter.ToString();
        }
    }
}