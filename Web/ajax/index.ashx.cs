using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
namespace Web.ajax
{
    /// <summary>
    /// index 的摘要说明
    /// </summary>
    public class index : IHttpHandler
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
                string FName = filename + "index.html";
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", FName);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/htmls/index.html"), Encoding.UTF8);
                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                SBuilder.Replace("{webtitle}", wv.title);
                SBuilder.Replace("{keywords}", wv.keywords);
                SBuilder.Replace("{Description}", wv.description);
                SBuilder.Replace("{meta}", gethtml.gethtmls(context, "meta"));
                SBuilder.Replace("{right}", gethtml.gethtmls(context, "right"));
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
                return "首页面生成成功";
            }
            catch (Exception)
            {
                return "首页面生成失败";
            }
        }
        public string case_type()
        {
            StringBuilder str = new StringBuilder();
            foreach (DAL.typeData.Value av in DAL.typeData.list(2,4))
            {
                str.Append("<a href='/case/page-" + av.id + "_" + "1.html'  >" + av.title + "</a>");
            }
            return str.ToString();
        }
        public string wecan()
        {
            StringBuilder str = new StringBuilder();
            int i = 0;
            foreach (DAL.articleData.Value av in DAL.articleData.table(29, 4))
            {
                str.Append("<div class=' wow " + (i == 3 ? "border_l_n" : "") + "' data-wow-delay='1s' style='visibility: visible; -webkit-animation-delay: 1s;'>");
                str.Append(" <div class='w90'>");
                str.Append("<span class='icon icont icont" + (i + 1) + "'></span>");
                str.Append("<div class='title'><span class='line'></span><span class='tit'>" + av.title + "</span><span class='line'></span></div>");
                str.Append("<p>" + av.realTitle + "</p>");
                str.Append("<p class='desc'>" + av.description.Replace("\n","<br/>") + "</p>");
                str.Append("</div>");
                str.Append("<div class='wow1'>");
                str.Append(" <div class='w90'>");
                str.Append("<span class='icon icont icont" + (i + 1) + "'></span>");
                str.Append(" <div class='title'><span class='line'></span><span class='tit'>" + av.title + "</span><span class='line'></span></div>");
                str.Append("<p>" + av.realTitle + "</p>");
                str.Append(" <p class='desc'>" + av.description.Replace("\n", "<br/>") + "</p>");
                str.Append(" </div>");
                str.Append("</div>");
                str.Append(" </div>");
                i++;
            }
            return str.ToString();
        }
        public string case_list()
        {
            StringBuilder str = new StringBuilder(); 
            int i = 0;
            foreach (DAL.articleData.Value av in DAL.articleData.table(30, 4))
            {
                string logo = "";
                try
                {
                    logo = av.a1.Split(',')[1];
                }
                catch (Exception)
                {
                }
                str.Append("<a  href='"+av.url+"' target='_blank'>");
                str.Append(" <div class='list1'>");
                if (i % 2 == 0)
                {
                    str.Append(" <div class='img'>");
                    str.Append("<i> <img src='" + av.imgSrc + "' /></i>");
                    str.Append("<div class='ic_logo'>");
                    str.Append(" <img src='" + logo + "' />");
                    str.Append(" </div>");
                    str.Append("</div>");

                    str.Append("<div class='conn'>");
                    str.Append(" <p class='title'>" + av.title + "</p>");
                    str.Append("<p class='keyword'>");
                    str.Append(av.realTitle);
                    str.Append("</p>");
                    str.Append("<p class='desc'>");
                    str.Append(av.description);
                    str.Append("</p>");
                    str.Append(" </div>");
                }
                else
                {
                    str.Append("<div class='conn'>");
                    str.Append(" <p class='title'>" + av.title + "</p>");
                    str.Append("<p class='keyword'>");
                    str.Append(av.realTitle);
                    str.Append("</p>");
                    str.Append("<p class='desc'>");
                    str.Append(av.description);
                    str.Append("</p>");
                    str.Append(" </div>");

                    str.Append(" <div class='img'>");
                    str.Append("<i> <img src='" + av.imgSrc + "' /></i>");
                    str.Append("<div class='ic_logo'>");
                    str.Append(" <img src='" + logo + "' />");
                    str.Append(" </div>");
                    str.Append("</div>");
                }
              

                str.Append("</div>");
                str.Append("</a>");
                i++;
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