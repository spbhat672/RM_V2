﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMWA.Models
{
    public class ResourceModelOnFetchData
    {
        public string TypeName { get; set; }
        public int TypeID { get; set; }
        public long ResourceId { get; set; }
        public string ResourceName { get; set; }
        public long TagId { get; set; }
        public string ResourceDisplayName { get; set; }
    }
}