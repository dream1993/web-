using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userName = Request["userName"];
            var passWord = Request["passWord"];
            // var cookie = "on";

            if (string.IsNullOrEmpty(userName))
            {
                if (Request.IsAuthenticated)
                {
                    if (DAL.adminData.row(Page.User.Identity.Name.ToString()).hasRow)
                    {
                        Session["hy_user"] = Page.User.Identity.Name.ToString();
                        Response.Redirect("/admin/main", true);
                    }
                }
            }
            else
            {
                var result = "";

                result = BLL.admin.login(userName, passWord);


                Response.Write(result);
            }
            //if (string.IsNullOrEmpty(userName))
            //{
            //    string user = CL.Common.login();
            //    if (user != "")
            //    {
            //        if (DAL.adminData.row(user).hasRow)
            //        {
            //            Response.Redirect("/admin/main/", true);
            //        }
            //    }
            //}
            //else
            //{
            //   string result = BLL.admin.login(userName, passWord);
            //   Response.Write(result);
            //}
        }
    }
}