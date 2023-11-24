using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using PlantBuddy.Data;
using PlantBuddy.Models;

namespace PlantBuddy.Controllers
{
    public class WaterHistoryController : Controller
    {
        private readonly PlantBuddy.Data.PlantBuddyContext _context;

        public WaterHistoryController(PlantBuddyContext context)
        {
            _context = context;
        }

        // GET: WaterHistoryController
        public string Index()
        {
            return "This is my default action...";
        }

        public class WaterHistoryControllerDetail
        {
            public string date { get; set; }
            public string value { get; set; }
        }

        // GET: WaterHistoryController/Details/5
        public JsonResult Details(int id)
        {
            var waterRecords = _context.WaterHistories.AsNoTracking()
                .Where(x => x.PlantId == id)
                .OrderBy(x => x.WateredOn)
                .Select(x => new WaterHistoryControllerDetail
                {
                    date = x.WateredOn.ToString("yyyy-M-dd"),
                    value = "1"
                });

            return new JsonResult(waterRecords);
        }

        // GET: WaterHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WaterHistoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var waterHistory = new WaterHistory()
            {
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                //PlantId = id,
                //WateredOn = DateWatered
            };

            // call this method from an ajax call
            // ahve the payload be the id of the plant
            // the time that was watered on
            // and the page that the user has clicked the button
            // so that we return them to the og page.

            
            try
            {
                _context.WaterHistories.Add(waterHistory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WaterHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WaterHistoryController/Edit/5
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

        // GET: WaterHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WaterHistoryController/Delete/5
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
