using SharedLibrary.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinClient.LocalServices
{
    public class XamarinMessageService : IMessageService
    {
        public Task MessageAsync(string message) =>
            Application.Current.MainPage.DisplayAlert("Xamarin Sample", message, "OK");
        
    }
}
