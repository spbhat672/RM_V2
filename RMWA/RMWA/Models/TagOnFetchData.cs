﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RMWA.Models
{
    public class TagOnFetchData
    {
        public string TagName { get; set; }
        public long TagResourceId { get; set; }
        public long TagId { get; set; }
        public string TagUOM { get; set; }
    }
}