using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Web.ajax
{
    /// <summary>
    /// html 的摘要说明
    /// </summary>
    public class html : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            DirectoryInfo dir = new DirectoryInfo(context.Server.MapPath(@"~/htmls/"));
            foreach (FileInfo fi in dir.GetFiles("*.html"))
            {
                if (fi.FullName.EndsWith(".html")) // 将 docx 类型的文件过滤掉
                {
                    // 这个 fi 就是你要的 doc 文件
                    OutputHtml(context, fi.Name );
                }
            } 
        }
        private string OutputHtml(HttpContext context, string FName)
        {
            try
            {
                string filename = "/";
                CL.Common.createDir(context.Server.MapPath(filename));
               
                //获取将要生成的*.htm文件的虚拟路径，引用为HtmlPath 
                string HtmlPath = String.Format(@"\{0}", FName);
                //根据*.htm模板文件的物理路径，读取模板中所有字符串，引用为HtmlTemp，编码为UTF8 
                string HtmlTemp = File.ReadAllText(context.Server.MapPath("/html/" + FName), Encoding.UTF8);
                //根据HtmlTemp创建StringBuilder对象，引用为SBuilder 
                StringBuilder SBuilder = new StringBuilder(HtmlTemp);
                //将SBuilder中的指定字符串替换为参数变量值 
                SBuilder.Replace("{meta}", gethtmls(context,"meta"));
                SBuilder.Replace("{right}", gethtmls(context, "right"));
                SBuilder.Replace("{head}", gethtmls(context, "head"));
                SBuilder.Replace("{foot}", gethtmls(context, "foot"));
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
                return "生成成功";
            }
            catch (Exception)
            {
                return "生成失败";
            }
        }
        private string gethtmls(HttpContext context,string name) {
            using (StreamReader reader = new StreamReader(context.Server.MapPath(@"/common/"+name+".html"), Encoding.UTF8))
            {
                string content = reader.ReadToEnd();
                return content;
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