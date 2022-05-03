using Encheres.Modeles;
using Encheres.Services;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Encheres.VuesModeles
{
    class RegisterVueModeles : BaseVueModele
    {

        #region Constructeurs

        public RegisterVueModeles(INavigation navigation)
        {
            new Command(() => Gotoco());
        }


        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes
        public async void Gotoco()
        {
            var route = $"{nameof(RegisterVue)}";
            await Shell.Current.GoToAsync(route);
        }

        #endregion
    }
}
