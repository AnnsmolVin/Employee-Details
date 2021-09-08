using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;


namespace ConsoleApp1
{



    class Employee : EmployeeDetails
    {
        string validemployeeid, validemployeename;
        string validphoneNumber, validemail, validDOB;
        DateTime validdob;

        public void printmessage()
        {
            Console.WriteLine(getMessage());
        }


        public void Details()
        {

            Console.WriteLine();
            Console.WriteLine("Enter Employee Id:");
            id = Console.ReadLine();
            Console.WriteLine();
            validemployeeid = validateEmployeeId();

            Console.WriteLine("Enter Employee Name:");
            name = Console.ReadLine();
            Console.WriteLine();
            validemployeename = validateEmployeeName();

            Console.WriteLine("Enter Employee Phone no:");
            phno = Console.ReadLine();
            Console.WriteLine();
            validphoneNumber = validateNumber(phno);

        }

        public void Details(int i)
        {
            Console.WriteLine("Enter Employee Email:");
            email = Console.ReadLine();
            Console.WriteLine();
            validemail = validateEmail(email);

            Console.WriteLine("Enter Employee Date of Birth:");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();
            validdob = validateDateOfBirth(dob);
            validDOB = validdob.ToString("dd/MM/yyyy");

            Console.WriteLine("Employee Id :" + validemployeeid);
            Console.WriteLine("Employee Name :" + validemployeename);
            Console.WriteLine("Employee phone Number :" + validphoneNumber);
            Console.WriteLine("Employee Email Id :" + validemail);
            Console.WriteLine("Employee Date of Birth :" + validdob);
        }

        public static string validateEmployeeId()
        {

            string str1 = "0000";
            int flag = 1;
            string employeeid = id;
            while (flag == 1)
            {

                int len = employeeid.Length;
                String str2 = employeeid.Substring(3);

                if (len == 7 && !String.IsNullOrEmpty(employeeid) && (employeeid.StartsWith("ace") || employeeid.StartsWith("ACE") == true))
                {
                    flag = 0;
                }
                else
                    flag = 1;

                if (flag == 0)
                {
                    for (int i = 3; i < 7; i++)
                    {
                        if (!Char.IsDigit(employeeid[i]))
                        {
                            flag = 1;
                            break;
                        }
                    }
                }
                if (flag == 1 || Equals(str1, str2) == true)
                {
                    Console.WriteLine("INVALID ID!!");
                    Console.WriteLine("Employee Id should start with 'ace' or 'ACE' followed by 4 digits");
                    Console.WriteLine();
                    Console.WriteLine("Enter a valid Employee Id:");
                    employeeid = Console.ReadLine();
                    Console.WriteLine();

                }
                else
                {
                    return employeeid;
                }

            }
            return employeeid;
        }

        public static string validateEmployeeName()
        {
            int flag = 0;


            String employeename = name;
            do
            {
                int length = employeename.Length;
                String nameasuppercase = employeename.ToUpper();
                char[] data = nameasuppercase.ToCharArray();
                for (int k = 0; k < length; k++)
                {
                    int asciinum = (int)data[k];
                    if (asciinum != 32)
                    {
                        if (asciinum < 65 || asciinum > 90)
                        {
                            flag = 0;
                            Console.WriteLine("INVALID NAME!!");
                            Console.WriteLine("SPECIAL CHARACTERS ARE NOT ALLOWDED");
                            Console.WriteLine();
                            Console.WriteLine("Enter a valid  Employee Name:");
                            employeename = Console.ReadLine();
                            Console.WriteLine();

                        }
                        else
                            flag = 1;
                    }

                }
                if (flag == 1)
                {

                    return employeename;
                }


            } while (flag == 0);
            return employeename;
        }


        public static string validateNumber(string phoneNumber)
        {
            int flag = 0;

            do
            {
                Regex rgx = new Regex(@"^[5-9][0-9]{9}$");

                if (rgx.IsMatch(phoneNumber))
                {

                    return phoneNumber;


                }
                else
                {
                    flag = 0;
                    Console.WriteLine("INVALID PHONE NUMBER!!");
                    Console.WriteLine("Phone no must have 10 digits and should start with a number from 5-9");
                    Console.WriteLine();
                    Console.WriteLine("Enter a valid Phone no:");
                    phoneNumber = Console.ReadLine();
                    Console.WriteLine();

                }
            } while (flag == 0);
            return phoneNumber;
        }

        public static string validateEmail(string email)
        {
            int flag;

            do
            {

                Regex rgx = new Regex("^[A-Za-z0-9+_.-]+@[A-Za-z]+.+[A-za-z]+$");

                if (rgx.IsMatch(email))
                {

                    return email;
                }
                else
                {
                    flag = 0;
                    Console.WriteLine("INVALID EMAIL!!");
                    Console.WriteLine("Email should be in the format abc@xyz.com");
                    Console.WriteLine();
                    Console.WriteLine("Enter a valid Email:");
                    email = Console.ReadLine();
                    Console.WriteLine();
                }
            } while (flag == 0);
            return email;
        }
        public static DateTime validateDateOfBirth(DateTime dob)
        {

            int flag = 0;
            while (flag == 0)
            {


                DateTime now = DateTime.Today;
                TimeSpan a = DateTime.Today - dob;
                int age = (a.Days / 365);
                if (18 < age && age < 60)
                {

                    flag = 1;
                    return dob;
                }
                else
                {
                    flag = 0;
                    Console.WriteLine("INVALID DATE OF BIRTH!!");
                    Console.WriteLine("Age shoud be between 18-60");
                    Console.WriteLine();
                    Console.WriteLine("Enter a valid Date of Birth:");
                    dob = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();
                }


            } while (flag == 0) ;

            return dob;

        }
        public void printmessage(int j)
        {
            Console.WriteLine();
            Console.WriteLine("EMPLOYEE DETAILS SUBMITTED SUCCESSFULLY");
            Console.WriteLine();

        }

        public void databaseconnection()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                string connString;
                connString = ConfigurationManager.ConnectionStrings["DbConn"].ConnectionString;
                SqlConnection sqlConnection = new SqlConnection(connString);


                string query = "INSERT INTO EMPLOYEE_DETAILS VALUES('" + validemployeeid + "','" + validemployeename + "','" + validphoneNumber + "','" + validemail + "','" + validDOB + "')";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                Console.WriteLine("VALUES ARE INSERTED INTO  THE DATABASE");

                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                Console.ReadLine();

            }
        }
    }

}

