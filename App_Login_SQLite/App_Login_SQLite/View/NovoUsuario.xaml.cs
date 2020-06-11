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
    public partial class NovoUsuario : ContentPage
    {
        int id;
        public NovoUsuario()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (Menu.usuario != null)
            {
                btCadastrar.Text = "Alterar";
                btExcluir.IsVisible = true;
                btCancelar.IsVisible = false;
                lblTitulo.Text = "ALTERAR SENHA";

                id = Menu.usuario.Id;

                txtUsuario.Text = Menu.usuario.Nome;
                txtSenha.Text = Menu.usuario.Senha;
                NavigationPage.SetHasNavigationBar(this, true);
            }
        }

        private async void Button_Clicked_Novo(object sender, EventArgs e)
        {
            try
            {
                ModelUsuario user = new ModelUsuario();
                user.Nome = txtUsuario.Text;
                user.Senha = txtSenha.Text;

                ServicesBDUsuario dbAula = new ServicesBDUsuario(App.DbPath);

                if (btCadastrar.Text == "CRIAR NOVO USUÁRIO")
                {
                    dbAula.Inserir(user);
                    await DisplayAlert("Resultado da operação", dbAula.StatusMessage, "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    user.Id = id;
                    dbAula.Alterar(user);
                    await DisplayAlert("Resultado da operação", dbAula.StatusMessage, "OK");
                    Menu.usuario.Nome = txtUsuario.Text;
                    Menu.usuario.Senha = txtSenha.Text;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void BtCancelar_Clicked(object sender, EventArgs e)
        {
            if (btCadastrar.Text == "CRIAR NOVO USUÁRIO")
            {
                await Navigation.PushAsync(new Login());
            }

        }

        private async void BtExcluir_Clicked(object sender, EventArgs e)
        {

            bool resp = await DisplayAlert("Excluir Registro",
                "Deseja excluir a nota atual?",
                "Sim", "Não");

            if (resp)
            {
                ServicesBDUsuario dbAula = new ServicesBDUsuario(App.DbPath);
                dbAula.Excluir(id);
                await DisplayAlert("Resultado da operação", dbAula.StatusMessage, "OK");
                Menu.usuario = null;
                await Navigation.PushAsync(new Login());

            }
        }
    }
}