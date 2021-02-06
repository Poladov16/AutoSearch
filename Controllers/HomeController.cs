using JsonButton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JsonButton.Controllers
{
    public class HomeController : Controller
    {
        TestDbEntities entityContext = new TestDbEntities();
        public ActionResult AddUser(Users users)
        {
            return View();
        }
        public ActionResult Countries()
        {
            return View();
        }
        public JsonResult GetCountries(string search)
        {
            List<CountryModel> countries = entityContext.Countries.Where(x => x.NameCountry.Contains(search)).Select(x => new CountryModel
            {
                ID = x.ID,
                NameCountry = x.NameCountry,
                IndexCountry = x.IndexCountry
            }
                ).ToList();
            return new JsonResult { Data = countries, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}