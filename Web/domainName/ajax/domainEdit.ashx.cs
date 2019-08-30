using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.domainName.ajax
{
    /// <summary>
    /// domainEdit 的摘要说明
    /// </summary>
    public class domainEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {

                if (context.Session["domain"] == null)
                {
                    context.Response.Write("1");
                    return;
                }
                DAL.adminData.Value av = DAL.adminData.row(int.Parse(context.Session["domain"].ToString()));
                DAL.domainData.Value dv = new DAL.domainData.Value();
                dv.adminName = av.userid;
                dv.company = string.IsNullOrEmpty(context.Request["company"]) ? "" : context.Request["company"];
                dv.contactName = string.IsNullOrEmpty(context.Request["contactName"]) ? "" : context.Request["contactName"];
                dv.createTime = DateTime.Now;
                dv.domainName = string.IsNullOrEmpty(context.Request["domainName"]) ? "" : context.Request["domainName"];
                dv.domainRemarks = string.IsNullOrEmpty(context.Request["domainRemarks"]) ? "" : context.Request["domainRemarks"];
                dv.domainTime = string.IsNullOrEmpty(context.Request["domainTime"]) ? DateTime.Now.AddYears(1) : DateTime.Parse(context.Request["domainTime"]);
                dv.email = string.IsNullOrEmpty(context.Request["email"]) ? "" : context.Request["email"];
                dv.ftp = string.IsNullOrEmpty(context.Request["ftp"]) ? "" : context.Request["ftp"];
                dv.ftpTime = string.IsNullOrEmpty(context.Request["ftpTime"]) ? DateTime.Now.AddYears(1) : DateTime.Parse(context.Request["ftpTime"]);
                dv.isUsDomain = string.IsNullOrEmpty(context.Request["isUsDomain"]) ? true : Boolean.Parse(context.Request["isUsDomain"]);
                dv.isUsFtp = string.IsNullOrEmpty(context.Request["isUsFtp"]) ? true : Boolean.Parse(context.Request["isUsFtp"]);
                dv.isUsServer = string.IsNullOrEmpty(context.Request["isUsServer"]) ? true : Boolean.Parse(context.Request["isUsServer"]);
                dv.phone = string.IsNullOrEmpty(context.Request["phone"]) ? "" : context.Request["phone"];
                dv.remarks = string.IsNullOrEmpty(context.Request["remarks"]) ? "" : context.Request["remarks"];
                dv.server = string.IsNullOrEmpty(context.Request["server"]) ? "" : context.Request["server"];
                dv.serverTime = string.IsNullOrEmpty(context.Request["serverTime"]) ? DateTime.Now.AddYears(1) : DateTime.Parse(context.Request["serverTime"]);
                dv.adminId = av.id;
                string id = context.Request["id"];
                if (string.IsNullOrEmpty(id))
                {
                    if (DAL.domainData.Add(dv) > 0)
                    {
                        context.Response.Write("0");
                    }
                    else
                    {
                        context.Response.Write("添加失败");
                    }
                }
                else
                {
                    dv.id = int.Parse(id);
                    if (DAL.domainData.Update(dv) > 0)
                    {
                        context.Response.Write("0");
                    }
                    else
                    {
                        context.Response.Write("修改失败");
                    }
                }
            }
            catch (Exception e)
            {
                context.Response.Write(e.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}