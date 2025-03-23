using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.JsonParser
{
    public static class JsonParserFactory
    {
        private static IJsonParser? instance;
        public static IJsonParser GetInstance()
        {
            if (instance == null)
            {
                instance = new JsonParser();
            }
                return instance;
        }
    }
}
