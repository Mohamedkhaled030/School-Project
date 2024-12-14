using Microsoft.EntityFrameworkCore;

namespace Shcool.Data.Entity.Views
{
    [Keyless]
    public class ViewDepartment
    {
        public string DID { get; set; }
        public string? DName { get; set; }
        public int? StudentCount { get; set; }
    }
}
