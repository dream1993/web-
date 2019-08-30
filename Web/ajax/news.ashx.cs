using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
namespace Web.ajax
{
    /// <summary>
    /// news 的摘要说明
    /// </summary>
    public class news : IHttpHandler
    {
        private int data = 3;
        public void ProcessRequest(HttpContext context)
        {
            int pid = 34;
            int count = DAL.articleData.count(pid);
            int Cpage = (count % data) > 0 ? ((count / data) + 1) : count / data;//一共有多少页
            DAL.webSiteData.Value wv = DAL.webSiteData.table();
            try
            {
                string filename = "/news/";
                CL.Common.createDir(context.Server.MapPath(filename));
                for (int i = 1; i <= Cpage; i++)
                {
                    string name = i == 1 ? filename + "index.html" : filename + "page-34_" + i + ".html";
                    OutputHtml(context, wv, name, pid, i, count, filename, Cpage);
                }
                OutputHtml(context, wv, filename + "page-34_1.html", pid, 1, count, filename, Cpage);
                string src = "";
                //foreach (DAL.typeData.Value v in DAL.typeData.list(4))
                //{
                    pid =35;
                    count = DAL.articleData.count(pid);
                    Cpage = (count % data) > 0 ? ((count / data) + 1) : count / data;//一共有多少页
                    src = filename;
                    CL.Common.createDir(context.Server.MapPath(src));
                    if (count > 0)
                    {
                        for (int i = 1; i <= Cpage; i++)
                        {
                            string name = src + "page-35_" + i + ".html";
                            OutputHtml(context, wv, name, pid, i, count, src, Cpage);
                        }
                    }
                    else
                    {
                        string name = src + "page-35_1.html";
                        OutputHtml(context, wv, name, pid, 1, count, src, Cpage);
                    }
                //}
                context.Response.Write("新闻页面生成成功");
            }
            catch (Exception)
            {
                context.Response.Write("新闻页面生成失败");
            }
        }
        private string OutputHtml(HttpContext context, DAL.webSiteData.Value wv, string FName, int pid, int page, int count, string filename, int Cpage)
        {
            try
            {
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", FName);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/htmls/news.html"), Encoding.UTF8);
                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                //SBuilder.Replace("{webtitle}", "新闻_" + wv.title);
                //SBuilder.Replace("{keywords}", wv.keywords);
                //SBuilder.Replace("{Description}", wv.description);
                //SBuilder.Replace("{meta}", gethtml.gethtmls(context, "meta"));
                //SBuilder.Replace("{right}", gethtml.gethtmls(context, "right"));
                //SBuilder.Replace("{head}", gethtml.gethtmls(context, "head"));
                //SBuilder.Replace("{foot}", gethtml.gethtmls(context, "foot"));
                SBuilder.Replace("{list}", newslist(pid, page, data));
                SBuilder.Replace("{new_nav}",nav(pid));
                //感谢您，每次都关注我们最前沿的动态
                if (pid == 34)
                {
                    SBuilder.Replace("{title1}", "公司动态");
                    SBuilder.Replace("{title2}", "感谢您，每次都关注我们最前沿的动态");
                }
                else
                {
                    SBuilder.Replace("{title1}", "行业新闻");
                    SBuilder.Replace("{title2}", "感谢您，每次都关注我们行业内最新新闻");
                }
                int type = 0;
                if (pid != 4)
                {
                    type = 1;
                }
                SBuilder.Replace("{page}", Cpage > 1 ? pages(page, data, count, pid, filename,type) : "");

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
                return "新闻页面生成成功";
            }
            catch (Exception)
            {
                return "新闻页面生成失败";
            }
        }

        private string newslist(int pid, int page, int data)
        {

            string filename = "/news/";

            string src = "";
            List<DAL.articleData.Value> list = DAL.articleData.page(data, page, pid);

            src = filename;
            StringBuilder str = new StringBuilder();
            foreach (DAL.articleData.Value ev in list)
            {
                str.Append("<a href='/news/" + ev.id + ".html' >");
                str.Append("  <dl class='clearfix'> <dt>");
                str.Append(" <img src='" + ev.imgSrc + "'>");
                str.Append("<span class='img-blueline'></span> </dt><dd>");
                str.Append("  <h5 class='blue-ski'>" + ev.title + "</h5>");
                str.Append("<p>" + ev.keyword + "</p>");
                str.Append(" </dd>");
                str.Append(" <div class='list-bd-time'>");
                str.Append(" <div class='list-time-left'>");
                str.Append("<span>" + ev.updateTime.ToString("MM-dd") + "<br><i>" + ev.updateTime.ToString("yyyy") + "</i></span>");
                str.Append("</div>");
                str.Append(" <div class='list-time-right'><i></i></div></div></dl> </a><div class='line-news'></div>");
            }
            return str.ToString();
        }
        private string pages(int page, int data, int count, int pid, string filename,int type)
        {
            return CL.Common.page2(count, page, data, pid, filename,type);
        }
        private string nav(int pid)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<a class='"+(pid==34?"on":"")+"' href='/news/index.html'>公司动态<span class='span-tra'></span></a>");
            str.Append("<a class='" + (pid == 35 ? "on" : "") + "' href='/news/page-35_1.html'>行业新闻<span class='span-tra'></span></a>");

            //foreach (DAL.typeData.Value tv in DAL.typeData.list(4))
            //{
            //    str.Append("<a href='/news/page-"+tv.id+"_1.html'>"+tv.title+"<span class='span-tra'></span></a>");
            //}
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