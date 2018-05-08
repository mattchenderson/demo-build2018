using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LinuxAuthDemo
{
    [Route("api/[controller]")]
    public class PhotoController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            //X-MS-CLIENT-PRINCIPAL-NAME 
            //X-MS-CLIENT-PRINCIPAL-ID 
            //X-MS-CLIENT-PRINCIPAL-IDP 
            //X-MS-CLIENT-PRINCIPAL 
            //X-MS-TOKEN-AAD-ACCESS-TOKEN 
            //X-MS-TOKEN-AAD-EXPIRES-ON 
            //X-MS-TOKEN-AAD-REFRESH-TOKEN 
            //X-MS-TOKEN-AAD-ID-TOKEN 
            string appToken = Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"];
            var graphToken = await GetGraphTokenOnBehalfOfUser(appToken);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", graphToken);
            return await client.GetAsync("https://graph.microsoft.com/v1.0/me/");
        }

        private async Task<string> GetGraphTokenOnBehalfOfUser(string appToken)
        {
            var clientId = Environment.GetEnvironmentVariable("WEBSITE_AUTH_CLIENT_ID");
            var clientSecret = Environment.GetEnvironmentVariable("WEBSITE_AUTH_CLIENT_SECRET");

            AuthenticationContext ac;
            AuthenticationResult ar = await ac.AcquireTokenAsync("https://graph.microsoft.com", new ClientCredential(clientId, clientSecret), new UserAssertion(appToken));
            return ar.AccessToken;
        }
    }
}
