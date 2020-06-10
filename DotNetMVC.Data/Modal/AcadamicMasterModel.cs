using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetMVC.Data.Modal
{
    public class AcadamicMasterModel
    {
        public int Id { get; set; }
        [Required]
        public String CollageName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FromYear { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ToYear { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string Semester { get; set; }
        [Required]
        public decimal Credit { get; set; }
        [Required]
        public string Grade { get; set; }
        public List<DropDown> SemesterList { get; set; }
        public List<DropDown> GradeList { get; set; }
    }

}
