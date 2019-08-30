using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.type
{
    /// <summary>
    /// type 的摘要说明
    /// </summary>
    public class type : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string act = context.Request["act"];
                var title = context.Request["title"];
                var imgSrc = context.Request["imgSrc"] == null ? "" : context.Request["imgSrc"];
                var img = context.Request["imgSrc1"] == null ? "" : context.Request["imgSrc1"];
                var content = context.Request["content"] == null ? "" : context.Request["content"];
                var parentId = context.Request["pid"];
                var typeId = "";
                var layer = context.Request["layer"];
                var view = context.Request["view"];


                var id = context.Request["id"];

                var v = new DAL.typeData.Value();
                v.title = title;
                v.imgSrc = imgSrc;
                v.content = content;
                v.view = Convert.ToBoolean(view);
                v.img = img;
                switch (act)
                {
                    case "add"://添加
                        v.parentId = int.Parse(parentId);
                        v.typeId = typeId;
                        v.layer = int.Parse(layer);
                        if (BLL.type.Add(v).Equals("0"))
                        {
                            var upId = BLL.type.MaxId();
                            if (v.parentId > 0)
                            {
                                var row = BLL.type.row(v.parentId);
                                if (row.hasRow)
                                {
                                    typeId = row.typeId + upId + ",";
                                }
                            }
                            else
                            {
                                typeId = "," + upId + ",";
                            }

                            var up = new DAL.typeData.Value();
                            up.id = upId;
                            up.typeId = typeId;

                            if (DAL.typeData.typeId(up))
                            {
                                context.Response.Redirect("add.aspx?message=添加成功！&pid=" + v.parentId, false);
                            }
                            else
                            {
                                context.Response.Redirect("add.aspx?message=添加失败！&pid=" + v.parentId, false);
                            }
                        }
                        break;
                    case "update"://修改
                        v.id = int.Parse(id);
                        if (DAL.typeData.update(v))
                        {
                            context.Response.Redirect("update.aspx?message=修改成功！&id=" + v.id, false);
                        }
                        else
                        {
                            context.Response.Redirect("update.aspx?message=修改失败！&id=" + v.id, false);
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                context.Response.Redirect("default.aspx?message=网络错误，请稍后再试！");
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