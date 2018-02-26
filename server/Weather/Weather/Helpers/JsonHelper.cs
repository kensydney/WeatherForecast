using System.Xml;
using Newtonsoft.Json;

namespace Weather.Helpers
{
    public static class JsonHelper
    {
        public static string processWeatherResult(string results)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(results);
            var json = JsonConvert.SerializeXmlNode(doc);
            return json;
        }
    }
}