using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.management
{
    public partial class update : System.Web.UI.Page
    {
        public DAL.RoleInfoData.Value v = new DAL.RoleInfoData.Value();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request["id"];
                if (string.IsNullOrEmpty(id))
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    v = DAL.RoleInfoData.row(int.Parse(id));
                }
            }
            catch (Exception)
            {

            }
        }
    }
}