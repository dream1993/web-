using System;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Web.admin.manager
{
    public partial class sql : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string path = Server.MapPath("/bak/");
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach (FileInfo fi in dir.GetFiles("*.bak"))
                {
                    if (fi.FullName.EndsWith(".bak")) // 将 docx 类型的文件过滤掉 
                    {
                        // 这个 fi 就是你要的 doc 文件
                        DropDownList1.Items.Add(new ListItem(fi.Name, path + fi.Name));
                        //  DropDownList1.DataValueField = "D://" + fi.Name;

                        // Console.WriteLine(fi.Name);
                    }
                }
            }
        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            string path = Server.MapPath("/bak/");
            string SqlStr1 = DAL.publicData.connString;
            string str = DateTime.Now.ToString("yyyyMMddHHmmss");
            string SqlStr2 = "backup database temp to disk='" + path + str + ".bak'";
            SqlConnection con = new SqlConnection(SqlStr1);
            con.Open();
            try
            {
                //if (File.Exists(this.TextBox1.Text.Trim()))
                //{
                //    Response.Write("<script language=javascript>alert('此文件已存在，请从新输入！');location='Default.aspx'</script>");
                //    return;
                //}
                SqlCommand com = new SqlCommand(SqlStr2, con);
                com.ExecuteNonQuery();
                Response.Write("<script language=javascript>alert('备份数据成功！');window.location.href='sql.aspx'</script>");
            }
            catch (Exception error)
            {
                Response.Write(error.Message);
                Response.Write("<script language=javascript>alert('备份数据失败！')</script>");
            }
            finally
            {
                con.Close();
            }
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {
            string path = DropDownList1.SelectedValue; //获得备份路径及数据库名称


            //com.ExecuteNonQuery();
            if (RestoreDataBase("temp", path, true))
            {
                Response.Write("<script language=javascript>alert('还原数据成功！');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('还原数据失败！')</script>");
            }

        }


        /// <summary>
        /// 恢复数据库，可选择是否可以强制还原（即在其他人在用的时候，依然可以还原）
        /// </summary>
        /// <param name="databasename">待还原的数据库名称</param>
        /// <param name="databasefile">带还原的备份文件的完全路径</param>
        /// <param name="errormessage">恢复数据库失败的信息</param>
        /// <param name="forceRestore">是否强制还原（恢复），如果为TRUE，则exec killspid '数据库名' 结束此数据库的进程，这样才能还原数据库</param>
        /// <returns></returns>
        public bool RestoreDataBase(string databasename, string databasefile, bool forceRestore)
        {
            bool success = true;
            string path = databasefile;
            string dbname = databasename;

            string restoreSql = "use master;";

            if (forceRestore)//如果强制回复
                restoreSql += string.Format("use master exec killspid '{0}';", databasename);

            restoreSql += "restore database @dbname from disk = @path WITH REPLACE;";
            string SqlStr1 = DAL.publicData.connString;
            SqlConnection conn = new SqlConnection(SqlStr1);
            SqlCommand myCommand = new SqlCommand(restoreSql, conn);

            myCommand.Parameters.Add("@dbname", SqlDbType.Char);
            myCommand.Parameters["@dbname"].Value = dbname;
            myCommand.Parameters.Add("@path", SqlDbType.Char);
            myCommand.Parameters["@path"].Value = path;

            try
            {
                myCommand.Connection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //errormessage = ex.Message;
                success = false;
            }
            finally
            {
                myCommand.Connection.Close();
            }

            return success;
        }

    }
}