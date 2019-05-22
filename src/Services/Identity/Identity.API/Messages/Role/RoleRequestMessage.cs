using System.ComponentModel.DataAnnotations;

namespace Identity.API.Messages.Role
{
    public class RoleRequestMessage
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string NormalizedName{ get; set; }
    }
}
