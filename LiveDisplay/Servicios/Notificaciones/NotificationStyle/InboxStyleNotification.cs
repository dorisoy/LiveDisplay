using Android.Widget;

namespace LiveDisplay.Servicios.Notificaciones.NotificationStyle
{
    internal class InboxStyleNotification : NotificationStyle
    {
        public InboxStyleNotification(OpenNotification openNotification, ref LinearLayout notificationView, AndroidX.Fragment.App.Fragment notificationFragment)
      : base(openNotification, ref notificationView, notificationFragment)
        {
        }

        protected override void SetTextMaxLines()
        {
            Text.SetMaxLines(6);
        }
    }
}