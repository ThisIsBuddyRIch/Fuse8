using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using F8App.Services;
using F8App.Storage;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Net.Http;
using F8App.Models;
// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace F8App.Controllers
{   [Route("api/Reports")]
    public class ReportsController : Controller
    {
        IEmailServices mailService = null;
        IDbRepository db = null;
        IHostingEnvironment env = null;
        IReportService reportService = null;
        public ReportsController(IEmailServices mailService, IDbRepository db, 
                                IHostingEnvironment env, IReportService reportService)
        {
            this.mailService = mailService;
            this.db = db;
            this.env = env;
            this.reportService = reportService;
        }

        // GET: api/values
        [HttpGet]
        [Route("Report")]
        public IEnumerable<Report> Report(DateTime fDate, DateTime sDate, string email)
        {
            var data = db.GetDataReport(fDate, sDate);
           
            var path = $"{env.WebRootPath}\\Reports\\{Guid.NewGuid()}.xlsx";
            reportService.SaveData(data, path);
            mailService.SendMessage(email, path);
            return data.Take(50);
        }

        [HttpGet]
        [Route("Test")]
        public string Test(string id)
        {
            return id;
        }

   

    }
}
