using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GozdeOzerBitirmeProjesi_.Entities;

namespace GozdeOzerBitirmeProjesi_.Models
{
    public class LoginControl

    {
        public static Admin GetUser()
        {
            var user = new Admin();
            if (HttpContext.Current.Session["Username"] != null)
            {
                try
                {
                    user = HttpContext.Current.Session["Username"] as Admin;
                    return user;
                }
                catch (Exception)
                {
                    HttpContext.Current.Response.Redirect("~/Login");
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Login");

            }
            return user;


        }
    }
}