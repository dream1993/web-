using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web.other
{
    public partial class update : System.Web.UI.Page
    {
        public string title;
        public List<DAL.typeData.Value> list = new List<DAL.typeData.Value>();
        public DAL.articleData.Value av;
        public int pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"]);
                pid = int.Parse(Request["pid"]);
                av = DAL.articleData.row(id);
                title = DAL.typeData.row(av.typeId).title;
                list = DAL.typeData.list(pid);
            }
            catch (Exception)
            {

            }
        }
    }
}