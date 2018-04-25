using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.ViewModels.Roles
{
    public class RoleVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName{ get; set; }
    }
}
