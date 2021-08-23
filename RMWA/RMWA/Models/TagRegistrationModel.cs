using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMWA.Models
{
    public class TagRegistrationModel
    {
        public IEnumerable<SelectListItem> Resource { get; set; }
        public IEnumerable<SelectListItem> Tag { get; set; }
        public string TagUOM { get; set; }
    }
}