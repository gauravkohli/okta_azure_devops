using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace okta_aspnetcore_mvc_example.Controllers
{
    public class UserController : Controller
    {

        private OktaClient oktaClient;

        public UserController(IConfiguration configuration)
        {

            oktaClient = new OktaClient(new OktaClientConfiguration
            {
                OktaDomain = configuration["Okta:OktaDomain"],
                Token = configuration["Okta:ApiToken"]
            });


        }

        [Authorize]
        public async Task<IActionResult> ListUsers()
        {
            var allUsers = await oktaClient.Users.ToArrayAsync();
            return View(allUsers);
        }

    }
}