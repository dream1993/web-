using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web.message
{
    public partial class _default : System.Web.UI.Page
    {
        public List<DAL.messageData.Value> list;
        public int data;
        public int page;
        public int count;
        public string msg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request["delid"];
                if (!string.IsNullOrEmpty(id))
                {
                    if (DAL.messageData.delete(int.Parse(id)))
                    {
                        msg = "删除成功";
                    }
                    else
                    {
                        msg = "删除失败";
                    }
                }
                data = 15;
                page = Request["page"] == null ? 1 : int.Parse(Request["page"]);

                list = DAL.messageData.page(data, page);
                count = DAL.messageData.count();
            }
            catch (Exception)
            {

            }
        }

    } 
}