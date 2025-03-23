using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Exceptions
{
    public class ConfigurationMissingException : Exception
    {
        public ConfigurationMissingException() :this("Missing configuration data")
        {
        }

        public ConfigurationMissingException(string? message) : base(message)
        {
        }
    }
}
