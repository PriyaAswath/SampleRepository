using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsCSVImportDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var lineNumber = 0;
            string dbname = "C:\\Users\\Kanmani Priya\\Desktop\\CSV-Import-to-Database-Csharp-master\\CSV-Import-to-Database-Csharp-master\\Order.mdf";
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbname + ";Integrated Security=True"))
            {
                conn.Open();

                //Put your file location here:
                using (StreamReader reader = new StreamReader(@"C:\Users\Kanmani Priya\Desktop\CSV-Import-to-Database-Csharp-master\CSV-Import-to-Database-Csharp-master\order.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (lineNumber != 0)
                        {
                            var values = line.Split(',');

                            var sql = "INSERT INTO [Order] VALUES ('" + values[0] + "','" + values[1] + "','" + values[2] + "')";
                            var cmd = new SqlCommand();
                            cmd.CommandText = sql;
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.Connection = conn;
                            cmd.ExecuteNonQuery();
                        }
                        lineNumber++;
                    }
                }
                conn.Close();
            }
            Console.WriteLine("Order Import Complete");
            Console.ReadLine();
        }

     ////   public void readcsvparsing()
     //   {
     //       string[] csvLines = System.IO.File.ReadAllLines(@"C:\Users\Kanmani Priya\Desktop\CSV-Import-to-Database-Csharp-master\CSV-Import-to-Database-Csharp-master\order.csv");

     //       // Create lists with the CSV data
     //       var OrderID = new List<int>();
     //       var OrderName = new List<string>();
     //       var OrderDetails = new List<string>();

     //       // Split each row into column data
     //       for (int i = 1; i < csvLines.Length; i++)
     //       {
     //           string[] rowData = csvLines[i].Split(',');

     //           int id = int.Parse(rowData[0]);
     //           OrderID.Add(id);
     //           OrderName.Add(rowData[1]);
     //           OrderDetails.Add(rowData[2]);
     //       }
     //       Console.ReadKey();
     //   }
       
    }
}
