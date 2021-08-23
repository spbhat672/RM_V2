using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMWA.Models
{
    public class StatusModel
    {
        [Display(Name = "Resource Status Id")]
        public int StatusId { get; set; }
        [Display(Name = "Resource Status Name")]
        public string StatusName { get; set; }
    }
}