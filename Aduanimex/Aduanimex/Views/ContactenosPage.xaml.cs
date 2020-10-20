namespace Aduanimex.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactenosPage : ContentPage
    {
        public ContactenosPage()
        {
            InitializeComponent();
            webView.Source = "http://www.aduanimex.com.co/contactenos.html";
        }
    }
}