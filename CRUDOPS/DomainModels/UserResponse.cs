using Newtonsoft.Json;
using static CRUDOPS.DomainModels.User;

namespace CRUDOPS.DomainModels
{
    public class UserResponse
    {
        [JsonProperty("results")]
        public List<User> Results { get; set; }
    }
}
