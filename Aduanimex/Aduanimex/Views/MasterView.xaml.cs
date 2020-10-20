namespace Aduanimex.Views
{
    using Android.Graphics.Drawables;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterView : MasterDetailPage
	{
		public MasterView ()
		{
            //FlyOutMenuPage Menu = new FlyOutMenuPage();
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.Navigator = Navigator;
            App.Master = this;
        }
        //public class FlyOutMenuPage : ContentPage
        //{
        //   Icon "ir.png";           
        //}
    }
}