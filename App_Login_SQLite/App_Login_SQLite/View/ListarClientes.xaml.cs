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
    public partial class ListarClientes : ContentPage
    {
        public ListarClientes()
        {
            InitializeComponent();
            AtualizaLista();
        }

        public void AtualizaLista()
        {
            ServicesBDCliente dbCliente = new ServicesBDCliente(App.DbPath);
            ListaClientes.ItemsSource = dbCliente.ListarCliente();
        }




    }
}