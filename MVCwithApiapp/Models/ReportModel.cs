using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Models
{
    public class ReportModel
    {
        //  public int ReportId { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Name must be greater than 5 character")]
        public string ReportDetails { get; set; }
    }
}
