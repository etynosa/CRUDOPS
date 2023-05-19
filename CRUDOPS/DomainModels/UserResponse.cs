using Newtonsoft.Json;
using static CRUDOPS.DomainModels.User;

namespace CRUDOPS.DomainModels
{
    public class UserResponse
    {
        public long Id { get; set; }

        [JsonProperty("results")]
        public List<User> Results { get; set; }
    }
}
