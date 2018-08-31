using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
namespace WebApi.Controllers
{
    //[Authorize]
    
    public class ValuesController : ApiController
    {
        // GET api/values
        
        public List<Credit> Get()
        {
            return ConsumeJSON();
        }
        public List<Credit> ConsumeJSON()
        {
            List<Credit> creditList = new List<Credit>();
            // serialize JSON to a string and then write string to a file
            var jsonText = System.IO.File.ReadAllText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledata.txt");
            var credits = JsonConvert.DeserializeObject<IList<Credit>>(jsonText);
            return creditList;

        }
        // GET api/values/5
        
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Route("api/values/6")]
        public IHttpActionResult Post([FromBody]string value)
        {
            List<Credit> creditMaster = new List<Credit>();
            creditMaster = ConsumeJSON();

            Credit addCredit = new Credit()
            {
                Id = "anand-egjwg-8990-705a962fb048",
                ApplicationId = 456299,
                Type = "Debit",
                Summary = "Payment",
                Amount = 52.92,
                PostingDate = DateTime.Now,
                IsCleared = true,
                ClearedDate = DateTime.Now
            };
            
            creditMaster.Add(addCredit);
            System.IO.File.WriteAllText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledataCreate.json", JsonConvert.SerializeObject(creditMaster));

            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledataCreate.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                // serializer.Serialize(file, movie);
            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        [Route("api/values/5")]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            List<Credit> creditMaster = new List<Credit>();
            creditMaster = ConsumeJSON();
            Credit cr = new Credit();
            cr = (from row in creditMaster where row.Id == "0f6eb0a1-3e48-49b6-8990-705a962fb048" select row).FirstOrDefault();
            //Credit addCredit = new Credit()
            //{
            //    Id = "anand-egjwg-8990-705a962fb048",
            //    ApplicationId = 456299,
            //    Type = "Debit",
            //    Summary = "Payment",
            //    Amount = 52.92,
            //    PostingDate = DateTime.Now,
            //    IsCleared = true,
            //    ClearedDate = DateTime.Now
            //};
            cr.Id = "anand-egjwg-8990-705a962fb048";
            creditMaster.Add(cr);
            System.IO.File.WriteAllText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledataCreate.json", JsonConvert.SerializeObject(creditMaster));

            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledataCreate.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                // serializer.Serialize(file, movie);
            }
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete]
        
        public void Delete(int id)
        {
            List<Credit> creditMaster = new List<Credit>();
            creditMaster = ConsumeJSON();
            Credit cr = new Credit();
            cr = (from row in creditMaster where row.Id == "0f6eb0a1-3e48-49b6-8990-705a962fb048" select row).FirstOrDefault();            
            
            creditMaster.Remove(cr);
            System.IO.File.WriteAllText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledataCreate.json", JsonConvert.SerializeObject(creditMaster));

            // serialize JSON directly to a file
            using (StreamWriter file = System.IO.File.CreateText(@"C:\Users\Administrator\Documents\Visual Studio 2015\Projects\WebApi\sampledataCreate.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                // serializer.Serialize(file, movie);
            }
        }
    }
}
