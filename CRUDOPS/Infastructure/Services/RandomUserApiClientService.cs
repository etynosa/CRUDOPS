using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Infastructure.Database.Models.CRUDOPS.Models;
using CRUDOPS.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Text.Json.Serialization;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace CRUDOPS.Infastructure.Services
{
    public class RandomUserApiClientService : IRandomUserApiClientService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RandomUserApiClientService> _logger;

        public RandomUserApiClientService(ILogger<RandomUserApiClientService> logger)
        {
            _httpClient = new HttpClient();
            _logger = logger;
        }

        public async Task<List<UserResult>> GetRandomUsers(int page, int resultsPerPage)
        {
            _logger.LogInformation("Fetching random users...");

            var response = await _httpClient.GetAsync($"https://api.randomuser.me/?page={page}&results={resultsPerPage}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<UserResponse>(content);

            return result.Results.Select(r => new UserResult
            {
                Gender = r.Gender,
                Email = r.Email,
                Phone = r.Phone,
                Cell = r.Cell,
                Location = new UserLocation
                {
                    Street = r.Location.Street,
                    City = r.Location.City,
                    State = r.Location.State,
                    Country = r.Location.Country,
                },
                Name = new UserName
                {
                    First = r.Name.First
                    ,
                    Last = r.Name.Last
                },
            }).ToList();

        }

        public async Task<UserResult> GetRandomUserById(string userId)
        {
            _logger.LogInformation("Fetching random user by ID...");

            var response = await _httpClient.GetAsync($"https://api.randomuser.me/?id={userId}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<UserResponse>(content);

            return result.Results.FirstOrDefault();
        }

        public async Task<List<UserResult>> GetRandomUsers(int count)
        {
            _logger.LogInformation($"Fetching {count} random users...");

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://api.randomuser.me/?results={count}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<UserResponse>(content);

                    _logger.LogInformation("Random users fetched successfully.");
                    return result.Results;
                }
                else
                {
                    _logger.LogInformation("Failed to fetch random users.");
                    return null;
                }
            }
        }
    }
}
