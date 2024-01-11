using System;
using System.Windows.Input;
using productoApp.Models;
using productoApp.Services;
using Xamarin.Forms;

namespace productoApp.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                SetProperty(ref username, value);
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                SetProperty(ref password, value);
            }
        }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new Command(OnLoginClicked);
                }
                return loginCommand;
            }
        }

        private async void OnLoginClicked()
        {
            
            var isValidUser = await _APIService.VerificarUsuario(new User { UserMail = Username, UserPassword = Password });

            if (isValidUser)
            {
                // Usuario válido, se realiza la navegacion a la siguiente pagina
                await Application.Current.MainPage.Navigation.PushAsync(new ProductoPage(_APIService));
            }
            else
            {
                // Muestra una alerta u otro mensaje indicando que el inicio de sesión falló
                await Application.Current.MainPage.DisplayAlert("Error", "Inicio de sesión fallido/Credenciales incorrectas", "OK");
            }
        }
    }
}