/*
 * Yiwen Zhao 
 *  5/6/2019
 *  UserLoginController.cs
 *  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DAL.Models;
using Repositories;

namespace Services
{

    public partial class Service
    {        
        public bool LoginService(string SUsername, string SPasswd)
        {
            bool ReturnValue = false;
            int intR;
            //convert the password("decimal") to integer from string type
            //int intR = Convert.ToInt32(SPasswd);
            /* TryParse is more efficient*/
            int.TryParse(SPasswd, out intR);
            // search using the .ToList instead of GetByID saving time
            foreach (tblUser LoginInfo in uow.consumer.GetAll().ToList())
            {
                // convert the byte[] to interger32
                int intP = BitConverter.ToInt32(LoginInfo.User_Password, 0);
                bool result = (intR == intP);
                if(((LoginInfo.User_Name == SUsername) || (LoginInfo.User_Email == SUsername)) && result)
                {
                    return (ReturnValue = true);
                }
                else
                {
                    return ReturnValue;
                }
            }            
            /*convert string to byte[] */
            //byte[] SPasswd_byteArray = Encoding.ASCII.GetBytes(SPasswd);
            return ReturnValue;
        }
        //methods for service need 
        //e.g. UsrLogin();
    }
}
