using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee();
            employee.printmessage();
            employee.Details();
            employee.Details(1);
            employee.printmessage(1);
            employee.databaseconnection();
            Console.ReadLine();
            employee.databaseconnection();
            Console.ReadLine();
        }
    }
}
