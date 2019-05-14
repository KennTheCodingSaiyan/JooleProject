/*
 * Yiwen Zhao 
 *  5/6/2019
 *  UserLoginController.cs
 *  
 */
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Services;
using System.Collections;
using Repositories.Repositories;
using System.Data;

namespace Joole_MVC_Team1.Controllers
{
    public class UserLoginController : Controller
    {
        // UserLogin
        public ActionResult LoginPage(string userIDInfo, string passwordInfo)
        {
            
            /*******************************************/
            // if all the inputs are null keep the login page

            if ((userIDInfo == null) && (passwordInfo == null))
            {
                return View();
            }
            Services.Service LoginTrueOrFalse = new Services.Service();
            bool LoginDetermine = LoginTrueOrFalse.LoginService(userIDInfo, passwordInfo);
            // based on the return bool value to choose which page to go
            if (LoginDetermine == false)
            {
                return View();
            }
            else
            {
                // this part should be the redirection page
                /* 
                 
                 */
                return RedirectToAction("SearchPage", "Search");
            }
        }
    }
}