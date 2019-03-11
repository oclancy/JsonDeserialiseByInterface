using Newtonsoft.Json;

namespace JsonDeserialiseByInterface
{
    internal class Scenario
    {
        [JsonConverter(typeof(JobConverter))]
        public Job[] Jobs { get; set; }
    }
}