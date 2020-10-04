using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using geo_kids_web_net.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace geo_kids_web_net.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ILogger<CountriesController> _logger;

        private readonly DemoContext _context;

        public CountriesController(ILogger<CountriesController> logger, DemoContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var countries = (from r in _context.Regions
            join c in _context.Continents on r.continent_id equals c.continent_id
            join cr in _context.Countries on r.region_id equals cr.region_id
            orderby c.continent_id ascending, r.region_id, cr.country_id 
            select new{
                cr.country_id,
                cr.region_id,
                c.continent_id,
                cr.country,
                c.continent,
                r.region,
                cr.flag
            }).ToList();

            ViewBag.countries = countries.Select(v =>{
                dynamic eo = new ExpandoObject();
                eo.country_id = v.country_id;
                eo.region_id = v.region_id;
                eo.continent_id = v.continent_id;
                eo.country = v.country;
                eo.continent = v.continent;
                eo.region = v.region;
                eo.flag = v.flag;
                return eo;
            }).ToArray();
            return View();
        }

        public IActionResult Details(int id)
        {
            var region = _context.Regions.Find(id);

            ViewBag.region = region;

            var countries = (from r in _context.Regions
            join c in _context.Continents on r.continent_id equals c.continent_id
            join cr in _context.Countries on r.region_id equals cr.region_id
            where cr.region_id == id
            orderby c.continent_id ascending, r.region_id, cr.country_id 
            select new{
                cr.country_id,
                cr.region_id,
                c.continent_id,
                cr.country,
                c.continent,
                r.region,
                cr.flag
            }).ToList();

            ViewBag.countries = countries.Select(v =>{
                dynamic eo = new ExpandoObject();
                eo.country_id = v.country_id;
                eo.region_id = v.region_id;
                eo.continent_id = v.continent_id;
                eo.country = v.country;
                eo.continent = v.continent;
                eo.region = v.region;
                eo.flag = v.flag;
                return eo;
            }).ToArray();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
