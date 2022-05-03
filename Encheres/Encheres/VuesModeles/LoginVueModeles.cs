using Encheres.Modeles;
using Encheres.Services;
using Encheres.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Encheres.VuesModeles
{
    class LoginVueModeles : BaseVueModele
    {
        // elle
        
        #region Attributs
        private readonly ApiAuthentification _apiServicesAuthentification = new ApiAuthentification();
        private string _password;
        private string _email;
        private bool auth = false;

        #endregion

        #region Constructeur
        public LoginVueModeles()
        {
            CommandeButtonAuthentification = new Command(ActionPageAuthentification);
            CommandeButtonRegister = new Command(ActionPageRegister);
        }

        #endregion

        #region Getters/Setters
        public ICommand CommandeButtonAuthentification { get; }
        public ICommand CommandeButtonRegister { get; }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        #endregion

        #region Méthodes
        public async void ActionPageAuthentification()
        {
            User unUser = new User(Email, Password);
            var connexion = await _apiServicesAuthentification.GetAuthAsync(unUser, "api/getUserByMailAndPass");
                if (connexion != default(User))
                {
                    auth = true;
                    await SecureStorage.SetAsync("ID", connexion.Id.ToString());
                    await Application.Current.MainPage.Navigation.PushModalAsync(new AccueilPageVue());

                }
                else
                {
                    auth = false;
                    await Application.Current.MainPage.DisplayAlert("connexion echouée", "Echec", "recommencer");
                }

            
        }
        public async void ActionPageRegister()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterVue());

        }
        #endregion
        
        /*

        // moi

        #region Attributs

        Api _apiService = new Api();

        protected Page Page;
        private string _emailEntry,
            _passwordEntry;

        #endregion

        #region Constructeurs
        public LoginVueModeles()
        {
            CommandBoutonConnexion = new Command(OnSubmit);
            CommandBoutonInscription = new Command(Inscription);
        }
        #endregion

        #region Getters/Setters

        public string EmailEntry
        {
            get
            {
                return _emailEntry;
            }
            set
            {
                SetProperty(ref _emailEntry, value);
            }
        }

        public string PasswordEntry
        {
            get
            {
                return _passwordEntry;
            }
            set
            {
                SetProperty(ref _passwordEntry, value);
            }
        }

        public ICommand CommandBoutonConnexion { get; private set; } // getter/setter du boutton CommandBouttonConnexion
        public ICommand CommandBoutonInscription { get; private set; } // getter/setter du boutton  CommandBouttonInscription

        #endregion

        #region Methodes

        // méthode permettant à un utilisateur de se connecter
        public async void OnSubmit()
        {
            // créer un dictionnaire param
            Dictionary<string, object> param = new Dictionary<string, object>();
            //ajoute la valeur du mail et du mot de passe au dictionnaire
            param.Add("Email", EmailEntry);
            param.Add("Password", PasswordEntry);
            // crée une instance de user à partir des informations récupérer par le mot de passe et le mail à l'aide
            // de la méthode d'API GetUserByMdpAndMail
            User user = await GetUserByMdpAndMail(param);
            if (user == null) // si l'utilisateur n'existe pas affiche un message d'erreur
                await Application.Current.MainPage.DisplayAlert(ServiceApi.ErrorTitle, ServiceApi.ErrorDescriptionConnexion,
                    ServiceApi.ErrorCancel);
            else // sinon renvoi vers la page d'acceuil en tant qu'utilisateur connecté
            {
                Application.Current.MainPage = new AccueilPageVue();
            }
        }


        /// <param name="param"></param> Dictionnaire d'objet initialiser dans le OnSubmit
        /// <returns>récupère les données d'un user à partir de la méthode d'API GetOneAsync</returns>
        async Task<User> GetUserByMdpAndMail(Dictionary<string, object> param)
        {
            return await _apiService.GetOneAsync<User>(ServiceApi.ApiGetUserByMailAndPass, param);
        }

        /// <summary>
        /// redirige vers la page d'inscription
        /// </summary>
        public async void Inscription()
        {
            var route = $"{nameof(RegisterVue)}"; // créer un objet ayant pour valeur la route shell de l'inscription
            await Shell.Current.GoToAsync(route); // redirige vers la valeur d'objet route
        }

        #endregion */
    }
}
