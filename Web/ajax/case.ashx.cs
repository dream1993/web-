using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
namespace Web.ajax
{
    /// <summary>
    /// _case 的摘要说明
    /// </summary>
    public class _case : IHttpHandler
    {

        private List<DAL.typeData.Value> list = DAL.typeData.list(2);
        private int data = 9;
        public void ProcessRequest(HttpContext context)
        {
            int pid = 2;
            int count = DAL.articleData.count(pid);
            int Cpage = (count % data) > 0 ? ((count / data) + 1) : count / data;//一共有多少页
            DAL.webSiteData.Value wv = DAL.webSiteData.table();
            try
            {
                string filename = "/case/";
                CL.Common.createDir(context.Server.MapPath(filename));
                for (int i = 1; i <= Cpage; i++)
                {
                    string name = i == 1 ? filename + "index.html" : filename + "page-" + i + ".html";
                    OutputHtml(context, wv, name, pid, i, count, filename, Cpage,0,0);
                }
                string src = "";
                foreach (DAL.typeData.Value v in DAL.typeData.list(2))
                {
                    pid = v.id;
                    count = DAL.articleData.count(pid);
                    Cpage = (count % data) > 0 ? ((count / data) + 1) : count / data;//一共有多少页
                    src = filename;
                    CL.Common.createDir(context.Server.MapPath(src));
                    if (count > 0)
                    {
                        for (int i = 1; i <= Cpage; i++)
                        {
                            string name = src + "page-"+v.id+"_"+ i + ".html";
                            OutputHtml(context, wv, name, pid, i, count, src, Cpage,0,1);
                        }
                    }
                    else
                    {
                        string name = src + "page-"+v.id+"_"+"1.html";
                        OutputHtml(context, wv, name, pid, 1, count, src, Cpage,0,1);
                    }
                }
                for (int j = 1; j < 5; j++)
                {
                    count = DAL.articleData.count_a3(j);
                    Cpage = (count % data) > 0 ? ((count / data) + 1) : count / data;//一共有多少页
                    src = filename;
                    CL.Common.createDir(context.Server.MapPath(src));
                    if (count > 0)
                    {
                        for (int i = 1; i <= Cpage; i++)
                        {
                            string name = src + "type_" + j + "_" + i + ".html";
                            OutputHtml(context, wv, name, j, i, count, src, Cpage,j,2);
                        }
                    }
                    else
                    {
                        string name = src + "type_" +j + "_" + "1.html";
                        OutputHtml(context, wv, name, j, 1, count, src, Cpage,j,2);
                    }
                }
                    context.Response.Write("案例页面生成成功");
            }
            catch (Exception)
            {
                context.Response.Write("案例页面生成失败");
            }
        }
        private string OutputHtml(HttpContext context, DAL.webSiteData.Value wv, string FName, int pid, int page, int count, string filename, int Cpage,int j,int type)
        {
            try
            {
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", FName);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/htmls/case.html"), Encoding.UTF8);
                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                //SBuilder.Replace("{webtitle}", "案列_" + wv.title);
                //SBuilder.Replace("{keywords}", wv.keywords);
                //SBuilder.Replace("{Description}", wv.description);
                SBuilder.Replace("{qq}", wv.QQ1);
                //SBuilder.Replace("{meta}", gethtml.gethtmls(context, "meta"));
                //SBuilder.Replace("{right}", gethtml.gethtmls(context, "right"));
                //SBuilder.Replace("{head}", gethtml.gethtmls(context, "head"));
                //SBuilder.Replace("{foot}", gethtml.gethtmls(context, "foot"));
                SBuilder.Replace("{nav_list}", types(pid));
                SBuilder.Replace("{casenav}", casenav(j));
                if (j == 0) { 
                SBuilder.Replace("{case_list}", caselist(pid, page, data));
                }
                else
                {
                    SBuilder.Replace("{case_list}", caselist_a3(j, page, data));
                }

                SBuilder.Replace("{page}", Cpage>1?pages(page, data, count, pid, filename,type):"");
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
                return "案例页面生成成功";
            }
            catch (Exception)
            {
                return "案例页面生成失败";
            }
        }

        private string caselist(int pid, int page, int data)
        {
            string filename = "/case/";
            string src = "";
            List<DAL.articleData.Value> list = DAL.articleData.page(data, page, pid);
            src = filename;
            StringBuilder str = new StringBuilder();
            foreach (DAL.articleData.Value ev in list)
            {
                str.Append("<li><a href='/case/"+ev.id+".html' target='_blank'>");
                str.Append("<div class='he_border1'>");
                str.Append("  <img src='"+ev.imgSrc+"' alt='"+ev.title+"'>");
                str.Append("<div class='he_border1_caption'> <p class='he_border1_caption_p'></p></div></div>");
                str.Append(" <p>" + ev.title + "</p>");
                str.Append("<span>" + ev.keyword + "</span>");
                str.Append(" </a>");
                str.Append(" </li>");
           
            }
            return str.ToString();
        }
        private string caselist_a3(int a3, int page, int data)
        {
            string filename = "/case/";
            string src = "";
            List<DAL.articleData.Value> list = DAL.articleData.page_a3(data, page, a3);
            src = filename;
            StringBuilder str = new StringBuilder();
            foreach (DAL.articleData.Value ev in list)
            {
                str.Append("<li><a href='/case/" + ev.id + ".html' target='_blank'>");
                str.Append("<div class='he_border1'>");
                str.Append("  <img src='" + ev.imgSrc + "' alt='" + ev.title + "'>");
                str.Append("<div class='he_border1_caption'> <p class='he_border1_caption_p'></p></div></div>");
                str.Append(" <p>" + ev.title + "</p>");
                str.Append("<span>" + ev.keyword + "</span>");
                str.Append(" </a>");
                str.Append(" </li>");

            }
            return str.ToString();
        }
        private string types(int pid)
        {
            DAL.typeData.Value tv = DAL.typeData.row(2);
            string str = "";
            foreach (DAL.typeData.Value av in DAL.typeData.list(2))
            {
                str += " <li class='leibie'><a href='/case/page-" + av.id + "_" + "1.html'  >" + av.title + "</a></li>";
            }
            return str;
        }
        private string pages(int page, int data, int count, int pid, string filename,int type)
        {
            return CL.Common.page2(count, page, data, pid, filename,type);
        }
        private string casenav(int i) {
            StringBuilder str = new StringBuilder();
            str.Append("<li class='"+(i==0?"on":"")+"'><a style='margin-left: 0;' href='/case/'>ALL</a></li>");
            str.Append("<li class='" + (i == 1 ? "on" : "") + "'><a href='/case/type_1_1.html'>网 站</a></li>");
            str.Append("<li class='" + (i == 2 ? "on" : "") + "'><a href='/case/type_2_1.html'>电 商</a></li>");
            str.Append("<li class='" + (i == 3 ? "on" : "") + "'><a href='/case/type_3_1.html'>移 动 端</a></li>");
            str.Append("<li class='" + (i == 4 ? "on" : "") + "'><a href='/case/type_4_1.html'>APP</a></li>");
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