using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RMWA.Models
{
    public class ResourceModel
    {
        public IEnumerable<SelectListItem> ResourceType { get; set; }
        public long ResourceId { get; set; }
        public string ResourceName { get; set; }
    }
}