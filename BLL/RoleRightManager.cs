using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public  class RoleRightManager
    {
        public static string AddRoleRight(string nodeid, int roleid)
        {
            string sql = "Delete FROM RoleRight  where RoleId=" + roleid + ";";
            string msg = "";
            try
            {
                foreach (string nid in nodeid.Split(','))
                {
                    if (!string.IsNullOrEmpty(nid))
                    {
                        sql += "INSERT RoleRight (NodeId, RoleId)VALUES (" + int.Parse(nid) + "," + roleid + ");";
                    }
                }
                if (DAL.RoleRightData.AddRoleRight(sql) > 0)
                {
                    msg = "提交成功";
                }
            }
            catch (Exception)
            {
                msg = "非法字符";
            }

            return msg;
        }
    }
}
