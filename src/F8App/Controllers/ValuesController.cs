using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F8App.Services;
using F8App.Storage;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace F8App.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IEmailServices mailService = null;
        IDbRepository db = null;
        public ValuesController(IEmailServices mailService, IDbRepository db)
        {
            this.mailService = mailService;
            this.db = db;
        }

        // GET: api/values
        [HttpGet("val")]
        public IEnumerable<string> Get()
        {
            db.GetDataReport(DateTime.Now, DateTime.Now);
            //mailService.SendMessage(SmtpServerType.GMail, null);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values


        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
