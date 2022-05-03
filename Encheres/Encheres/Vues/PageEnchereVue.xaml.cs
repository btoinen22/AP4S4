using Encheres.Modeles;
using Encheres.VuesModeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageEnchereVue : ContentPage
    {
        PageEnchereVueModele VuesModele;
        public PageEnchereVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele= new PageEnchereVueModele(param);
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);

        }
        private void ButtonValiderEnchere_Clicked(object sender, EventArgs e)
        {
            VuesModele.EncherirManuel(float.Parse(SaisieEnchere.Text));
        }
    }
}