using Microsoft.AspNetCore.Mvc;
using WebAppNew.Models;

namespace WebAppNew.Controllers
{
    public class CountryController : Controller
    {
        private readonly WebAppNewEntity _context;
        public CountryController(WebAppNewEntity context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Country> list = _context.Countries.ToList();

            return View(list);
        }
        public IActionResult DistrictIndex()
        {

            List<District> lists = _context.Districts.ToList();
            return View(lists);
        }
        public IActionResult CreateCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCountry(Country newcountry) {
        _context.Countries.Add(newcountry);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
        public IActionResult CreateDistrict()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDistrict(District newdistrict)
        {
            
            _context.Districts.Add(newdistrict);
            _context.SaveChanges();
            return RedirectToAction("DistrictIndex");
           
        }
        public IActionResult DeleteDistrict(int id)
        {
            var district = _context.Districts.Where(x => x.ID == id).FirstOrDefault();
            _context.Districts.Remove(district);
            _context.SaveChanges();
            return RedirectToAction("DistrictIndex");
        }
        public IActionResult Edit(int id)
        {
            var district = _context.Districts.Where(x => x.ID == id).FirstOrDefault();
            return View(district);

        }
        [HttpPost]
        public IActionResult Edit(int id, District editedDistrict)
        {
            var district = _context.Districts.FirstOrDefault(x => x.ID == id);

            if (district == null)
            {
                
                return NotFound();
            }

            district.ID = editedDistrict.ID;
            district.DistrictName = editedDistrict.DistrictName;
            district.CountryName = editedDistrict.CountryName;
            _context.SaveChanges();  
            return RedirectToAction("DistrictIndex");
        }
 }
}
