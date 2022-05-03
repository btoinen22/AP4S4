using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class User
    {
        #region Attributs
        public static List<User> CollClasse = new List<User>();
        private int id;
        private string _email;
        private string _photo;
        private string _password;
        private string _pseudo;
        //private ObservableCollection<Encherir> lesEncherir;




        #endregion

        #region Constructeurs
        public User(string email, string photo, string password, string pseudo)
        {
            Email = email;
            Photo = photo;
            Password = password;
            Pseudo = pseudo;
        }
        public User(string email,string password)
        {
            Email = email;
            Password = password;
        }
        public User()
        {

        }
        #endregion

        #region Getters/Setters
        public int Id { get => id; set => id = value; }
        public string Email { get => _email; set => _email = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public string Password { get => _password; set => _password = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        //public ObservableCollection<Encherir> LesEncherir { get => lesEncherir; set => lesEncherir = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
