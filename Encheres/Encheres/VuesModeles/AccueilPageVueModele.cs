using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Encheres.VuesModeles
{
    class AccueilPageVueModele
    {
        #region Attributs
        #endregion

        #region Constructeur
        public AccueilPageVueModele ()
        {
            CommandeButtonLogin = new Command(ActionPageLogin);
            CommandeButtonRegister = new Command(ActionPageRegister);

        }

        #endregion
        #region Getters/Setters

        public ICommand CommandeButtonLogin { get; }

        public ICommand CommandeButtonRegister { get; }
        #endregion

        #region Méthodes

        public async void ActionPageLogin()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPageVue());

        }
        public async void ActionPageRegister()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterVue());

        }
        #endregion
    }
}
