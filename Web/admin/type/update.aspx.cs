using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.type
{
    public partial class update : System.Web.UI.Page
    {
        public DAL.typeData.Value v = new DAL.typeData.Value();
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
                    v = DAL.typeData.row(int.Parse(id));
                }
            }
            catch (Exception)
            {

            }
        }
    }
}