using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomUrlsController : ControllerBase
    {
        
        private static readonly string[] UrlDomains = { "https://example.com/", "https://mydomain.com/", "https://someurl.net/" };

        private readonly ILogger<RandomUrlsController> _logger;

        public RandomUrlsController(ILogger<RandomUrlsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            if (data == null || !data.ContainsKey("githubRepo") || !data.ContainsKey("key"))
            {
                return BadRequest("JSON body must contain 'githubRepo' and 'key' properties.");
            }

            string githubRepo = data.GetValue("githubRepo").ToString();
            string key = data.GetValue("key").ToString();

            string prodUrl = GetRandomUrl();
            string stgUrl = GetRandomUrl();
            string deploymentUrl = GetRandomUrl();

            var response = new JObject
            {
                { "prodUrl", prodUrl },
                { "stgUrl", stgUrl },
                { "deploymentUrl", deploymentUrl }
            };

            return Ok(response);
        }

        private string GetRandomUrl()
        {
            Random random = new Random();
            string domain = UrlDomains[random.Next(UrlDomains.Length)];
            string path = Path.GetRandomFileName().Replace(".", "");

            return domain + path;
        }
        
    }
}

/*

This code defines a RandomUrlsController class that contains an HTTP POST method called Post. 
This method takes a JSON body that contains a githubRepo and a key, generates three random URLs
using the GetRandomUrl method, and returns them as a JSON response with the property names prodUrl, stgUrl, and deploymentUrl.

Note that this code uses the JObject class from the Newtonsoft.Json.Linq namespace to parse and create JSON objects. 
Also, the GetRandomUrl method generates a random URL by selecting a random domain from the UrlDomains array and appending a random path generated using the Path.GetRandomFileName method.
 You can modify these methods to generate URLs according to your requirements.
 
 */