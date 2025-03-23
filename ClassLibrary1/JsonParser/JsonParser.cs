using ClassLibrary1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.JsonParser
{
    internal class JsonParser : IJsonParser
    {

        public IList<T> ParseMatchModel<T>(string jsonURL) //one parser for all models
        {
            var webRequest = WebRequest.Create(jsonURL) as HttpWebRequest;
            if (webRequest == null)
            {
                throw new InvalidExpressionException("The web request URL is invalid.");
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var MatchesAsJson = sr.ReadToEnd();
                    var matches = JsonConvert.DeserializeObject<List<T>>(MatchesAsJson);
                    //matches.Sort((x, y) => x.Id.CompareTo(y.Id)); //simple sort
                    //matches.ForEach(Console.WriteLine);
                    return new List<T>(matches);
                }
            }
        }

        public IList<T> ParseMatchModelFromFile<T>(string jsonPATH) //one parser for all models
        {
            using (StreamReader sr = new StreamReader(jsonPATH))
            {
                var MatchesAsJson = sr.ReadToEnd();
                var matches = JsonConvert.DeserializeObject<List<T>>(MatchesAsJson);
                return new List<T>(matches);
            }
        }

        public async Task<IList<T>> ParseMatchModelAsync<T>(string jsonURL)
        {
            var webRequest = WebRequest.Create(jsonURL) as HttpWebRequest;
            if (webRequest == null)
            {
                throw new InvalidExpressionException("The web request URL is invalid.");
            }

            webRequest.ContentType = "application/json";
            webRequest.UserAgent = "Nothing";

            using (var s = webRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(s))
                {
                    var MatchesAsJson = sr.ReadToEnd();
                    var matches = JsonConvert.DeserializeObject<List<T>>(MatchesAsJson);
                    //matches.Sort((x, y) => x.Id.CompareTo(y.Id)); //simple sort
                    //matches.ForEach(Console.WriteLine);
                    return new List<T>(matches);
                }
            }
        }
    }
}
