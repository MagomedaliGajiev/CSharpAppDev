
using System.IO;
using System.Text.Json;
using System.Xml;

namespace JsonToXmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("input.json"))
            {
                Console.WriteLine("Файл input.json не найден!");
                return;
            }
            // Read JSON from file
            string json = File.ReadAllText("input.json");

            // Parse JSON
            JsonDocument jsonDoc = JsonDocument.Parse(json);

            // Create XML document
            XmlDocument xmlDoc = new XmlDocument();

            // Create root element
            XmlElement rootElement = xmlDoc.CreateElement("root");
            xmlDoc.AppendChild(rootElement);

            // Convert JSON to XML
            ConvertJsonToXml(jsonDoc.RootElement, rootElement, xmlDoc);

            // Save XML to file
            xmlDoc.Save("output.xml");
        }

        static void ConvertJsonToXml(JsonElement jsonElement, XmlElement parentElement, XmlDocument xmlDoc)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                    // Create element for object
                    XmlElement objectElement = xmlDoc.CreateElement(jsonElement.ValueKind.ToString().ToLower());
                    parentElement.AppendChild(objectElement);

                    // Convert properties to XML elements
                    foreach (JsonProperty property in jsonElement.EnumerateObject())
                    {
                        ConvertJsonToXml(property.Value, objectElement, xmlDoc);
                    }
                    break;

                case JsonValueKind.Array:
                    // Create element for array
                    XmlElement arrayElement = xmlDoc.CreateElement(jsonElement.ValueKind.ToString().ToLower());
                    parentElement.AppendChild(arrayElement);

                    // Convert items to XML elements
                    foreach (JsonElement item in jsonElement.EnumerateArray())
                    {
                        ConvertJsonToXml(item, arrayElement, xmlDoc);
                    }
                    break;

                case JsonValueKind.String:
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                case JsonValueKind.Null:
                    // Create element for value
                    XmlElement valueElement = xmlDoc.CreateElement(jsonElement.ValueKind.ToString().ToLower());
                    valueElement.InnerText = jsonElement.ToString();
                    parentElement.AppendChild(valueElement);
                    break;
            }
        }
    }
}