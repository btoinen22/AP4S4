using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class Enchere
    {
        #region Attributs

        public static List<Enchere> CollClasse = new List<Enchere>(); // création d'une collclasse d'enchère
        private int _id; // variable correspondant a l'id d'une enchère
        private DateTime _datedebut; //variable désignant le début d'une enchère
        private DateTime _datefin; // variable désignant la fin d'une enchère
        private double _prixReserve; // variable désignant le prix de réserve d'une enchère
        private TypeEncheres leTypeEnchere; // variable désignant le type d'enchère correspondant
        private Produit leProduit; // variable désignant le produit mis aux enchères
        private string _tableauFlash;

        public string TableauFlash { get => _tableauFlash; set => _tableauFlash = value; }

        #endregion

        #region Constructeurs

        /// <summary>
        /// associe les éléments obligatoires à la création
        /// d'une instance d'enchère et ajoute l'enchère créer
        /// dans la collclasse
        /// </summary>
        /// <param name="id"></param>
        /// <param name="datedebut"></param>
        /// <param name="datefin"></param>
        /// <param name="prixReserve"></param>
        /// <param name="leTypeEnchere"></param>
        /// <param name="leProduit"></param>
        public Enchere(int id, DateTime datedebut, DateTime datefin, double prixReserve,  TypeEncheres leTypeEnchere = null, Produit leProduit = null)
        {
            Enchere.CollClasse.Add(this);
            this._id = id;
            this._datedebut = datedebut;
            this._datefin = datefin;
            this._prixReserve = prixReserve;
            this.leTypeEnchere = leTypeEnchere;
            this.leProduit = leProduit;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; } //getter stter de l'ID
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; }//getter stter de datedebut
        public DateTime Datefin { get => _datefin; set => _datefin = value; }//getter stter de datefin
        public double PrixReserve { get => _prixReserve; set => _prixReserve = value; }//getter stter du prix de reserve
        public TypeEncheres LeTypeEnchere { get => leTypeEnchere; set => leTypeEnchere = value; }//getter stter du type d'enchere
        public Produit LeProduit { get => leProduit; set => leProduit = value; }//getter stter du produit
        #endregion

    }
}
