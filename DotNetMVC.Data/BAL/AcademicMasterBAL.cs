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
    public class AcademicMasterBAL
    {
        public static void CreateProfile(AcadamicMasterModel model,string StudentId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                connection.Execute("insert into AcadamicMaster(CollageName,FromYear,ToYear,CourseName,Semester,Credit,Grade,StudentId) values(@CollageName,@FromYear,@ToYear,@CourseName,@Semester,@Credit,@Grade,@StudentId)", 
                    new { model.CollageName, model.FromYear, model.ToYear, model.CourseName, model.Semester, model.Credit, model.Grade,StudentId});
            }
        }
        public static List<AcadamicMasterModel> AcadamicList(string Email)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
            string Query = @"select a.Id as 'Id',CollageName,FromYear,ToYear,CourseName,Semester,Credit,Grade from acadamicmaster a
                           left join UserMaster u on a.studentid = u.Id
                           where u.Email = @Email"
                return connection.Query<AcadamicMasterModel>(Query, new { Email }).ToList();
            }
        }
        public static AcadamicMasterModel Acadamic(string Email,int Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                return connection.Query<AcadamicMasterModel>("select CollageName,FromYear,ToYear,CourseName,Semester,Credit,Grade from acadamicmaster a left join UserMaster u on a.studentid = u.Id where u.Email = @Email and a.Id = @Id", new { Email,Id }).FirstOrDefault();
            }
        }
        public static void UpdateAcademic(AcadamicMasterModel model, string StudentId,int Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                connection.Execute("update AcadamicMaster set  CollageName = @CollageName,FromYear=@FromYear,ToYear=@ToYear,CourseName=@CourseName,Semester=@Semester,Credit=@Credit,Grade=@Grade,StudentId=@StudentId where StudentId = @StudentId and Id = @Id",
                    new { model.CollageName, model.FromYear, model.ToYear, model.CourseName, model.Semester, model.Credit, model.Grade, StudentId,Id });
            }
        }
        public static void DeleteAcademic(string StudentId, int Id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.ConString("DefaultConnection")))
            {
                connection.Execute("delete from AcadamicMaster where StudentId = @StudentId and Id = @Id",new { StudentId,Id});
            }
        }

        public static List<DropDown> BindSamester()
        {
            List<DropDown> dropDowns = new List<DropDown>() {
                new DropDown{Text="Semester - 1",Value="Semester - 1"},
                new DropDown{Text="Semester - 2",Value="Semester - 2"},
                new DropDown{Text="Semester - 3",Value="Semester - 3"},
                new DropDown{Text="Semester - 4",Value="Semester - 4"},
                new DropDown{Text="Semester - 5",Value="Semester - 5"},
                new DropDown{Text="Semester - 6",Value="Semester - 6"},
                new DropDown{Text="Semester - 7",Value="Semester - 7"},
                new DropDown{Text="Semester - 8",Value="Semester - 8"}
            };

            return dropDowns;
        }

        public static List<DropDown> BindGrade()
        {
            List<DropDown> dropDowns = new List<DropDown>() {
                new DropDown{Text="A",Value="A"},
                new DropDown{Text="B",Value="B"},
                new DropDown{Text="C",Value="C"},
                new DropDown{Text="D",Value="D"},
                new DropDown{Text="E",Value="E"},
            };

            return dropDowns;
        }
    }
}
