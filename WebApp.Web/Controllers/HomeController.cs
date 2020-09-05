using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApp.Web.Models;

namespace WebApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration _configuration { get; }
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View(new InfoView()
            {
                OSVersion = System.Environment.OSVersion.ToString(),
                FrameworkName = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName,
                Data = DateTime.Now,
                VariavelAmbienteManual = System.Environment.GetEnvironmentVariable("INFO_VAR"),
                VariavelAmbienteConfiguration = _configuration.GetSection("CHAVES").GetValue<string>("VAR")
            });
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

    public class InfoView 
    {
        public string OSVersion { get; internal set; }
        public string FrameworkName { get; internal set; }
        public DateTime Data { get; internal set; }
        public string VariavelAmbienteManual { get; internal set; }
        public string VariavelAmbienteConfiguration { get; internal set; }
    }
}
