using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Jobs
    {
        [Key]
        public string jobId { get; set; }
        [Required]
        public string title { get; set; }
                                 
        public string? descriPtion { get; set; }
        [Required]
        public string postedBy { get; set; }

        public string? applicationId {  get; set; }

        public DateTime? createdOn { get; set; }= DateTime.Now;
    }
}
