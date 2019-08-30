using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
namespace CL
{
    /// <summary>
    /// 通用类
    /// </summary>
    public class Common
    {
        public static string head()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<div class='head_bg'></div>");
            str.Append("<div id='head'>");
            str.Append("<div class='head'>");
            str.Append("<a href='/' class='logo'><img src='/img/logo.png' /></a>");
            str.Append("<div class='nav'>");
            str.Append("<a href='javascript:void(0)' id='nav'>");
            str.Append("<span></span>");
            str.Append("<span></span>");
            str.Append("<span></span>");
            str.Append("</a>");
            str.Append("<ul>");
            str.Append("<li class='case'>");
            str.Append("<a href='/case'>");
            str.Append("<span class='en'>CASE</span>");
            str.Append("<span class='cn'>案 例</span>");
            str.Append("</a>");
            str.Append("</li>");
            str.Append("<li class='service'>");
            str.Append("<a href='/service.html'>");
            str.Append("<span class='en'>SERVICE</span>");
            str.Append("<span class='cn'>服 务</span>");
            str.Append("</a>");
            str.Append("</li>");
            str.Append("<li class='news'>");
            str.Append("<a href='/news'>");
            str.Append("<span class='en'>NEWS</span>");
            str.Append("<span class='cn'>新 闻</span>");
            str.Append("</a>");
            str.Append("</li>");
            str.Append("<li class='about'>");
            str.Append("<a href='/about.html'>");
            str.Append("<span class='en'>ABOUT</span>");
            str.Append("<span class='cn'>关 于</span>");
            str.Append("</a>");
            str.Append("</li>");
            str.Append("<li class='contact'>");
            str.Append("<a href='/contact.html'>");
            str.Append("<span class='en'>CONTACT</span>");
            str.Append("<span class='cn'>联 络</span>");
            str.Append("</a>");
            str.Append("</li>");
            str.Append("</ul>");
            str.Append("</div>");
            str.Append("</div>");
            str.Append("</div>");
            return str.ToString();
        }
        public static string foot(string add,string tel,string mail,string qq,string copyright)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<div class='contact_foot_bg'>");
            str.Append("<div class='foot'>");
            str.Append("<img src='/images/er.jpg' alt='关注' class='er' />");
            str.Append("<div class='copyright'>");
            str.Append("<div class='contact_c'>");
            str.Append("<span>ADD：<a>"+add+"</a></span>");
            str.Append("<span>QQ：" + qq + "</span><br />");
            str.Append("<span>TEL：" + tel + "</span>");
            str.Append("<span>E-mail："+mail+"</span>");
            str.Append("</div>");
            str.Append(copyright);
            str.Append("</div>");
            str.Append("<div class='share icon bdsharebuttonbox'>");
            str.Append("<a title='分享到微信' href='#' class='bds_weixin' data-cmd='weixin'></a>");
            str.Append("<a title='分享到QQ好友' href='#' class='bds_sqq' data-cmd='sqq'></a>");
            str.Append("<a title='分享到新浪微博' href='#' class='bds_tsina' data-cmd='tsina'></a>");
            str.Append("<a title='分享到人人网' href='#' class='bds_renren' data-cmd='renren'></a>");
            str.Append("<a title='分享到Facebook ' href='#' class='bds_fbook facebook' data-cmd='fbook'></a>");
            str.Append("</div>");
            str.Append(" </div>");
            str.Append("</div>");
            str.Append("<div class='conleft'>");
            str.Append("<ul>");
            str.Append("<li>");
            str.Append("<a href='http://wpa.qq.com/msgrd?v=3&uin="+qq+"&site=qq&menu=yes' target='_blank' class='qq icon'></a>");
            str.Append("<li>");
            str.Append("<a href='javascript:void(0);' class='phone icon'></a>");
            str.Append("</li>");
            str.Append("<li> <a href='#index' class='tophead icon'></a></li>");
            str.Append("</ul>");
            str.Append("</div>");
            return str.ToString();
        }
        public static string state(int audit)
        {
            if (audit == 0)
            {
                return "待审核";
            }
            if (audit == 1)
            {
                return "通过";
            }
            if (audit == 2)
            {
                return "未通过";
            }
            if (audit == 3)
            {
                return "已发货";
            }
            if (audit == 4)
            {
                return "已收货";
            }
            if (audit == 5)
            {
                return "逾期";
            }
            if (audit == 6)
            {
                return "订单完成";
            }
            return "未知";
        }
        /// <summary>
        /// 审核 0待审核   1通过    2不通过   3拉黑
        /// </summary>
        public static string audit(int audit)
        {
            if (audit == 0)
            {
                return "待审核";
            }
            if (audit == 1)
            {
                return "通过";
            }
            if (audit == 2)
            {
                return "未通过";
            }

            return "拉黑";


        }
        public static string input(bool b)
        {
            string str = "checkbox";
            if (b)
            {
                str = "radio";
            }
            return str;
        }

        /// <summary>
        /// 0女1男
        /// </summary>
        /// <param name="sex"></param>
        /// <returns></returns>
        public static string sex(int sex)
        {
            if (sex == 0)
            {
                return "女";
            }
            else
            {
                return "男";
            }
        }
        public static string login(HttpContext context)
        {
            string str = "";
            try
            {
                if (context.Session["hy_user"] != null)
                {
                    str = context.Session["hy_user"].ToString();
                }
            }
            catch (Exception)
            {

                str = "";
            }
            return str;
        }
        public static string userlogin(HttpContext context)
        {
            string str = "";
            try
            {
                if (context.Session["user"] != null)
                {
                    str = context.Session["user"].ToString();
                }
            }
            catch (Exception)
            {

                str = "";
            }
            return str;
        }
        public static string login()
        {
            string str = "";
            try
            {
                if (HttpContext.Current.Session["hy_user"] != null)
                {
                    str = HttpContext.Current.Session["hy_user"].ToString();
                }
            }
            catch (Exception)
            {

                str = "";
            }
            return str;
        }
        public static string userlogin()
        {
            string str = "";
            try
            {
                if (HttpContext.Current.Session["user"] != null)
                {
                    str = HttpContext.Current.Session["user"].ToString();
                }
            }
            catch (Exception)
            {

                str = "";
            }
            return str;
        }
        /// <summary>
        /// 发送激活链接
        /// </summary>
        /// <param name="activeCode"></param>
        /// <param name="mail"></param>
        public static bool SendActiveEmail(string mail, string path, string content, string title, string zhanghao, string mima)
        {
            try
            {
                MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
                mailMsg.From = new MailAddress(zhanghao);//源邮件地址 (发件人地址，网站管理员地址)
                mailMsg.To.Add(new MailAddress(mail));//目的邮件地址。可以有多个收件人
                mailMsg.Subject = title;//发送邮件的标题 
                mailMsg.Body = content;//发送邮件的内容 
                //---------------------附件-------------------------------
                FileInfo fi;
                if (path != "")
                {
                    string p = HttpContext.Current.Server.MapPath(path).Replace("\\\\", "/");
                    fi = new FileInfo(p);
                    if (fi.Exists)
                    {
                        System.Net.Mail.Attachment firstatt = new System.Net.Mail.Attachment(p, System.Net.Mime.MediaTypeNames.Application.Octet);
                        System.Net.Mime.ContentDisposition disposion = new System.Net.Mime.ContentDisposition();
                        disposion.CreationDate = System.IO.File.GetCreationTime(p);
                        disposion.ModificationDate = System.IO.File.GetLastWriteTime(p);
                        disposion.ReadDate = System.IO.File.GetLastAccessTime(p);
                        mailMsg.Attachments.Add(firstatt);
                    }
                }
                //-------------------------------------------------
                mailMsg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.163.com");//smtp.163.com，smtp.qq.com,发件人使用的邮箱的SMTP服务器地址.
                client.Credentials = new NetworkCredential(zhanghao, mima);//发件人邮箱的用户名密码.
                client.Send(mailMsg);//排队发送邮件.
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        #region ========加密========

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Encrypt(string Text)
        {
            return Encrypt(Text, "litianping");
        }
        /// <summary> 
        /// 加密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Encrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            byte[] inputByteArray;
            inputByteArray = Encoding.Default.GetBytes(Text);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region ========解密========


        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static string Decrypt(string Text)
        {
            return Decrypt(Text, "litianping");
        }
        /// <summary> 
        /// 解密数据 
        /// </summary> 
        /// <param name="Text"></param> 
        /// <param name="sKey"></param> 
        /// <returns></returns> 
        public static string Decrypt(string Text, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            int len;
            len = Text.Length / 2;
            byte[] inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(Text.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion

        /// <summary>
        /// 获取汉字首字母（可包含多个汉字）
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        public static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else
                return cnChar;
        }


        /// <summary>
        /// 获取第一个汉字的首字母，只能输入汉字
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string GetPYChar(string c)
        {
            byte[] array = new byte[2];
            array = System.Text.Encoding.Default.GetBytes(c);
            int i = (short)(array[0] - '\0') * 256 + ((short)(array[1] - '\0'));
            if (i < 0xB0A1) return "*";
            if (i < 0xB0C5) return "A";
            if (i < 0xB2C1) return "B";
            if (i < 0xB4EE) return "C";
            if (i < 0xB6EA) return "D";
            if (i < 0xB7A2) return "E";
            if (i < 0xB8C1) return "F";
            if (i < 0xB9FE) return "G";
            if (i < 0xBBF7) return "H";
            if (i < 0xBFA6) return "J";
            if (i < 0xC0AC) return "K";
            if (i < 0xC2E8) return "L";
            if (i < 0xC4C3) return "M";
            if (i < 0xC5B6) return "N";
            if (i < 0xC5BE) return "O";
            if (i < 0xC6DA) return "P";
            if (i < 0xC8BB) return "Q";
            if (i < 0xC8F6) return "R";
            if (i < 0xCBFA) return "S";
            if (i < 0xCDDA) return "T";
            if (i < 0xCEF4) return "W";
            if (i < 0xD1B9) return "X";
            if (i < 0xD4D1) return "Y";
            if (i < 0xD7FA) return "Z";
            return "*";
        }
        /// <summary>
        /// 验证账号密码是否符合规范
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool validation(string userName, string passWord)
        {
            Regex reg = new Regex(@"^.{1,30}$");
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(passWord))
            {
                if (reg.IsMatch(userName) && reg.IsMatch(passWord))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// MD5加密（两次）  会员密码
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static string MD5(string pass)
        {

            string s = "";
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "MD5");
            s = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5");
            return s;
        }
        /// <summary>
        /// 生成随机码
        /// </summary>
        /// <param name="num">位数</param>
        /// <returns></returns>
        public static string rund(int num)
        {
            ArrayList MyArray = new ArrayList();
            Random random = new Random();
            string str = null;
            //循环的次数     
            int Nums = num;
            while (Nums > 0)
            {
                int i = random.Next(0, 9);
                //  if (!MyArray.Contains(i))  
                //  {  
                if (MyArray.Count < 6)
                {
                    MyArray.Add(i);
                }
                // }  
                Nums -= 1;
            }
            for (int j = 0; j <= MyArray.Count - 1; j++)
            {
                str += MyArray[j].ToString();
            }
            return str;
        }
        /// <summary>
        /// 判断小于零   在前面补零
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string j(int i)
        {
            string s = "";
            if (i < 10)
            {
                s = "0" + i;
            }
            else
            {
                s = i.ToString();
            }

            return s;
        }
        /// <summary>
        /// 格式化英文月份
        /// </summary>
        /// <param name="months">月份</param>
        /// <returns></returns>
        public static string months(string months)
        {
            string rem = "";
            int mon = Convert.ToInt32(months);
            if (mon == 1)
            {
                rem = "Jan";
            }
            if (mon == 2)
            {
                rem = "Feb";
            }
            if (mon == 3)
            {
                rem = "Mar";
            }
            if (mon == 4)
            {
                rem = "Apr";
            }
            if (mon == 5)
            {
                rem = "May";
            }
            if (mon == 6)
            {
                rem = "Jun";
            }
            if (mon == 7)
            {
                rem = "Jul";
            }
            if (mon == 8)
            {
                rem = "Aug";
            }
            if (mon == 9)
            {
                rem = "Sep";
            }
            if (mon == 10)
            {
                rem = "Oct";
            }
            if (mon == 11)
            {
                rem = "Nov";
            }
            if (mon == 12)
            {
                rem = "Dec";
            }
            return rem;
        }
        /// <summary>
        /// 分页
        /// </summary>
        ///<param name="RequestURL">当期URL</param>
        /// <param name="pid">类别Id</param>
        /// <param name="page">当前页码</param>
        /// <param name="date">一页几条数据</param>
        /// <returns></returns>
        public static string page1(string RequestURL, int count, int page, int date)
        {
            string TempQuery = "";
            string[] TempQuery1 = { };
            System.Uri url = new Uri(RequestURL);
            string PathFileName = url.LocalPath.Substring(url.LocalPath.ToString().IndexOf('/'), url.LocalPath.ToString().LastIndexOf('.') - url.LocalPath.ToString().IndexOf('/'));//获取当前文件名，如YHQ.aspx则PathFileName的值为YHQ;
            if (url.Query.ToString().Trim() != "")
            {
                TempQuery = url.Query.ToString().Replace('?', ' ').Trim();
                #region 去除PageID参数
                ////if (TempQuery.IndexOf("pageid=" + NowPageID) != -1)
                ////{
                ////    TempQuery = TempQuery.Replace("pageid=" + NowPageID , "");
                ////}
                if (TempQuery.IndexOf("page=" + page + "&") != -1)
                {
                    TempQuery = TempQuery.Replace("page=" + page + "&", "");
                }
                if (TempQuery.IndexOf("&page=" + page) != -1)
                {
                    TempQuery = TempQuery.Replace("&page=" + page, "");
                }
                if (TempQuery.IndexOf("page=" + page) != -1)
                {
                    TempQuery = TempQuery.Replace("page=" + page, "");
                }
                #endregion
                if (TempQuery.Trim() != "")
                {
                    TempQuery1 = TempQuery.Split(new char[2] { '&', '=' });//分割参数;
                }
            }
            #region 组合新的URL
            string NewPath = "";
            for (int i = 0; i < TempQuery1.Length; )
            {
                if (NewPath == "")
                {
                    NewPath += "?" + TempQuery1[i] + "=" + TempQuery1[i + 1];
                }
                else
                {
                    NewPath += "&" + TempQuery1[i] + "=" + TempQuery1[i + 1];
                }
                i = i + 2;
            }
            if (NewPath == "")
            {
                NewPath = "?";
            }
            else
            {
                NewPath = NewPath + "&";
            }
            #endregion

            string str = "<div id='page'><div class='page'>";
            int Cpage = (count % date) > 0 ? ((count / date) + 1) : count / date;//一共有多少页
            if (count < 1)
            {
                str = "<span style='text-align:center;color:#BBC8D3;font-size: 24px;'>没有相关信息！</span>";
                return str;
            }

            //str += "<a class='RepeaterNumberList_sw' href='" + NewPath + "page=1'>首页</a>";
            if (page == 1)
            {
                str += "<a class='RepeaterNumberList'><</a>";
            }
            else
            {
                str += "<a href='" + NewPath + "page=" + (page - 1) + "' class='RepeaterNumberList'><</a>";
            }

            if (Cpage > 10)//判断一共有多少页码 是否要以 1 2 ...4 5 6 7 8 ...10  11  这样形式展示（超过10页这样显示）
            {

                if (page < 6)//当前页在前5页以内
                {
                    for (int i = 1; i < 3; i++)//固定显示前两页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                    //str += "<span class='RepeaterNumberList_sl'></span>";
                    for (int i = 3; i < 8; i++)//中间的5个分页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                    str += "<span class='RepeaterNumberList_sl'>...</span>";
                    for (int i = Cpage - 1; i < Cpage + 1; i++)//固定显示后两页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                }
                if (page >= Cpage - 4)//当前页在后5页以内(cpage+1-5)=cpage-4
                {
                    for (int i = 1; i < 3; i++)//固定显示前两页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                    //str += "<span class='RepeaterNumberList_sl'></span>";
                    for (int i = Cpage - 6; i < Cpage - 1; i++)//中间的5个分页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                    str += "<span class='RepeaterNumberList_sl'>...</span>";
                    for (int i = Cpage - 1; i < Cpage + 1; i++)//固定显示后两页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                }
                if (page > 5 && page < Cpage - 4)
                {
                    for (int i = 1; i < 3; i++)//固定显示前两页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                    //str += "<span class='RepeaterNumberList_sl'></span>";
                    for (int i = page - 2; i < page + 3; i++)//中间的5个分页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                    str += "<span class='RepeaterNumberList_sl'>...</span>";
                    for (int i = Cpage - 1; i < Cpage + 1; i++)//固定显示后两页
                    {
                        ym(NewPath, i, page, ref str);
                    }
                }
            }
            else
            {
                for (int i = 1; i < Cpage + 1; i++)
                {
                    ym(NewPath, i, page, ref str);
                }
            }

            if (page == Cpage)
            {
                str += "<a class='RepeaterNumberList'>></a>";
            }
            else
            {
                str += "<a href='" + NewPath + "page=" + (page + 1) + "' class='RepeaterNumberList'>></a>";
            }
            //str += "<a  class='RepeaterNumberList_sw' href='" + NewPath + "page=" + Cpage + "'>末页</a>";



            str += "</div></div>";
            return str;
        }
        public static void ym(string NewPath, int i, int page, ref string str)
        {

            if (i == page)
            {
                str += "<a href='" + NewPath + "page=" + i + "' class='RepeaterNumberList_Now'>" + i + "</a>";
            }
            else
            {
                str += "<a href='" + NewPath + "page=" + i + "' class='RepeaterNumberList_page'>" + i + "</a>";
            }
        }

        public static string page2(int count, int page, int date, int pid, string filename,int type)
        {


            string str = "<div class='pages' id='page'>";
            int Cpage = (count % date) > 0 ? ((count / date) + 1) : count / date;//一共有多少页
            if (count < 1)
            {
                str = "<span style='text-align:center;color:#BBC8D3;font-size:16px;display:block;margin:10px auto'>没有相关信息！</span>";

                return str;
            }


            string NewPath = filename;
            //if (Cpage > 5)//判断一共有多少页码 是否要以  ...4 5 6 7 8 ... 样形式展示（超过10页这样显示）
            //{

            //    if (page < 4)//当前页在前5页以内
            //    {
            //        // str += "<span class='glyphicon glyphicon-option-horizontal'></span>";
            //        for (int i = page - 2; i < page + 2; i++)//固定显示中间五页
            //        {
            //            ym2(NewPath, i, page, ref str);
            //        }

            //        // str += "<span class='glyphicon glyphicon-option-horizontal'></span>";

            //    }
            //    if (page >= Cpage - 4)//当前页在后5页以内
            //    {
            //        // str += "<span class='glyphicon glyphicon-option-horizontal'></span>";
            //        for (int i = Cpage - 4; i < Cpage; i++)//固定显示前两页
            //        {
            //            ym2(NewPath, i, page, ref str);
            //        }
            //    }
            //}
            //else
            //{
                for (int i = 1; i < Cpage + 1; i++)
                {
                    if (type == 0)
                    {
                        ym2(NewPath, i, page, ref str);
                    }
                    else if (type == 1)
                    {
                        ym3(NewPath, i, page, ref str,pid);
                    }
                    else if (type == 2)
                    {
                        ym4(NewPath, i, page, ref str, pid);
                    }
                   
                }
            //}
            //str += "</div>";
            //if (page == Cpage)
            //{
            //    str += "<a class='right r_arrows'></a>";
            //}
            //else
            //{
            //    str += "<a href='" + NewPath + "page=" + (page + 1) + "' class='right arrows arrows-transform180'></a>";
            //}

            str += "</div>";
            return str;
        }
        public static void ym2(string NewPath, int i, int page, ref string str)
        {

            if (i == page)
            {
                str += "<a class='on'>" + i + "</a>";
            }
            else if (i == 1)
            {
                str += "<a href='" + NewPath + "' >" + i + "</a>";
            }
            else
            {
                str += "<a href='" + NewPath + "page-" + i + ".html' >" + i + "</a>";
            }
        }
        public static void ym3(string NewPath, int i, int page, ref string str,int pid)
        {

            if (i == page)
            {
                str += "<a class='on'>" + i + "</a>";
            }
            else
            {
                str += "<a href='" + NewPath + "page-"+pid+"_" + i + ".html' >" + i + "</a>";
            }
        }
        public static void ym4(string NewPath, int i, int page, ref string str, int pid)
        {

            if (i == page)
            {
                str += "<a class='on'>" + i + "</a>";
            }
            else
            {
                str += "<a href='" + NewPath + "type_" + pid + "_" + i + ".html' >" + i + "</a>";
            }
        }
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool createDir(string fileName)
        {
            if (!Directory.Exists(fileName))
            {
                Directory.CreateDirectory(fileName);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="coding"></param>
        /// <returns></returns>
        public static string reader(string path, string coding)
        {
            string str = "";
            if (File.Exists(path))
            {
                var sr = new StreamReader(path, Encoding.GetEncoding(coding));
                str = sr.ReadToEnd();
                sr.Close();
            }
            else
            {
                str = "目录不存在";
            }
            return str;
        }
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="Text"></param>
        /// <param name="coding"></param>
        public static void writer(string path, string Text, string coding)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var sw = new StreamWriter(path, false, Encoding.GetEncoding(coding));
            sw.WriteLine(Text);
            sw.Flush();
            sw.Close();
        }
        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="zf">字符</param>
        /// <param name="cd">长度</param>
        /// <returns></returns>
        public static string cutStr(string zf, int cd)
        {
            if (zf.Length > cd)
            {
                zf = zf.Substring(0, cd) + "...";
            }
            return zf;
        }

        /// <summary>
        /// 清除HTML代码截取字符串
        /// </summary>
        /// <param name="zf"></param>
        /// <param name="cd"></param>
        /// <returns></returns>
        public static string cutHtml(string zf, int cd)
        {
            if (!string.IsNullOrEmpty(zf))
            {
                Regex reg = new Regex("<.*?>");
                string wz = reg.Replace(zf, "");
                return cutStr(wz, cd);
            }
            return "";
        }
        /// <summary>
        /// 显示textarea输入时的样式
        /// </summary>
        /// <param name="str">要进行转换的字符串</param>
        /// <returns>转换成textarea输入时的样的样子</returns>
        public static string textarea(String str)
        {

            //str 从数据库里取得的数据
            while (str.IndexOf("\n") != -1)
            {
                str = str.Substring(0, str.IndexOf("\n")) + "<br>" + str.Substring(str.IndexOf("\n") + 1);
            }
            while (str.IndexOf(" ") != -1)
            {
                str = str.Substring(0, str.IndexOf(" ")) + "&nbsp;" + str.Substring(str.IndexOf(" ") + 1);
            }
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">要进行转换的字符串</param>
        /// <param name="hs">要显示几行</param>
        /// <returns>转换成textarea输入时的样的样子</returns>
        public static string textarea(String str, int hs)
        {
            string[] zf;//所有行的字符（按照输入时的行来分段）
            string xs = "";//返回显示的字符
            str = textarea(str);
            while (str.IndexOf("<br>") != -1)
            {
                str = str.Substring(0, str.IndexOf("<br>")) + "|" + str.Substring(str.IndexOf("<br>") + 1);
            }
            zf = str.Split('|');
            for (int i = 0; i < hs; i++)
            {

                if (i < hs - 1)
                {
                    xs += zf[i] + "<";
                }
                else
                {
                    xs += zf[i];
                }
            }
            return xs;
        }



        /// <summary>
        /// 得到今天是星期几
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static string getWeek(string week)
        {
            string weekstr = "";
            switch (week)
            {
                case "Monday": weekstr = "星期一"; break;
                case "Tuesday": weekstr = "星期二"; break;
                case "Wednesday": weekstr = "星期三"; break;
                case "Thursday": weekstr = "星期四"; break;
                case "Friday": weekstr = "星期五"; break;
                case "Saturday": weekstr = "星期六"; break;
                case "Sunday": weekstr = "星期日"; break;
            }
            return weekstr;
        }
    }
}
