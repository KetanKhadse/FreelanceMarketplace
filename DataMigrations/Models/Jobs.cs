using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Jobs
    {
        public string jobId { get; set; }
        public string title { get; set; }
        public string descriPtion { get; set; }

        public string postedBy { get; set; }

        public string applicationId {  get; set; }
    }
}
