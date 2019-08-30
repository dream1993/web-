using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.management
{
    /// <summary>
    /// level 的摘要说明
    /// </summary>
    public class level : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var del = context.Request["del"];
            if (!string.IsNullOrEmpty(del))
            {
                if (DAL.RoleInfoData.DelRoleInfo(int.Parse(del)) > 0)
                {
                    context.Response.Redirect("default.aspx?message=删除成功", false);
                }
                else
                {
                    context.Response.Redirect("default.aspx?message=删除失败", false);
                }
                return;
            }
            string roleid = context.Request["roleid"];
            if (!string.IsNullOrEmpty(roleid))
            {
                try
                {

                    string nodeid = context.Request["nodeid"];
                    int role = int.Parse(roleid);
                    context.Response.Redirect("roleright.aspx?message=" + (BLL.RoleRightManager.AddRoleRight(nodeid, role)) + "&roleid=" + role, false);
                }
                catch (Exception)
                {
                    context.Response.Redirect("roleright.aspx?message=非法字符&roleid=" + roleid, false);
                }
                return;
            }
            var rolename = context.Request.Form["rolename"];
            var roledesc = context.Request.Form["roledesc"];
            var pid = context.Request.Form["pid"] == null ? "" : context.Request.Form["pid"];
            var id = context.Request["id"];
            DAL.RoleInfoData.Value mf = new DAL.RoleInfoData.Value();
            mf.RoleName = rolename;
            mf.RoleDesc = roledesc;
            if (string.IsNullOrEmpty(id))
            {
                mf.layer = pid.Length / 3;
                mf.parentId = pid;
                mf.RoleId = parentid(pid);
                if (DAL.RoleInfoData.AddRoleInfo(mf) > 0)
                {
                    context.Response.Redirect("add.aspx?message=添加成功", false);
                }
                else
                {
                    context.Response.Redirect("add.aspx?message=添加失败", false);
                }
            }
            else
            {
                mf.id = int.Parse(id);
                if (DAL.RoleInfoData.UpdateRoleInfo(mf) > 0)
                {
                    context.Response.Redirect("update.aspx?message=修改成功&id=" + id, false);
                }
                else
                {
                    context.Response.Redirect("update.aspx?message=修改失败&id=" + id, false);
                }
            }


        }
        private string parentid(string pid)
        {
            string str = "";
            int count = DAL.RoleInfoData.GetCount(pid) + 1;

            if (!string.IsNullOrEmpty(pid))
            {
                if (count <= 9)
                {
                    str = pid + "00" + count;
                }
                else if (count > 9 && count < 100)
                {
                    str = pid + "0" + count;
                }
                else
                {
                    str = pid + count;
                }
            }
            else
            {
                if (count <= 9)
                {
                    str = "10" + count;
                }
                else if (count > 9 && count < 100)
                {
                    str = "1" + count;
                }
                else
                {
                    str = count.ToString();
                }
            }
            return str;
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