using DotNetMVC.Data.Modal;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Text;
using DotNetMVC.Data.DAL;
using System.Linq;

namespace DotNetMVC.Data.BAL
{
    public class UserMasterBAL
    {

        public void RegisterUser(UserMaster model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                connection.Execute("insert into UserMaster(Email,Password) values(@Email,@Password)",new {model.Email,model.Password });
                var StudentId = UserProfileMasterBAL.GetStudentProfileData(model.Email).StudentId.ToString();
                connection.Execute("insert into UserProfileMaster(StudentId,FirstName,LastName,Gender,DOB,CollageId,YOG) values(@StudentId,'','','','',1,'')",new { StudentId});
            }
        }

        public static Boolean IsEmailExist(string email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                var data = connection.Query<UserMaster>("Select * from UserMaster where Email = @Email", new { email }).ToList();
                if (data.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool IsValidUser(LoginModel user)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
               var data = connection.Query<UserMaster>("Select * from UserMaster where Email = @Email", new { user.Email }).ToList();
                if (data.Count == 0)
                {
                    return false;
                }
                else
                {
                    if (user.Password == data[0].Password)
                    {
                        return true;
                    }else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
