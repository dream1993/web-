using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
namespace Web.ajax
{
    /// <summary>
    /// case_show 的摘要说明
    /// </summary>
    public class case_show : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                DAL.webSiteData.Value wv = DAL.webSiteData.table();
                string filename = "/case/";
                string src = "";
                foreach (DAL.articleData.Value v in DAL.articleData.table(2))
                {
                    CL.Common.createDir(context.Server.MapPath(filename));
                    src = filename;//+ tv1.fileName + "/"
                    CL.Common.createDir(context.Server.MapPath(src));
                    OutputHtml(context, v, wv, src + v.id + ".html");
                }
                context.Response.Write("案例详情页面生成成功");
            }
            catch (Exception)
            {
                context.Response.Write("案列详情页面生成失败");
            }
        }
        private string OutputHtml(HttpContext context, DAL.articleData.Value ev, DAL.webSiteData.Value wv, string FName)
        {
            try
            {
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", FName);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/htmls/caseShow.html"), Encoding.UTF8);
                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                //SBuilder.Replace("{webtitle}", "案例详情_" + ev.title);
                //SBuilder.Replace("{keywords}", wv.keywords);
                //SBuilder.Replace("{Description}", ev.description);
                SBuilder.Replace("{title}", ev.title);
                string img = "";

                try
                {
                    img = ev.a1.Split(',')[1];
                }
                catch (Exception)
                {

                }

                SBuilder.Replace("{case_xq}", img);
                SBuilder.Replace("{case_a2}", ev.a2);

                string url = "";
                if (ev.url.Length > 0)
                {
                    url = "<a class='zixun fwwz_caseshow' href=" + ev.url + " target='_blank'>访问网站 ></a>";
                }
                SBuilder.Replace("{case_url}", url);
                SBuilder.Replace("{case_title}", ev.title);
                SBuilder.Replace("{case_description}", ev.description);
                SBuilder.Replace("{case_keyword}", ev.keyword);
                SBuilder.Replace("{qq}", wv.QQ1);
                SBuilder.Replace("{navlist}", type(1));
                SBuilder.Replace("{case_realTitle}", ev.realTitle);
                //SBuilder.Replace("{meta}", gethtml.gethtmls(context, "meta"));
                //SBuilder.Replace("{right}", gethtml.gethtmls(context, "right"));
                //SBuilder.Replace("{head}", gethtml.gethtmls(context, "head"));
                //SBuilder.Replace("{foot}", gethtml.gethtmls(context, "foot"));
                //if (ev.a3.Equals("3") || ev.a3.Equals("4"))
                //{
                //SBuilder.Replace("{more_case}", morecase_a3(int.Parse(ev.a3), ev.id));
                //}
                //else
                //{
                  SBuilder.Replace("{more_case}", morecase(ev.typeId, ev.id,ev.a3));
                //}

                //如果文件存在则删除
                if (File.Exists(context.Server.MapPath("/") + FName))
                {
                    File.Delete(context.Server.MapPath("/") + FName);
                }
                //根据FName获取将要生成的*.htm文件物理路径，并创建该文件，返回的StreamWriter对象引用为SWriter 
                StreamWriter SWriter = File.CreateText(context.Server.MapPath("/") + FName);
                //调用SWriter的WriteLine方法，将SBuilder的字符串内容写入到文本流中 
                SWriter.WriteLine(SBuilder.ToString());
                //将缓冲区内容写入到新创建的*.htm文件中 
                SWriter.Flush();
                //关闭SWriter对象 
                SWriter.Close();
                //调用AddRow方法，并传递4个参数，用于数据库操作 
                return "案列详情页面生成成功";
            }
            catch (Exception)
            {
                return "案列详情页面生成失败";
            }
        }


        private string type(int pid)
        {
            DAL.typeData.Value tv = DAL.typeData.row(2);
            string str = "";
            foreach (DAL.typeData.Value av in DAL.typeData.list(2))
            {
                str += " <li class='leibie'><a href='/case/page-" + av.id + "_" + "1.html'  >" + av.title + "</a></li>";
            }
            return str;
        }
        private string morecase(int typeid, int id,string a3)
        {
            StringBuilder str = new StringBuilder();
            List<DAL.articleData.Value> list1 = DAL.articleData.table_ru(typeid, 3, id);
            foreach (DAL.articleData.Value av in list1)
            {
                str.Append("<a href='/case/" + av.id + ".html'><li><div class='he_border1'>");
                str.Append("<img src='" + av.imgSrc + "' alt='" + av.title + "'>");
                str.Append("<div class='he_border1_caption'> <p class='he_border1_caption_p'></p></div></div>");
                str.Append("<p>" + av.title + "</p>");
                str.Append("<span>" + av.keyword + "</span></a></li>");
            }
            if (list1.Count < 2)
            {
                list1 = DAL.articleData.table_rua3(int.Parse(a3), 3 - list1.Count, id,typeid);
                foreach (DAL.articleData.Value av in list1)
                {
                    str.Append("<a href='/case/" + av.id + ".html'><li><div class='he_border1'>");
                    str.Append("<img src='" + av.imgSrc + "' alt='" + av.title + "'>");
                    str.Append("<div class='he_border1_caption'> <p class='he_border1_caption_p'></p></div></div>");
                    str.Append("<p>" + av.title + "</p>");
                    str.Append("<span>" + av.keyword + "</span></a></li>");
                }
            }
            return str.ToString();
        }
        //private string morecase_a3(int a3, int id)
        //{
        //    StringBuilder str = new StringBuilder();
        //    foreach (DAL.articleData.Value av in DAL.articleData.table_rua3(a3, 3, id))
        //    {
        //        str.Append("<a href='/case/" + av.id + ".html'><li><div class='he_border1'>");
        //        str.Append("<img src='" + av.imgSrc + "' alt='" + av.title + "'>");
        //        str.Append(" <div class='he_border1_caption'></div></div>");
        //        str.Append("<p>" + av.title + "</p>");
        //        str.Append("<span>" + av.keyword + "</span></a></li>");
        //    }

        //    return str.ToString();
        //}
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}