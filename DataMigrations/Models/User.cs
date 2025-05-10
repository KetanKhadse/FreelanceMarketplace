using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class User
    {
        [Key]
        public string userId { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string userPassword { get; set; }
        [Required]
        public string userEmail { get; set; }
        public string UserRole { get; set; }

        public DateTime createdDate { get; set; }= DateTime.Now;


    }
}
