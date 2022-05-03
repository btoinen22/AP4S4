using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class Produit
    {
        #region Attributs
        public static List<Produit> CollClasse = new List<Produit>();
        private int _id;
        private string _nom;
        private string _photo;
        private double _prixreel;
        
        // private ObservableCollection<Magasin> lesMagasins;
        //private ObservableCollection<Encheres> lesEncheres;

        #endregion

        #region Constructeurs

        public Produit(int id, string nom, string photo, double prixreel)
        {
            // ObservableCollection< Magasin > lesMagasins, ObservableCollection<Encheres> lesEncheres
            Produit.CollClasse.Add(this);
            this._id = id;
            this._nom = nom;
            this._photo = photo;
            this._prixreel = prixreel;
            
            //this.lesMagasins = lesMagasins;
            //this.lesEncheres = lesEncheres;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public double Prixreel { get => _prixreel; set => _prixreel = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
