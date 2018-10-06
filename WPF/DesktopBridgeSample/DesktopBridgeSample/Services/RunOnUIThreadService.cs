using BooksLib.Services;
using System;
using System.Threading.Tasks;

namespace DesktopBridgeSample.Services
{
    public class RunOnUIThreadService : IRunOnUIThreadService
    {
        public Task RunOnUIThreadAsync(Action action)
        {
            return App.Current.Dispatcher.InvokeAsync(action).Task;
        }
    }
}
