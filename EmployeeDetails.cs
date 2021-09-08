using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EmployeeDetails
    {



        public static string id, name, phno, email, dob;


        static string printmessage = "ENTER THE DETAILS OF THE EMPLOYEE:";
        public static void setMessage(string msg)
        {
            printmessage = msg;
        }



        public static string getMessage()
        {
            return printmessage;
        }

    }
}
