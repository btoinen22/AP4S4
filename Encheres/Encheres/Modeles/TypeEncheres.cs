using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Encheres.Modeles
{
    public class TypeEncheres
    {
        #region Attributs
        public static List<TypeEncheres> CollClasse = new List<TypeEncheres>();
        private int id;
        private string nom;
        private ObservableCollection<Enchere> lesEncheres;

        #endregion

        #region Constructeurs

        public TypeEncheres(int id, string nom, ObservableCollection<Enchere> lesEncheres)
        {
            TypeEncheres.CollClasse.Add(this);
            this.id = id;
            this.nom = nom;
            this.lesEncheres = lesEncheres;
        }

        #endregion

        #region Getters/Setters
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
