using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.management
{
    public partial class _default : System.Web.UI.Page
    {
        public List<DAL.RoleInfoData.Value> list = new List<DAL.RoleInfoData.Value>();
        protected void Page_Load(object sender, EventArgs e)
        {
            list = DAL.RoleInfoData.GetAllList();
        }
    }
}