using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.admin.web
{
    public partial class _default : System.Web.UI.Page
    {
        public string copyright;
        protected void Page_Load(object sender, EventArgs e)
        {
            var v = BLL.webSite.table();
            this.title.Value = v.title;
            this.description.Value = v.description;
            this.keywords.Value = v.keywords;
            copyright = v.copyright;
            this.mail.Value = v.mail;
            this.tel.Value = v.tel;
            this.address.Value = v.address;
            this.code.Value = v.code;
            this.tel1.Value = v.tel1;
            this.QQ1.Value = v.QQ1;
            this.QQ2.Value = v.QQ2;
            this.fax.Value = v.fax;
            this.weburl.Value = v.weburl;
        }
    }
}