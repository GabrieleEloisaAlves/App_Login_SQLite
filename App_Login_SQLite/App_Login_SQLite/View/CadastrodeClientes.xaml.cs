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
    public partial class CadastrodeClientes : ContentPage
    {
        
        public CadastrodeClientes()
        {
            InitializeComponent();
        }

        private void BtIncluirDados_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelCliente user = new ModelCliente();
                user.Nome = txtNome.Text;
                user.Endereco = txtEndereco.Text;
                user.Email = txtEmail.Text;
                user.Cidade = txtCidade.Text;
                user.Estado = txtEstado.Text;
                user.Cep = txtCep.Text;
                user.Telefone = txtTelefone.Text;
                ServicesBDCliente dbCliente = new ServicesBDCliente(App.DbPath);
                if (btIncluirDados.Text == "INCLUIR DADOS")
                {
                    dbCliente.Incluir(user);
                    DisplayAlert("Resultado da operação", dbCliente.StatusMessage, "OK");
                }
                else
                {
                }
               /* MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new Home()); */
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
    }
