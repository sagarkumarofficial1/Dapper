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
    public class UserProfileMasterBAL
    {
        public static UserProfileMasterModel GetStudentProfileData(string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                return connection.Query<UserProfileMasterModel>("if exists(Select * from UserProfileMaster p left join UserMaster u on u.Id = p.StudentId where u.Email = @Email) begin select * from UserProfileMaster p left join UserMaster u on p.StudentId = u.Id where u.Email = @Email end else begin Select Id as 'StudentId' from UserMaster where Email = @Email end", new { Email }).FirstOrDefault();
            }
        }



        public static List<UserProfileMasterModel> ProfileList(string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                return connection.Query<UserProfileMasterModel>("select * from UserProfileMaster p left join UserMaster u on p.StudentId = u.Id where u.Email = @Email", new { Email }).ToList();
            }
        }
        public static void CreateProfile(UserProfileMasterModel model)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                connection.Execute("if exists(select * from UserProfileMaster where StudentId = @StudentId) begin update UserProfileMaster set FirstName = @FirstName,LastName=@LastName,Gender=@Gender,DOB=@DOB,CollageId=@CollageId,YOG=@YOG where StudentId = @StudentId end else begin insert into UserProfileMaster(StudentId,FirstName,LastName,Gender,DOB,CollageId,YOG) values(@StudentId,@FirstName,@LastName,@Gender,@DOB,@CollageId,@YOG) end ", new { model.StudentId, model.FirstName,model.LastName,model.gender,model.DOB,model.CollageId,  model.YOG});
            }
        }

        public static List<DropDown> BindGender()
        {
            List<DropDown> dropDowns = new List<DropDown>() {
                new DropDown{Text="Male",Value="Male"},
                new DropDown{Text="Female",Value="Female"},
            };

            return dropDowns;
        }
    }
}
