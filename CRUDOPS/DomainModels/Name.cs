using Newtonsoft.Json;

namespace CRUDOPS.DomainModels
{
    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}
