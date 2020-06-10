using Dapper;
using DotNetMVC.Data.DAL;
using DotNetMVC.Data.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DotNetMVC.Data.BAL
{
    public class CollageMasterBAL
    {
        public static List<DropDown> GetCollageList()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                return connection.Query<DropDown>("Select Id as 'Value',collagename as 'Text' from collagemaster").ToList();
            }
        }

        public static CollageMaster GetCollage(string StudentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                return connection.Query<CollageMaster>("Select * from collagemaster c left join UserProfileMaster p on c.Id = p.CollageId where p.StudentId = @StudentId",new { StudentId}).FirstOrDefault();
            }
        }
    }
}
