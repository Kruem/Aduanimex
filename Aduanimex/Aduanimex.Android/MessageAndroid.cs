using Aduanimex.Droid;
using Android.App;
using Android.Widget;
using Aduanimex.Interfaces;
using Android.Graphics;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace Aduanimex.Droid
{
    public class MessageAndroid : IMessage
    {
        #region Métodos
        public void LongAlert(string message)
        {
            //Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
            Toast oToast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            TextView toasView = (TextView)oToast.View;
            toasView.SetTextColor(Color.Yellow);
            oToast.Show();
        }
        public void ShortAlert(string message)
        {
            //Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
            Toast oToast = Toast.MakeText(Application.Context, message, ToastLength.Short);
            TextView toasView = (TextView)oToast.View.FindViewById(Android.Resource.Id.Message);
            //toasView.SetBackgroundColor(Color.Gray);
            oToast.Show();
        }
        #endregion
    }
}