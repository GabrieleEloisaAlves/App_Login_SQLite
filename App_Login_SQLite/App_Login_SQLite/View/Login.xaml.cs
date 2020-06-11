using App_Login_SQLite.Model;
using App_Login_SQLite.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Login_SQLite.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void Button_Clicked_Entrar(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;
                ServicesBDUsuario dbAula = new ServicesBDUsuario(App.DbPath);

                var result = dbAula.ValidarLogin(usuario, senha);
                if (result != null)
                {
                    await DisplayAlert("Resultado", "Login Efetuado", "OK");
                    await Navigation.PushAsync(new Menu(result));
                }
                else
                {
                    txtSenha.Text = "";
                    txtUsuario.Text = "";
                    await DisplayAlert("Resultado", "Usuario ou senha incorretos", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");

            }
        }

        private async void Button_Clicked_Registrar(object sender, EventArgs e)
        {
            try
            {
                var p = new NovoUsuario();
                await Navigation.PushAsync(p);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");

            }
        }
    }
    }