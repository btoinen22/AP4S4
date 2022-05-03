using Encheres.VuesModeles;
using Encheres.Modeles;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Encheres.Vues
{
    //page accessible seulement une fois connécté

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccueilPageVue : ContentPage
    {
        
        AccueilVueModele vueModel0;
        public AccueilPageVue()
        {
            InitializeComponent();
           BindingContext = vueModel0 = new AccueilVueModele();

        }
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushModalAsync(new PageEnchereVue(current));
        }

        //lien vers les enchére inverse accessible seulement connécté
        private void CollectionView_SelectionChanged_Inverse(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushModalAsync(new EnchereInverseVue(current));
        }

        private void classique_Clicked(object sender, EventArgs e)
        {
            vueModel0.VisibleEnchereEnCoursTypeClassique = true;
            vueModel0.VisibleEnchereEnCoursTypeInverse = false;
            vueModel0.VisibleEnchereEnCoursTypeFlash = false;

        }

        private void inverse_Clicked(object sender, EventArgs e)
        {
            vueModel0.VisibleEnchereEnCoursTypeClassique = false;
            vueModel0.VisibleEnchereEnCoursTypeInverse = true;
            vueModel0.VisibleEnchereEnCoursTypeFlash = false;
        }

        private void flash_Clicked(object sender, EventArgs e)
        {
            vueModel0.VisibleEnchereEnCoursTypeClassique = false;
            vueModel0.VisibleEnchereEnCoursTypeInverse = false;
            vueModel0.VisibleEnchereEnCoursTypeFlash = true;
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);

        }

        private void CollectionView_SelectionChanged_Flash(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushModalAsync(new EchereFlashVue(current));
        }
    }
}