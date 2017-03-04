using F8App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F8App.Storage
{
    public interface IDbRepository
    {

        IEnumerable<Report> GetDataReport(DateTime low, DateTime high);
    }
}
