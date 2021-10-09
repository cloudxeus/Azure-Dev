using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
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
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ITokenAcquisition tokenAcquisition;

        private readonly GraphServiceClient _graphServiceClient;
        public HomeController(ILogger<HomeController> logger, ITokenAcquisition tokenAcquisition, GraphServiceClient graphServiceClient)
        {
            _logger = logger;
            this.tokenAcquisition = tokenAcquisition;
            this._graphServiceClient = graphServiceClient;

        }

        public async Task<IActionResult> Index()
        {

            var user = await _graphServiceClient.Me.Request().GetAsync();
            ViewBag.username = user.DisplayName;
            
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
