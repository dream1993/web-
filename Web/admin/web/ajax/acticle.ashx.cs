using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.admin.web.ajax
{
    /// <summary>
    /// acticle 的摘要说明
    /// </summary>
    public class acticle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var delid=context.Request["delid"];
            
            if(!string.IsNullOrEmpty(delid)){
                string urlss = context.Request["returnurl"];
               
            
                if (DAL.articleData.delete(int.Parse(delid)))
                {
                    context.Response.Redirect(urlss + "/default.aspx?message=删除成功！&pid=" + context.Request["cc"], false);
                }
                else
                {
                    context.Response.Redirect(urlss + "/default.aspx?message=删除失败！&pid=" + context.Request["cc"], false);
                }
                return;
            }
            var user = context.User.Identity.Name.ToString();
            var title = context.Request["title"];
            var keyword = context.Request["keyword"] != null ? context.Request["keyword"] : "";
            var description = context.Request["description"] != null ? context.Request["description"] : "";
            var realTitle = context.Request["realTitle"] != null ? context.Request["realTitle"] : "";
            var imgSrc = context.Request["imgSrc"] != null ? context.Request["imgSrc"] : "";
            var fileSrc = context.Request["fileSrc"] != null ? context.Request["fileSrc"] : "";
            var updateTime = context.Request["updateTime"] != null ? context.Request["updateTime"] : DateTime.Now.ToString();
            var editor = context.Request["editor"] != null ? context.Request["editor"] : "";
            var source = context.Request["source"] != null ? context.Request["source"] : "";
            var hits = context.Request["hits"] != null ? context.Request["hits"] : "0";
            var content = context.Request["content"] != null ? context.Request["content"] : "";
            var typeId = context.Request["typeId"];
            var fine = context.Request["fine"] != null ? context.Request["fine"] : "false";
            var view = context.Request["view"] != null ? context.Request["view"] : "true";
            var url = context.Request["url"] != null ? context.Request["url"] : "###";
            var a1 = context.Request["a1"] != null ? context.Request["a1"] : "";
            var a2 = context.Request["a2"] != null ? context.Request["a2"] : "";
            var a3 = context.Request["a3"] != null ? context.Request["a3"] : "";
            var a4 = context.Request["a4"] != null ? context.Request["a4"] : "";
            var a5 = context.Request["a5"] != null ? context.Request["a5"] : "";
            var a6 = context.Request["a6"] != null ? context.Request["a6"] : "";
            var a7 = context.Request["a7"] != null ? context.Request["a7"] : "";
            var a8 = context.Request["a8"] != null ? context.Request["a8"] : "";
            var a9 = context.Request["a9"] != null ? context.Request["a9"] : "";
            var a10 = context.Request["a10"] != null ? context.Request["a10"] : "";
            var pic = context.Request["pic"] != null ? context.Request["pic"] : "";
            var id = context.Request["id"];
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(typeId))
            {
                var v = new DAL.articleData.Value();
                v.title = title;
                v.keyword = keyword;
                v.description = description;
                v.realTitle = realTitle;
                v.imgSrc = imgSrc;
                v.fileSrc = fileSrc;
                v.updateTime = Convert.ToDateTime(updateTime);
                v.editor = editor;
                v.source = source;
                v.hits = int.Parse(hits);
                v.content = content;
                v.typeId = int.Parse(typeId);
                v.fine = Convert.ToBoolean(fine);
                v.view = Convert.ToBoolean(view);
                v.url = url;
                v.a1 = a1;
                v.a2 = a2;
                v.a3 = a3;
                v.a4 = a4;
                v.a5 = a5;
                v.a6 = a6;
                v.a7 = a7;
                v.a8 = a8;
                v.a9 = a9;
                if (!string.IsNullOrEmpty(pic))
                {
                    v.imgSrc = pic.Split(',')[0];
                    v.a1 = pic;
                }
                v.a10 = a10;
                string urls = context.Request["returnurl"];
               
                if (!string.IsNullOrEmpty(id))
                {
                    v.id = int.Parse(id);
                    v.typeId = int.Parse(typeId);
                    if (DAL.articleData.update(v))
                    {
                        context.Response.Redirect(urls+"&id=" + v.id + "&message=修改成功！", false);
                    }
                    else
                    {
                        context.Response.Redirect(urls + "&id=" + v.id + "&message=修改失败！", false);
                    }

                }
                else
                {
                    v.role = 1;
                  
                    if (DAL.articleData.add(v))
                    {
                        context.Response.Redirect(urls + "&message=添加成功！", false);
                    }
                    else
                    {
                        context.Response.Redirect(urls + "&message=添加失败！", false);
                    }
                }
            }
            else
            {
                var idA = context.Request["idA"];
                var idB = context.Request["idB"];
                var ha = context.Request["ha"];
                var hb = context.Request["hb"];
                BLL.article.sort(idA, idB, ha, hb);
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