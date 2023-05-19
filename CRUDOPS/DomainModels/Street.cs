using Newtonsoft.Json;

namespace CRUDOPS.DomainModels
{
    public class Street
    {
        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}