namespace Aduanimex.Services
{
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Views;
    public class NavigationService
    {
        public void  SetMainPage(string pageName)
        {
            switch (pageName)
            {
                case "LoginView":
                    Application.Current.MainPage = new NavigationPage(new LoginView());
                    break;
                case "MasterView":
                    Application.Current.MainPage = new MasterView();
                    break;
            }
        }
        public async Task NavigateOnMaster(string PageName)
        {
            App.Master.IsPresented = false;
            string oPageName = PageName.Split('~')[0];
            switch (oPageName)
            {
                case "TrazabilidadBus":
                    await App.Navigator.PushAsync(
                   new TrazabilidadBus());
                    break;
                case "RelacionTercerosView":
                    await App.Navigator.PushAsync(
                   new RelacionTercerosView());
                    break;
                case "RelacionTercerosPage":
                    await App.Navigator.PushAsync(
                   new RelacionTercerosPage());
                    break;
                case "FacturaPage":
                    await App.Navigator.PushAsync(
                   new FacturaPage());
                    break;
                case "FacturaView":
                    await App.Navigator.PushAsync(
                   new FacturaView());
                    break;
                case "DocumentosDigContent":
                    await App.Navigator.PushAsync(
                   new DocumentosDigContent());
                    break;
                case "TrazabilidadView":
                    await App.Navigator.PushAsync(
                   new TrazabilidadView());
                    break;
                case "PreLiquidacionView":
                    await App.Navigator.PushAsync(
                   new PreLiquidacionView());
                    break;
                case "PreLiquidacionBus":
                    await App.Navigator.PushAsync(
                   new PreLiquidacionBus());
                    break;
                case "DocumentosDigBus":
                    await App.Navigator.PushAsync(
                   new DocumentosDigBus());
                    break;
                case "ContactenosPage":
                    await App.Navigator.PushAsync(
                   new ContactenosPage());
                    break;
                case "LoginView":
                    await App.Navigator.PushAsync(
                   new LoginView());
                    break;
            }
        }
    }
}
