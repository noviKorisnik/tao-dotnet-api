using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace TaoApi.Models
{
    public class TaoSaver
    {
        private static readonly string filename = "Tao.json";
        public static void SaveTao()
        {
            string jsonTao =
                JsonSerializer
                .Serialize(
                    TaoParser.GrabTao(),
                     new JsonSerializerOptions
                     {
                         WriteIndented = true,
                     });
            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                filename
            );
            File.WriteAllText(filePath, jsonTao);
        }
    }
}