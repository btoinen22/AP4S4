using System;
using System.Collections.Generic;
using System.Text;

namespace Encheres.Services
{
    public class ServiceApi
    {
        /// <summary>
        /// permet d'éviter les redondance et minimiser l'utilisation de texte dans le code
        /// </summary>
        public static string
           ErrorTitle = "Error",
           ErrorDescriptionConnexion = "Email ou mot de passe Incorrect",
           ErrorDescriptionInscription = "un des champs entrées est incorrect ou vide",
           ErrorOk = "Ok",
           ErrorCancel = "Retour",
           ApiPostUser = "PostUser",
           ApigetGagnant = "getGagnant",
           ApiGetUserByMailAndPass = "GetUserByMailAndPass",
           ApiEncheresEnCours = "GetEncheresEnCours";

    }
}
