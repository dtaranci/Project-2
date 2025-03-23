using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;
namespace ClassLibrary1.JsonParser
{
    public interface IJsonParser
    {
        IList<T> ParseMatchModel<T>(string jsonURL);
        IList<T> ParseMatchModelFromFile<T>(string jsonPATH);
        Task<IList<T>> ParseMatchModelAsync<T>(string json);
    }
}
