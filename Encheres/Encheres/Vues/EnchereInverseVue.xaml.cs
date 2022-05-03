using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encheres.Modeles;
using Encheres.VuesModeles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnchereInverseVue : ContentPage
    {
        //lien vers la page VueMOdele de tout les type d'enchere
        PageEnchereVueModele VuesModele;
        

        public EnchereInverseVue(Enchere param)
        {
            InitializeComponent();
            BindingContext = VuesModele = new PageEnchereVueModele(param);
        }

   
        

        

        private void ButtonValiderEnchereInverse_Clicked(object sender, EventArgs e)
        {
            if (SaisieEnchere.Text != null) VuesModele.EncherirManuellement(float.Parse(SaisieEnchere.Text));

        }

    }