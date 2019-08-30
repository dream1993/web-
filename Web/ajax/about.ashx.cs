using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// about 的摘要说明
    /// </summary>
    public class about : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(OutputHtml(context, DAL.webSiteData.table()));
        }
        private string OutputHtml(HttpContext context, DAL.webSiteData.Value wv)
        {
            try
            {
                string filename = "/";
                CL.Common.createDir(context.Server.MapPath(filename));
                string FName = filename + "about.html";
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", FName);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/htmls/about.html"), Encoding.UTF8);
                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                SBuilder.Replace("{webtitle}", "关于_" + wv.title);
                SBuilder.Replace("{keywords}", wv.keywords);
                SBuilder.Replace("{Description}", wv.description);
                SBuilder.Replace("{meta}", gethtml.gethtmls(context, "meta"));
                SBuilder.Replace("{right}", gethtml.gethtmls(context, "right"));
                SBuilder.Replace("{head}", gethtml.gethtmls(context, "head"));
                SBuilder.Replace("{foot}", gethtml.gethtmls(context, "foot"));
             
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
                return "关于页面生成成功";
            }
            catch (Exception)
            {
                return "关于页面生成失败";
            }
        }
        public string about_cc()
        {
            StringBuilder str = new StringBuilder();
            int i = 1;
            foreach (DAL.articleData.Value av in DAL.articleData.table(8, 3))
            {

                str.Append("<div class='con_w " + (i == 2 ? "con_w_m" : "") + "'>");
                str.Append("<p class='title'>" + av.title + "</p>");
                str.Append("<p class='etitle'>" + av.realTitle + "</p>");
                str.Append("<div class='con'>" + av.description + "</div>");
                str.Append("</div>");
                i++;
            }
            return str.ToString();

        }
        public string team_list()
        {
            StringBuilder str = new StringBuilder();
            int i = 1;
            foreach (DAL.articleData.Value av in DAL.articleData.table(33, 5))
            {
                if (i == 5)
                {
                    str.Append("<li class='mar0'>");
                }
                else
                {
                    str.Append("<li>");
                }
                if (i == 2||i==4)
                {
                    str.Append("<img src='" + av.imgSrc + "' class='dis' />");
                }
                if (i == 1 || i == 3 || i == 5)
                {
                    str.Append("<img src='" + av.imgSrc + "' />");
                }
                str.Append("<div class='con'>");
                str.Append("<p class='title'>" + av.title + "</p>");
                str.Append("<p class='keyword'>" + av.realTitle + "</p>");
                str.Append("<p>");
                str.Append(av.description.Replace("\n","<br/>"));
                str.Append("</p></div>");
                if (i == 2 || i == 4)
                {
                    str.Append("<img src='" + av.imgSrc + "' class='dis1'  />");
                }
                str.Append("</li>");
                i++;
            }
            return str.ToString();
        }
        public string link_list()
        {
            StringBuilder str = new StringBuilder();
            foreach (DAL.articleData.Value av in DAL.articleData.table(32))
            {
                string img = av.imgSrc;
                string img1 = "";
                try
                {
                    img1 = av.a1.Split(',')[1];
                }
                catch (Exception)
                {

                }
                str.Append("<li>");
                str.Append("<img src='" + img + "' />");
                str.Append("<img src='" + img1 + "' class='img' />");
                str.Append("</li>");
            }
            return str.ToString();
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