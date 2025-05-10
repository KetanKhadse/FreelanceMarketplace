using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Applications
    {
        [Key]
        public string applicationId {  get; set; }
        [Required]
        public string applicantName { get; set; }
        [Required]
        public string applicationFile {  get; set; }

    }
}
