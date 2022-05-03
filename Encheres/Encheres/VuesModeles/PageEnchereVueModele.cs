using Encheres.Modeles;
using Encheres.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Encheres.VuesModeles
{
    class PageEnchereVueModele : BaseVueModele
    {
        #region attributs
        private readonly Api _apiServices = new Api();
        private DecompteTimer tmps;
        private Enchere _monEnchere;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private ObservableCollection<Encherir> _maListeSixDernieresEncheres;
        private Encherir _prixActuel;
        private string _idUser;
        private User _unUser;
        private float _plafond;
        private float _saisieSecondes;
        public bool OnCancel;
        private bool _visibleSaisieEnchere;
        private bool _visibleGagnant;
        TimeSpan interval;
        #endregion
        #region Constructeurs

        public PageEnchereVueModele(Enchere param)
        {
            _monEnchere = param;

            DateTime datefin = param.Datefin;
            interval = datefin - DateTime.Now;
            this.VisibleSaisieEnchere = true;

            tmps = new DecompteTimer();
            this.GetTimerRemaining(param.Datefin);
            
            this.GetValeurActuelle();
            this.SetEnchereAuto();
            this.SixDernieresEncheres();
            this.GetGagnant(MonEnchere.Id.ToString());
        }


        #endregion
        #region Getters/Setters

        public Enchere MonEnchere
        {
            get
            {
                return _monEnchere;
            }
            set
            {
                SetProperty(ref _monEnchere, value);
            }
        }
        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty(ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }

        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }

        public string IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }
        public User UnUser
        {
            get
            {
                return _unUser;
            }
            set
            {
                SetProperty(ref _unUser, value);
            }
        }
        public bool VisibleSaisieEnchere
        {
            get { return _visibleSaisieEnchere; }
            set { SetProperty(ref _visibleSaisieEnchere, value); }
        }
        public bool VisibleGagnant
        {
            get { return _visibleGagnant; }
            set { SetProperty(ref _visibleGagnant, value); }
        }

        public float Plafond
        {
            get => _plafond;
            set { SetProperty(ref _plafond, value); }
        }

        public float SaisieSecondes
        {
            get => _saisieSecondes;
            set { SetProperty(ref _saisieSecondes, value); }
        }

        public ObservableCollection<Encherir> MaListeSixDernieresEncheres
        {
            get => _maListeSixDernieresEncheres;
            set { SetProperty(ref _maListeSixDernieresEncheres, value); }
        }
        #endregion
        #region methodes
        public void GetTimerRemaining(DateTime param)
        {
            DateTime datefin = param;
            TimeSpan interval = datefin - DateTime.Now;


            Task.Run(() =>
            {
                tmps.Start(interval);
                while (tmps.TempsRestant > TimeSpan.Zero)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetValeurActuelle()
        {
            // lancement d'une task permet de mettre en fils d'attente une tache
            Task.Run(async () =>
            {
                // tant que c'est vrai ( boucle infini )
                while (true)
                {
                    // attribuer à la varibale PrixActuel la valeur de retour de la méthode getActualPrice en fonction de l'enchère voulu
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, MonEnchere.Id.ToString());
                    // nettoie la collclasse ( la vide )
                    Encherir.CollClasse.Clear();
                    // attendre 20 secondes
                    Thread.Sleep(2000);
                }
            });
        }

       

        /// <summary>
        /// affichage dees six derniers enchéreurs
        /// enchère classique
        /// </summary>
        public void SixDernieresEncheres()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    Encherir.CollClasse.Clear();
                    MaListeSixDernieresEncheres = await _apiServices.GetAllAsyncID<Encherir>("api/getLastSixOffer", Encherir.CollClasse, "Id", MonEnchere.Id);

                    Thread.Sleep(10000);
                }
            });
        }
        /// <summary>
        /// automatisation d'une enchère
        /// </summary>
        public void SetEnchereAuto()
        {
            // lancement d'une task
            Task.Run(async () =>
            {
                // recupere la valeur de l'ID du user connecter et le stock pour enregistrer l'utilisateur qui fait une action
                IdUser = await SecureStorage.GetAsync("ID");
                // tant que le temps restant est supérieur a zéro on lance la boucle
                while (tmps.TempsRestant > TimeSpan.Zero)
                {
                    // si le prix actuel est non nul et que l'enchéreur n'est pas vous a lors lance la boucle
                    if (PrixActuel != null && PrixActuel.Id != int.Parse(IdUser))
                    {
                        // création d'une variable qui correspond au prix actuel d'une enchère auquel on ajoute 1
                        float paramValeur = PrixActuel.PrixEnchere + 1;
                        // création d'une variable  qui permet de poster la nouvelle valeur d'une enchérir
                        int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(paramValeur, int.Parse(IdUser), MonEnchere.Id, 0), "api/postEncherir");

                    }
                    // met a jour toutes les 10 secondes
                    Thread.Sleep(10000);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public async void EncherirManuel(float param)
        {
            IdUser = await SecureStorage.GetAsync("ID");


            if (PrixActuel != null)
            {
                int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(param, int.Parse(IdUser), MonEnchere.Id, 0), "api/postEncherir");

            }

        }
        // méthode pour enchére Inverse 

        //méthode pour récupérer le gagant 
        public void GetGagnant(string param)
        {
            bool fin = false;
            Task.Run(async () =>
            {
                while (fin == false)
                {

                    //vérification le temps restant de lenchère, si <= 0 alors on récupère le gagant et l'afficher 
                    if (tmps.TempsRestant <= TimeSpan.Zero) UnUser = await _apiServices.GetOneAsyncID<User>("api/getGagnant", User.CollClasse, param);
                    if (UnUser != null)
                    {
                        User.CollClasse.Clear();
                        VisibleGagnant = true;
                        fin = true;
                    }
                }
            });


        }

        // probléme 2 fois la méthode 
        //méthode pour encherir manuellement 
        public async void EncherirManuellement(float param)
        {

            IdUser = await SecureStorage.GetAsync("ID");
            int resultat = await _apiServices.PostAsync<Encherir>(new Encherir(param, int.Parse(IdUser), MonEnchere.Id, 0, ""), "api/postEncherirInverse");
            tmps.TempsRestant = TimeSpan.Zero;
            VisibleSaisieEnchere = false;
        }


        #endregion

    }
}
