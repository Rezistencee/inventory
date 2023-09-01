using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Inventory.Deserializers
{
    public static class XmlDeserializer<T> where T : class
    {
        private static T Deserialize(string xmlData)
        {
            using (StringReader reader = new StringReader(xmlData))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return serializer.Deserialize(reader) as T;
            }
        }
        
        public static T[] DeserializeAll(string directoryPath)
        {
            var files = Directory.GetFiles(directoryPath, "*.xml");
            var deserializeItems = new List<T>();

            foreach (var file in files)
            {
                try
                {
                    string xmlData = File.ReadAllText(file);
                    T item = Deserialize(xmlData);
                    deserializeItems.Add(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in {file}: {ex.Message}");
                }
            }

            return deserializeItems.ToArray();
        }
    }
}