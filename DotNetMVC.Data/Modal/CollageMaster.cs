using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetMVC.Data.Modal
{
    public class CollageMaster
    {
        [Required]
        public int Id { get; set; }
        [Required ]
        public string CollageName { get; set; }
    }
}
