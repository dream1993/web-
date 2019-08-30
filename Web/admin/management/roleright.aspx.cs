using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.management
{
    public partial class roleright : System.Web.UI.Page
    {
        public List<DAL.RoleRightData.Value> mr;
        protected void Page_Load(object sender, EventArgs e)
        {
            int roleid = 0;
            try
            {
                roleid = Request["roleid"] == null ? 0 : int.Parse(Request["roleid"]);
            }
            catch (Exception)
            {
            }
             mr = DAL.RoleRightData.GetListByRoleId(roleid);
        }
    }
}