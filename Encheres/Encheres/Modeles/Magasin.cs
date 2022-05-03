using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class Magasin
    {
        #region Attributs
        public static List<Magasin> CollClasse = new List<Magasin>();
        public int id;
        public string nom;
        public string adresse;
        public string ville;
        public int code_postal;
        public string portable;
        public double latitude;
        public double longitude;
        private ObservableCollection<Produit> lesProduits;
        #endregion

        #region Constructeurs

        public Magasin(int id, string nom, string adresse, string ville, int code_postal, string portable, double latitude, ObservableCollection<Produit> lesProduits, double longitude)
        {
            Magasin.CollClasse.Add(this);
            this.id = id;
            this.nom = nom;
            this.adresse = adresse;
            this.ville = ville;
            this.code_postal = code_postal;
            this.portable = portable;
            this.latitude = latitude;
            this.lesProduits = lesProduits;
            this.longitude = longitude;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string Ville { get => ville; set => ville = value; }
        public int Code_postal { get => code_postal; set => code_postal = value; }
        public string Portable { get => portable; set => portable = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }

        #endregion

        #region Methodes

        #endregion
    }
}
