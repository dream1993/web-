using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
namespace BLL
{
    public class RoleInfo
    {
        public static int count()
        {

            return RoleInfoData.count();
        }
        /// <summary>
        /// 最大id
        /// </summary>
        /// <returns></returns>
        public static int max()
        {
            return RoleInfoData.max();
        }
        public static int Add(RoleInfoData.Value roleInfo)
        {
            return RoleInfoData.AddRoleInfo(roleInfo);
        }
        public static int Update(RoleInfoData.Value roleInfo)
        {
            return RoleInfoData.UpdateRoleInfo(roleInfo);
        }
        public static int Del(int id)
        {
            return RoleInfoData.DelRoleInfo(id);
        }
        public static List<RoleInfoData.Value> GetAllList()
        {
            return RoleInfoData.GetAllList();
        }
        /// <summary>
        /// 根据父级查 
        /// </summary>
        /// <returns></returns>
        public static List<RoleInfoData.Value> GetList(string pid)
        {
            return RoleInfoData.GetList(pid);
        }
        public static RoleInfoData.Value row(int id)
        {
            return RoleInfoData.row(id);
        }


        

    }
}
