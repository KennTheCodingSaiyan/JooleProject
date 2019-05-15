using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace Services.Models
{
    public class InsertDataToDatabase
    {
        private string username;
        private string emailaddress;
        private string password;
        private string cpassword;
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string EmailAddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string CPassword
        {
            get { return cpassword; }
            set { cpassword = value; }
        }
        public InsertDataToDatabase()
        {

        }
        public InsertDataToDatabase(string un, string ea, string pw)
        {
            username = un;
            emailaddress = ea;
            password = pw;
        }
        public void InsertAction()
        {
            //string conn2 = "data source=192.168.1.5;initial catalog=joole_team1;user id=T_User;password=us1";
            ////string sqlquery1 = "insert tblUser (User_ID, User_Name, User_Email, User_Image, User_Password) values (3, 'Vettel', 'hi@gmail.com', null, 0x33); go";
            //long param = Convert.ToInt64(password);
            //byte[] pwresult = BitConverter.GetBytes(param);
            //if (!BitConverter.IsLittleEndian)
            //{
            //    Array.Reverse(pwresult);
            //}
            //string sqlquery1 = string.Format("insert tblUser (User_ID, User_Name, User_Email, User_Image, User_Password) values ({0}, \'{1}\', \'{2}\', null, 0x11)", 6, username, emailaddress/*, param*/);
            ////string sqlquery1 = "insert tblUser (User_ID, User_Name, User_Email, User_Image, User_Password) values (6, 'e', 'e', null, 0x12)";

            //SqlConnection sqlconn1 = new SqlConnection(conn2);
            //sqlconn1.Open();
            //// adapter bind to query and connection object
            //SqlDataAdapter sqladapter = new SqlDataAdapter(sqlquery1, sqlconn1);
            //sqlconn1.Close();

            /**/
            string insertXmlQuery = @"Insert Into [tblUser] (User_ID, User_Name, User_Email, User_Image, User_Password) Values (6, @username, @emailaddress, null, @BinData)";
            // configure connection
            SqlConnection sqlconnection = new SqlConnection(@"data source=192.168.1.5;initial catalog=joole_team1;user id=T_User;password=us1");
            SqlCommand insertCommand = new SqlCommand(insertXmlQuery, sqlconnection);
            insertCommand.Parameters.AddWithValue("@username", username);
            insertCommand.Parameters.AddWithValue("@emailaddress", emailaddress);
            insertCommand.Parameters.AddWithValue("@BinData", 0x11);
            sqlconnection.Open();
            int a = insertCommand.ExecuteNonQuery();
            /**/

        }
    }
}