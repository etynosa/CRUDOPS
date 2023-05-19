using CRUDOPS.Infastructure.Database.Models;
using CRUDOPS.Infastructure.Services;
using CRUDOPS.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOPS.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRandomUserApiClientService _randomUserApiClientService;
        private readonly ILogger _logger;

        public StudentController(IRandomUserApiClientService randomUserApiClientService, ILogger<StudentController> logger)
        {
            _randomUserApiClientService = randomUserApiClientService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int page = 1, int resultsPerPage = 10)
        {
            _logger.LogInformation($"Fetching users on page {page}, results per page: {resultsPerPage}...");

            var users = await _randomUserApiClientService.GetRandomUsers(page, resultsPerPage);

            _logger.LogInformation($"Fetched {users.Count} users.");

            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            _logger.LogInformation($"Fetching user details for ID: {id}...");

            var user = await _randomUserApiClientService.GetRandomUserById(id);

            if (user == null)
            {
                _logger.LogInformation($"User with ID {id} not found.");
                return NotFound();
            }

            _logger.LogInformation($"Fetched user details for ID: {id}.");

            return View(user);
        }
    }

}
