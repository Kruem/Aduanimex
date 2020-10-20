namespace Aduanimex.Services
{
    using System;
    using System.Threading.Tasks;
    using Plugin.Connectivity;
    using Xamarin.Forms;
    using Models;
    public class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "Aceptar");
        }
        public async void ConfirmarAsync(object sender, EventArgs e)
        {
            var respuesta = await Application.Current.MainPage.DisplayAlert(
                "Confirmar",
                "¿Realmente desea cerrar la sesión?",
                "Sí",
               "No");
        }
        public async Task<bool> Confirmar(string title, string message)
        {
            return await Application.Current.MainPage.DisplayAlert(
                title,
                message,
                "Si",
               "No");
        }
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Por favor encienda el acceso a internet.",
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "No hay navegación, valide su conexión.",
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
    }
}
