using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Options;
using F8App.Models;

namespace F8App.Storage
{
    public class DbRepository : IDbRepository
    {
        string _connString;


        public DbRepository(IOptions<Options> options)
        {
            _connString = options.Value.ConString;

        }

        public IEnumerable<Report> GetDataReport(DateTime low, DateTime high)
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                var cmd = new SqlCommand(@"SELECT [Order].ID, [Order].OrderDate,[Product].ID as [ProductId], 
                                           [Product].Name, [OrderDetail].Quantity, [OrderDetail].UnitPrice
                                           FROM [Order]
                                           JOIN[OrderDetail]
                                           ON[Order].ID = [OrderDetail].OrderID
                                           JOIN[Product]
                                           On[OrderDetail].ProductID = [Product].ID
                                           WHERE[Order].OrderDate >= @low AND[Order].OrderDate < @high", connection);
                cmd.Parameters.Add(new SqlParameter("low", SqlDbType.DateTime) { Value = low});
                cmd.Parameters.Add(new SqlParameter("high", SqlDbType.DateTime) { Value = high});
                

                var table = new DataTable();
                table.Load(cmd.ExecuteReader());

                var result = new List<Report>();

                foreach (DataRow row in table.Rows)
                {
                    result.Add(new Report
                    {
                        OrderId = row.Field<int>("ID"),
                        OrderDate = row.Field<DateTime?>("OrderDate"),
                        ProductId = row.Field<int>("ProductId"),
                        ProductName = row.Field<string>("Name"),
                        Quantity = row.Field<Int16?>("Quantity"),
                        PriceForUnit = row.Field<decimal?>("UnitPrice")
                    });
                }
                
                return result;

            }
        }
    }
}
