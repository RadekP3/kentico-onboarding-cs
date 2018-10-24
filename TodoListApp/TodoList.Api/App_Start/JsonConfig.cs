using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace TodoList.Api
{
    public class JsonConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}