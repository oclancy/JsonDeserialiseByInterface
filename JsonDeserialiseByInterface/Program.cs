using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonDeserialiseByInterface
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            if (File.Exists(args[0]))
            {
                using (var textReader = new StreamReader(args[0]))
                {
                    try
                    {
                        var json = await textReader.ReadToEndAsync();
                        JsonConvert.DeserializeObject<Scenario>(json);

                        Console.Write(JsonConvert.SerializeObject(json));
                    }
                    catch(JsonSerializationException ex)
                    {
                        Console.WriteLine("JSON error" + ex.Message);
                    }
                }
                Console.ReadKey();                
            }
        }
    }
}
