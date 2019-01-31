using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCwithApiapp.Data.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        //public string Flag { get; set; }

        [Required]
        [StringLength(10000,MinimumLength =10)]
        public string ReportDetails { get; set; }
        public User user { get; set; }
    }
}
