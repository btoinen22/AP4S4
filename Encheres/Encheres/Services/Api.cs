using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encheres.Services
{
    class Api
    {
        /// <summary>
        /// Cette methode est générique
        /// Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        /// 
        /// </summary>
        /// <typeparam name="T">la classe concernée</typeparam>
        /// <param name="paramUrl">l'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        /// public async void GetListe()
        ///{
        ///MaListeClients = await _apiServices.GetAllAsync<Client>("api/clients", Client.CollClasse);
        ///}
        /// <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync<T>(string paramUrl, List<T> param)
        {
            try
            {
                var clientHttp = new HttpClient();
                var json = await clientHttp.GetStringAsync(Constantes.BaseApiAddress + paramUrl);
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Cette methode est générique
        /// Cette méthode permet de recuperer la liste de toutes les occurences de la table.
        /// </summary>
        /// <typeparam name="T">la classe concernée</typeparam>
        /// <param name="paramUrl">l'adresse de l'API</param>
        /// <param name="param">la collection de classe concernee</param>
        ///
        ///
        /// <returns>la liste des occurences</returns>
        public async Task<ObservableCollection<T>> GetAllAsync2<T>(string paramUrl, List<T> param, object param2)
        {


            try
            {
                string jsonString = @"{'IdTypeEnchere':'" + param2 + "'}";
                JObject getResult = JObject.Parse(jsonString);
                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception)
            {
                return null;
            }
        }

      
        /// <summary>
        /// permet d'envoyer une instance créer ou modifier dans l'api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="paramUrl"></param>
        /// <returns></returns>
        public async Task<int> PostAsync<T>(T param, string paramUrl)
        {

            var jsonstring = JsonConvert.SerializeObject(param);
            int nID;
            try
            {
                var client = new HttpClient();
                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                var result = int.TryParse(content, out nID) ? nID : 0;
                return result;
            }
            catch (Exception ex)
            {
                return 0;
          
            }
        }

        /// <summary>
        /// récupere des donner a partir de l'id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramUrl"></param>
        /// <param name="param"></param>
        /// <param name="paramID"></param>
        /// <returns></returns>
        public async Task<T> GetOneAsyncID<T>(string paramUrl, List<T> param, string paramID)
        {
            try
            {
                string jsonString = @"{'Id':'" + paramID + "'}";
                var getResult = JObject.Parse(jsonString);

                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return res;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// recupere une list de donnée a partir d'une clé et d'un id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paramUrl"></param>
        /// <param name="param"></param>
        /// <param name="cle"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        public async Task<ObservableCollection<T>> GetAllAsyncID<T>(string paramUrl, List<T> param, string cle, int param2)
        {


            try
            {
                string jsonString = @"{'" + cle + "':'" + param2 + "'}";
                JObject getResult = JObject.Parse(jsonString);
                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                JsonConvert.DeserializeObject<List<T>>(json);
                return GestionCollection.GetListes<T>(param);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T> GetOneAsync1<T>(string paramUrl, List<T> param, T paramT)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(paramT);

                var clientHttp = new HttpClient();
                var jsonContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
                return res;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Get One Item whith a list of parameters in the request
        /// This method is generic and work with values that have toString() method
        /// </summary>
        /// <param name="paramUrl"></param>
        /// <param name="parameters">Dictionnary with Key = param name  and Value = param value</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public async Task<T> GetOneAsync<T>(string paramUrl, Dictionary<string, object> parameters)
        {
            try
            {
                JObject getResult = JObject.Parse(GetJsonString(parameters));
                var jsonContent = new StringContent(getResult.ToString(), Encoding.UTF8, "application/json");
                var clientHttp = new HttpClient();
                var response = await clientHttp.PostAsync(Constantes.BaseApiAddress + paramUrl, jsonContent);
                var json = await response.Content.ReadAsStringAsync();
                T res = JsonConvert.DeserializeObject<T>(json);
                return res;
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// Get a Jsonstring for all the parameters with their name and value
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetJsonString(Dictionary<string, object> parameters)
        {
            string jsonString = @"{";
            int i = 0;
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                i++;
                jsonString += @"'" + parameter.Key + "':'" + parameter.Value + "'";
                if (i != parameters.Count)
                    jsonString += @",";
            }
            jsonString += @"}";
            return jsonString;
        }
    }
}
