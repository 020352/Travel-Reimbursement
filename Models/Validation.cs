using System.Text.RegularExpressions;
using Webapplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
namespace Webapplication.Models
{
    public class Validation
    {
        static Dictionary<string, string[]> employeedata = new Dictionary<string, string[]>();

        static Validation()
        {
            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1443;Initial Catalog=MVCApplication;Integrated Security=true"))
            {
                connection.Open();
                Console.WriteLine("Connection Established");
                SqlCommand selectcommand= new SqlCommand("SELECT * FROM signupdetails",connection);
                SqlDataReader readdata= selectcommand.ExecuteReader();
                while(readdata.Read())
                {
                    string[] userdata= new string[3];
                    userdata[0]= readdata["Password"].ToString();
                    userdata[1]=readdata["Emailaddress"].ToString();
                    userdata[2]=readdata["Employeename"].ToString();
                    employeedata.Add(readdata["EmployeeId"].ToString(),userdata);
                }
            }
        }
        public  static int validateDetails(SignupAccount signupaccount)
        {
            string idpattern="^[A-Z]{3}[0-9]{5}$";
            string userpattern="^[a-zA-Z]*$";
            string passpattern="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
            Regex rg1= new Regex(idpattern);
            Regex rg2= new Regex(passpattern);
            Regex rg3= new Regex(userpattern);
            string id = signupaccount.EmployeeID;
            string name = signupaccount.EmployeeName;
            string email = signupaccount.Emailaddress;
            string password = signupaccount.Password;
            // Console.WriteLine(signupaccount.EmployeeID);
            // Console.WriteLine("hello");
            if(rg1.IsMatch(signupaccount.EmployeeID.ToString()))
            {
                if(rg2.IsMatch(signupaccount.Password) && rg3.IsMatch(signupaccount.EmployeeName))
                {
                    if(string.Equals(signupaccount.Password,signupaccount.ConfirmPassword))
                    {
                        foreach(var checkdata in employeedata)
                        {
                            if(string.Equals(checkdata.Key,signupaccount.EmployeeID)|| string.Equals(signupaccount.Emailaddress,checkdata.Value[1]))
                            {
                                Console.WriteLine("User already exists");
                                return 5;
                            }
                        }
                            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1443; Initial Catalog=MVCApplication; Integrated Security=true"))
                            {
                                connection.Open();
                                SqlCommand insertCommand= new SqlCommand("INSERT INTO signupdetails VALUES(@v1,@v2,@v3,@v4)",connection);
                                insertCommand.Parameters.Add("@v1",SqlDbType.VarChar,50,"EmployeeId").Value=signupaccount.EmployeeID;
                                insertCommand.Parameters.Add("@v2",SqlDbType.VarChar,50,"Employename").Value=signupaccount.EmployeeName;
                                insertCommand.Parameters.Add("@v3",SqlDbType.VarChar,50,"Emailaddress").Value=signupaccount.Emailaddress;
                                insertCommand.Parameters.Add("@v4",SqlDbType.VarChar,50,"Password").Value=signupaccount.Password;
                                insertCommand.ExecuteNonQuery();
                                string[] userdata= new string[3];
                                userdata[0]= password;
                                userdata[1]=email;
                                userdata[2]=name;
                                employeedata.Add(id,userdata);
                            }
                            return 1;
                    }
                    else
                    {
                        Console.WriteLine("Password mismatch");  
                        return 2;
                    } 
                }   
                else
                {
                    Console.WriteLine("Invalid username or password");
                    return 3;
                }  
            }
            else
            {
                Console.WriteLine("Invalid ID");
                return 4;
            }
        }
        public static  int validateLogin(Account account)
        {
            
                foreach(var checkdata in employeedata)
                {
                    if(string.Equals(account.EmployeeID,"ADM00882"))
                    {
                        if(string.Equals(account.Password,checkdata.Value[0]))
                         return 4;
                    }
                    
                    if(string.Equals(checkdata.Key,account.EmployeeID))
                    {
                        if( string.Equals(account.Password,checkdata.Value[0]))
                            return 1; 
                        else
                            return 2;
                    }  
                }
            return 3;
        }
        public static int changePassword(ForgotPassword forgotpassword)
        {
            string id=forgotpassword.EmployeeID;
            string email=forgotpassword.Emailaddress;
            string password=forgotpassword.Password;
            string confirmpassword=forgotpassword.ConfirmPassword;
            Console.WriteLine(email+password);
            string passpattern="^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
             Regex rg1= new Regex(passpattern);
             foreach(KeyValuePair<string, string[]> checkdata in employeedata)
             {
                if(email.ToString()==checkdata.Value[1].ToString() && string.Equals(id,checkdata.Key))
                {
                            using(SqlConnection connection = new SqlConnection("Data Source=ASPIRE1443; Initial Catalog=MVCApplication; Integrated Security=true"))
                            {
                                connection.Open();
                                Console.WriteLine("update connection establsihed");
                                SqlCommand updatecommand = new SqlCommand("UPDATE signupdetails SET Password=@v1 WHERE Emailaddress=@v3 AND EmployeeId=@v2",connection);
                                updatecommand.Parameters.Add("@v3",SqlDbType.VarChar,50,"Emailaddress").Value=email;
                                updatecommand.Parameters.Add("@v2",SqlDbType.VarChar,50,"EmployeeId").Value=id;
                                updatecommand.Parameters.Add("@v1",SqlDbType.VarChar,50,"Password").Value=password;
                                updatecommand.ExecuteNonQuery();
                                
                                

                            }
                            return 1;
                }
             }
             return 2;
        }
        public static int validateForm(Employees employee)
        {
            
            // int fileSize= employee.Attachment.ContentLength;
            foreach(KeyValuePair<string,string[]> validatedata in employeedata)
            {
                if(string.Equals(employee.EmployeeName,validatedata.Value[2]) && string.Equals(employee.EmployeeID,validatedata.Key))
                {
                    return 1;
                }     
            }
            return 2;
        }
        public static SignupAccount myProfile(string EmployeeID)
        {
            SignupAccount signupaccount= new SignupAccount();
            try
            {
            using(SqlConnection connection= new SqlConnection("Data Source=ASPIRE1443; Initial Catalog=MVCApplication; Integrated Security=true"))
            {
                connection.Open();
                string queryString=$"SELECT * FROM signupdetails WHERE EmployeeId='{EmployeeID}';";
                SqlCommand sqlCommand= new SqlCommand(queryString,connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while(reader.Read())
                {
                    signupaccount.EmployeeID=reader["EmployeeId"].ToString();
                    signupaccount.EmployeeName=reader["EmployeeName"].ToString();
                    signupaccount.Emailaddress=reader["Emailaddress"].ToString();  
                }    
            }   
            }
            catch(SqlException sqlexception)
            {
                Console.WriteLine(sqlexception);
            }
            return signupaccount;
        }
    }
}