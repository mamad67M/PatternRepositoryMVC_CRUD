using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_DotnetCoreMVC_CRUD.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        [StringLength(75)]
        [Required]
        public string Description { get; set; }


    }
}
