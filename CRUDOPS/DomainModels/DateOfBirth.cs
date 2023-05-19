using Newtonsoft.Json;

namespace CRUDOPS.DomainModels
{
    public class DateOfBirth
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}