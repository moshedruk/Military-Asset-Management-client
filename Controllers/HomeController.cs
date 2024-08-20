using Microsoft.AspNetCore.Mvc;
using Military_Asset_Management_client.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace Military_Asset_Management_client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly HttpClient _httpClient = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;           
        }
       
        public async Task <IActionResult> Index()
        {            
            var res = await _httpClient.GetStringAsync("http://localhost:5062/api/Assets/vehicle");
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(res);            
            return View(vehicles);
        }
        public IActionResult Create() 
        {
            return View();
            
        }
        public async Task <IActionResult> postCreate(Vehicle New_vehicle ) 
        {
            string json = JsonConvert.SerializeObject(New_vehicle);   

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5062/api/Assets/vehicle", httpContent);
            return RedirectToAction("Index");
            
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
