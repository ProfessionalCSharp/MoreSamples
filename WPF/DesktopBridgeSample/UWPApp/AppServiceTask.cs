using System;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

namespace UWPApp
{
    public sealed class AppServiceTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _taskDeferral;
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _taskDeferral = taskInstance.GetDeferral();
            taskInstance.Canceled += OnTaskCanceled;
            if (taskInstance.TriggerDetails is AppServiceTriggerDetails details)
            {
                details.AppServiceConnection.RequestReceived += OnRequestReceived;
            }
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var deferral = args.GetDeferral();
            ValueSet message = args.Request.Message;
            await new MessageDialog("received message").ShowAsync();

            deferral.Complete();
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason) =>
            _taskDeferral?.Complete();
    }
}
