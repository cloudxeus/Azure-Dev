using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using OAuth_2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OAuth_2.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ITokenAcquisition tokenAcquisition;
        public HomeController(ILogger<HomeController> logger, ITokenAcquisition tokenAcquisition)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
        }

        public async Task<IActionResult> Index()
        {


            string[] scopes = new string[] { "api://e68a5a3c-2ad5-4061-8a55-0ea5fad30e2b/Courses.Read" };
            string accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(scopes);

            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var _response = await _client.GetAsync("https://webapi100012.azurewebsites.net/api/Course");

            if (_response.StatusCode == HttpStatusCode.OK)
            {
                var _content = await _response.Content.ReadAsStringAsync();

                ViewBag.content = _content;
            }


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
