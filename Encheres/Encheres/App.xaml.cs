using Encheres.Vues;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //page de demarrage 
            MainPage = new AccueilVisiteurPage();
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
