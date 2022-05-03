using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace Encheres.Services
{
    class GestionCollection
    {
        /// <summary>
        /// recupere les valeurs d'une liste choisis
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public static ObservableCollection<T> GetListes<T>(List<T> paramList)
        {
            ObservableCollection<T> resultat = new ObservableCollection<T>();

            foreach (T leParam in paramList)
            {
                resultat.Add(leParam);
            }

            return resultat;
        }

        /// <summary>
        /// recupere un objet a partir de son ID 
        /// dans une liste choisis
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public static T GetObjet<T>(List<T> param, int param2)

        {
            T result = default(T);
            foreach (T unparam in param)
            {
                PropertyInfo x = (unparam.GetType().GetProperty("id"));
                int nbi = Convert.ToInt32(x.GetValue(unparam));
                if (nbi == Convert.ToInt32(param2))
                {
                    result = unparam;
                    break;
                }
            }
            return result;
        }
    }
}
