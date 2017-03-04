using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F8App.Models;
using System.Text;
using ClosedXML.Excel;
using System.Threading;
using System.Globalization;

namespace F8App.Services
{
    public class ReportService : IReportService
    {
        public void SaveData(IEnumerable<Report> data, string pathToSave)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            try
            {
                XLWorkbook workbook = new XLWorkbook();
              
              

                var report = workbook.AddWorksheet("Report");
                //У ребят в библиотеке баг с парсингом decimal типа, костылируется вот так
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                var firsRow = report.Row(1);
                firsRow.Cell(1).Value = "ID";
                firsRow.Cell(2).Value = "Date";
                firsRow.Cell(3).Value = "Quantity";
                firsRow.Cell(4).Value = "Price";
                firsRow.Cell(5).Value = "ProductName";
                firsRow.Cell(6).Value = "Vendor Code";
                firsRow.Cell(7).Value = "Total";

                int j = 2;

                foreach (var item in data)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendFormat("=C{0}*D{0}", j);
                    var row = report.Row(j);

                    row.Cell(1).Value = item.OrderId;
                    row.Cell(2).Value = item.OrderDate.Value.ToShortDateString();

                    row.Cell(3).Value = item.Quantity;
                    row.Cell(4).Value = item.PriceForUnit;

                    row.Cell(4).DataType = XLCellValues.Number;

                    row.Cell(5).Value = item.ProductName;
                    row.Cell(6).Value = item.ProductId;


                    row.Cell(7).FormulaA1 = builder.ToString();
                    j++;
                }


                report.Columns().ForEach(x => x.AdjustToContents());
                workbook.SaveAs(pathToSave);
                
            }
            finally { Thread.CurrentThread.CurrentCulture = currentCulture; }
            
        }
    }

}
