namespace Aduanimex.Views
{
    using System;
    using System.Diagnostics;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Generic error: " + ex.Message);
            }

           
                
            
		}
	}
}