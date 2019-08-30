using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

using System.Collections.Generic;//Please add references
namespace DAL
{
    public class roleUrlData : publicData
    {
        private static string sql = @"select r.NodeId 'NodeId',DisplayName,NodeURL from SysFun s,RoleInfo i,RoleRight r 
where s.NodeId=r.NodeId and r.RoleId=i.id and r.RoleId=@RoleId and s.ParentNodeId=@ParentNodeId order by DisplayOrder ";
        public static List<Value> table(int RoleId, int ParentNodeId)
        {
            using (var odc = Odc())
            {
                using (var cmd = new SqlCommand())
                {

                    cmd.Connection = odc;
                    cmd.CommandText = sql;
                    SqlParameter[] odp = new SqlParameter[]{
                        new SqlParameter("@RoleId",RoleId),
                        new SqlParameter("@ParentNodeId",ParentNodeId)
                    };
                    cmd.Parameters.AddRange(odp);
                    odc.Open();
                    var v = new Value();
                    var list = new List<Value>();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        v.NodeId = int.Parse(dr["NodeId"].ToString());
                        v.DisplayName = dr["DisplayName"].ToString();
                        v.NodeURL = dr["NodeURL"].ToString();
                        list.Add(v);
                    }
                    return list;
                }
            }
        }
        public struct Value
        {
            public int NodeId { get; set; }
            public string DisplayName { get; set; }
            public string NodeURL { get; set; }
        }
    }

}
