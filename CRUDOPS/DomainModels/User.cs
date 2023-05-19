using Newtonsoft.Json;

namespace CRUDOPS.DomainModels
{
    public class User
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("dob")]
        public DateOfBirth Dob { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cell")]
        public string Cell { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("picture")]
        public Picture Picture { get; set; }
    }
}

