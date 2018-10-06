using BooksLib.Services;
using System;
using System.Threading;
using System.Windows;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace DesktopBridgeSample.Services
{
    public class UpdateTileService : IUpdateTileService
    {
        private static int s_badgeNumber = 0;
        public static int GetBadgeNumber() =>
            Interlocked.Increment(ref s_badgeNumber);
        
        public void UpdateTile()
        {
            try
            {
                XmlDocument badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
                XmlNodeList badge = badgeXml.GetElementsByTagName("badge");
                badge[0].Attributes[0].NodeValue = GetBadgeNumber().ToString();
                var notification = new BadgeNotification(badgeXml);
                BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(notification);
            }
            catch (Exception ex) when (ex.HResult == -2147023728)
            {
                MessageBox.Show("not started with a package?");
            }
        }
    }
}
