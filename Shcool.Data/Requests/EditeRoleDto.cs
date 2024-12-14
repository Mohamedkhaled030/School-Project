using System.ComponentModel.DataAnnotations;

namespace Shcool.Data.Dtos
{
    public class EditeRoleDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
