using System;
using System.IO;
using Inventory.Classess;
using Newtonsoft.Json;

namespace Inventory.Deserializers
{
    public static class JsonDeserializer<T> where T : class
    {
        private static string[] GetAllJsonFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath, "*.json");
        } 
        
        private static T Deserialize(string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static void DeserializeAndPrintCrossbows()
        {
            var files = GetAllJsonFiles(Path.Combine(Directory.GetCurrentDirectory(), "items/crossbows"));

            foreach (var file in files)
            {
                try
                {
                    string jsonData = File.ReadAllText(file);
                    
                    Crossbow crossbow = JsonDeserializer<Crossbow>.Deserialize(jsonData);
                    
                    Console.WriteLine($"Name: {crossbow.Name}");
                    Console.WriteLine($"Description: {crossbow.Description}");
                    Console.WriteLine($"Weight: {crossbow.Weight}");
                    Console.WriteLine($"Rarity: {crossbow.Rarity}");
                    Console.WriteLine($"Damage: {crossbow.Damage}");
                    Console.WriteLine($"Range: {crossbow.Range}");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in {file}: {ex.Message}");
                }
            }
        }
    }
}