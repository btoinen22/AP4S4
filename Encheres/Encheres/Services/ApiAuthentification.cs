using Encheres.Modeles;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encheres.Services
{
    class ApiAuthentification
    {
        #region Attributs 
        #endregion
        #region Methodes

        /// <summary>
        /// permet à l'authentification d'un user a partir de son email et de son mdp
        /// </summary>
        /// <param name="unUser"></param>
        /// <param name="paramUrl"></param>
        /// <returns></returns>
        public async Task<User> GetAuthAsync(User unUser, string paramUrl)
        {
            string jsonString = @"{'Email':'" + unUser.Email + "', 'Password':'" + unUser.Password+ "'}";
            var getResult = JObject.Parse(jsonString);
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                User res = JsonConvert.DeserializeObject<User>(content);
                return res;
            }
            catch (Exception ex)
            {
                return default(User);
            }
        }
        #endregion
    }
}
