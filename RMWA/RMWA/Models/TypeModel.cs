using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RMWA.Models
{
    public class TypeModel
    {
        [Display(Name = "Resource Type Id")]
        public int TypeId { get; set; }
        [Display(Name = "Resource Type Name")]
        public string TypeName { get; set; }
    }
}