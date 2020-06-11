using App_Login_SQLite.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Login_SQLite
{
    public partial class App : Application
    {
        public static String DbName;
        public static String DbPath;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        public App(string dbPath, string dbName)
        {
            InitializeComponent();

            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
