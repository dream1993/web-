using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
namespace Web.ajax
{
    /// <summary>
    /// news_show 的摘要说明
    /// </summary>
    public class news_show : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                DAL.webSiteData.Value wv = DAL.webSiteData.table();
                DAL.typeData.Value tv2 = DAL.typeData.row(2);

                string filename = "/news/";
                string src = "";
                foreach (DAL.articleData.Value v in DAL.articleData.table(4))
                {
                    CL.Common.createDir(context.Server.MapPath(filename));
                    src = filename;//+tv1.fileName+"/"
                    CL.Common.createDir(context.Server.MapPath(src));
                    OutputHtml(context, v, wv, src);
                }
                context.Response.Write("新闻详情页面生成成功");
            }
            catch (Exception)
            {
                context.Response.Write("新闻详情页面生成失败");
            }

        }
        private string OutputHtml(HttpContext context, DAL.articleData.Value ev, DAL.webSiteData.Value wv, string FName)
        {
        
            try
            {
                string fnames = FName + ev.id + ".html";
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", fnames);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/htmls/newshow.html"), Encoding.UTF8);

                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                //SBuilder.Replace("{webtitle}", ev.title+"_"+wv.title);
                //SBuilder.Replace("{keywords}", ev.keyword);
                //SBuilder.Replace("{Description}", ev.description);
                SBuilder.Replace("{news_title}", ev.title);
                SBuilder.Replace("{news_type}", DAL.typeData.row(ev.typeId).title);
                SBuilder.Replace("{content}", ev.content);
                //SBuilder.Replace("{newsid}", ev.id.ToString());
                SBuilder.Replace("{news_source}", ev.source);
                SBuilder.Replace("{news_time}", ev.updateTime.ToString("yyyy-MM-dd"));
                if (ev.typeId == 35)
                {
                    SBuilder.Replace("{img1}", "/images/ne5_1.png");
                    SBuilder.Replace("{img2}", "/images/ne5_2.png");
                }
                else
                {
                    SBuilder.Replace("{img1}", "/images/ne4_1.png");
                    SBuilder.Replace("{img2}", "/images/ne4_2.png");
                }
                //SBuilder.Replace("{meta}", gethtml.gethtmls(context, "meta"));
                //SBuilder.Replace("{right}", gethtml.gethtmls(context, "right"));
                //SBuilder.Replace("{head}", gethtml.gethtmls(context, "head"));
                //SBuilder.Replace("{foot}", gethtml.gethtmls(context, "foot"));
                string next = "###";
                //string prev = "###";
                DAL.articleData.Value q = DAL.articleData.q(ev.sort, ev.typeId);
                //if (q.hasRow)
                //{
                //    prev = q.id + ".html";
                //}
                DAL.articleData.Value x=DAL.articleData.x(ev.sort, ev.typeId);
                if (q.hasRow)
                {
                    next = q.id + ".html";
                }
                SBuilder.Replace("{nextNews}", "<a href='" + next + "'>"+(!q.hasRow?"没有了":q.title)+"</a>");
               // SBuilder.Replace("{prev}", prev);
                //如果文件存在则删除
                if (File.Exists(context.Server.MapPath("/") + fnames))
                {
                    File.Delete(context.Server.MapPath("/") + fnames);
                }
                //根据FName获取将要生成的*.htm文件物理路径，并创建该文件，返回的StreamWriter对象引用为SWriter 
                StreamWriter SWriter = File.CreateText(context.Server.MapPath("/") + fnames);
                //调用SWriter的WriteLine方法，将SBuilder的字符串内容写入到文本流中 
                SWriter.WriteLine(SBuilder.ToString());
                //将缓冲区内容写入到新创建的*.htm文件中 
                SWriter.Flush();
                //关闭SWriter对象 
                SWriter.Close();
                //调用AddRow方法，并传递4个参数，用于数据库操作 
                return "新闻详情页面生成成功";
            }
            catch (Exception)
            {
                return "新闻详情页面生成失败";
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