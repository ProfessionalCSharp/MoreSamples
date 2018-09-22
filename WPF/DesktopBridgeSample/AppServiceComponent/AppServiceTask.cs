using System;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Collections;

namespace AppServiceComponent
{
    public sealed class AppServiceTask : IBackgroundTask
    {
        public AppServiceTask()
        {

        }

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
            ValueSet response = new ValueSet();
            response.Add("answer", "from UWP");
            await args.Request.SendResponseAsync(response);

            deferral.Complete();
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason) =>
            _taskDeferral?.Complete();
    }
}
