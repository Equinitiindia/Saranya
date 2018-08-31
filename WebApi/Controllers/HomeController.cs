using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Net;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ConsumeJSON();
            return View();
        }

        public void ConsumeJSON()
        {

            
            List<Credit> creditList = new List<Credit>();
            // serialize JSON to a string and then write string to a file
            var jsonText =System.IO.File.ReadAllText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledata.txt");
            var sponsors = JsonConvert.DeserializeObject<IList<Credit>>(jsonText);
            

           
            
        }
    
    }
}
