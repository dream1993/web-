using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web.product
{
    public partial class add : System.Web.UI.Page
    {
        public string title;
        public int pid;
        public List<DAL.typeData.Value> list = new List<DAL.typeData.Value>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                pid = int.Parse(Request["pid"]);
                title = DAL.typeData.row(pid).title;
                list = DAL.typeData.list(pid);
            }
            catch (Exception)
            {

            }
        }
    }
}