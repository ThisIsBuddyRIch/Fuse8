using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F8App.Models;

namespace F8App.Services
{
    public interface IReportService
    {
        void SaveData(IEnumerable<Report> data, string pathToSave);
                 
    }
}
