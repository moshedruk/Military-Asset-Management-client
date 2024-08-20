using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Military_Asset_Management_client.Models;
using Newtonsoft.Json;

namespace Military_Asset_Management_client.Controllers
{
    public class VehicleController : Controller
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        // GET: VehicleController1
        public async Task<IActionResult> Index()
        {
            var res = await _httpClient.GetStringAsync("http://localhost:5062/api/Assets/vehicle");
            var vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(res);
            return View(vehicles);
        }

        // GET: VehicleController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleController1/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> postCreate(Vehicle New_vehicle)
        {
            string json = JsonConvert.SerializeObject(New_vehicle);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5062/api/Assets/vehicle", httpContent);
            return RedirectToAction("Index");

        }

        // POST: VehicleController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
