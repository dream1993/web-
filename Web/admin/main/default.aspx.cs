using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.main
{

    public partial class _default : System.Web.UI.Page
    {
        public static string loginuser = "";
        public int roleid;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (loginuser == "")
            {
                Session["hy_user"] = Page.User.Identity.Name.ToString();
                //Response.Redirect("/admin");
            }
            loginuser = CL.Common.login();
            roleid = DAL.adminData.row(loginuser).role;
            if (Request["loginout"]=="quit")
            {
                FormsAuthentication.SignOut();
                Response.Redirect("/admin/");
                Session.Clear();
            }
            
        }
    }
}