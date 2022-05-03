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
    public partial class AccueilVisiteurPage : ContentPage
    {
        AccueilVueModele vueModel;

        public AccueilVisiteurPage()
        {
            InitializeComponent();
            BindingContext = vueModel = new AccueilVueModele();
        }
       
        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //Permet de cliquer sur les enchéres et ramener sur la page d'enchereVue 
        private void CollectionView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var current = (Enchere)e.CurrentSelection.FirstOrDefault();
            Navigation.PushModalAsync(new PageEnchereVue(current));
        }
        //Permet que quand le bouton de la methode classique_clicked est cliker les enchére classque seule s'affiche 
        private void classique_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = true;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;

        }
        //Permet que quand le bouton de la methode inverse_clicked est cliker les enchére inverse  s'affiche et les 2 autres enchéres ne se voit pas 
        private void inverse_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = true;
            vueModel.VisibleEnchereEnCoursTypeFlash = false;
        }
        //Permet que quand le bouton de la methode flash_clicked est cliker les enchére flash  s'affiche 
        private void flash_Clicked(object sender, EventArgs e)
        {
            vueModel.VisibleEnchereEnCoursTypeClassique = false;
            vueModel.VisibleEnchereEnCoursTypeInverse = false;
            vueModel.VisibleEnchereEnCoursTypeFlash = true;
        }
        // mise en place d'une méthode qui permet de remonter en haut de la page
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await remote.ScrollToAsync(0, 0, true);

        }
        // Méthode du bouton de lien vers la page d'identification
        private void Connect(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new RegisterVue());
        
    }
        // Méthode du bouton de lien vers la page de Login 
        private void ButtonConexion(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new LoginPageVue());
        }
    }
}