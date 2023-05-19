using Newtonsoft.Json;

namespace CRUDOPS.DomainModels
{
    public class User
    {
        public long Id { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }
    }
}

