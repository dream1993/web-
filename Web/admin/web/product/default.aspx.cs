using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web.product
{
    public partial class _default : System.Web.UI.Page
    {
        public List<DAL.articleData.Value> list;
        public int pid;
        public string title;
        public int tid;
        public int data;
        public int page;
        public int count;
        public List<DAL.typeData.Value> tlist = new List<DAL.typeData.Value>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pid = int.Parse(Request["pid"]);
                title = DAL.typeData.row(pid).title;
                tlist = DAL.typeData.list(pid);
                data = 15;
                page = Request["page"] == null ? 1 : int.Parse(Request["page"]);
                if (string.IsNullOrEmpty(Request["tid"]))
                {
                    tid = pid;
                }
                else
                {
                    tid = int.Parse(Request["tid"]);
                }
                string search = Request["title"] == null ? "" : Request["title"];
                list = DAL.articleData.page(data, page, tid, search);
                count = DAL.articleData.count(tid, search);
            }
            catch (Exception)
            {

            }
        }

    }
}