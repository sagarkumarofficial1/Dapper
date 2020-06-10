using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetMVC.Data.Modal
{
    public class UserProfileMasterModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string gender { get; set; }

        public List<DropDown> GenderList { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string DOB { get; set; }
        [Required]
        public int CollageId { get; set; }

        public List<DropDown> CollageList { get; set; }
        //Year Of Graduation
        [Required]
        public int YOG { get; set; }
    }

    public enum gender
    {
        Male,
        Female,
        Others
    }
}
