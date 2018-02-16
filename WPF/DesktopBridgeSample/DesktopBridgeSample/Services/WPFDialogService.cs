using BooksLib.Services;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopBridgeSample.Services
{
    public class WPFDialogService : IDialogService
    {
        public Task ShowMessageAsync(string message)
        {
            MessageBox.Show(message);
            return Task.CompletedTask;
        }
    }
}
