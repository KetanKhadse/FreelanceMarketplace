using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLiberaryCore.Helper.JqueryDT
{
    public class SearchModel
    {
        public string? sortColumnDirection;
        public string? searchValue;
        public int pageSize;
        public string draw { get; set; }
        public string start { get; set; }
        public string length { get; set; }
        public string sortColumn { get; set; }
        public string searchVal { get; set; }
        public int skip { get; set; }
        public int recordsTotal { get; set; }
    }
}
