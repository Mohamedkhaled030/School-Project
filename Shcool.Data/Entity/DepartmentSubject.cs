using System.ComponentModel.DataAnnotations.Schema;

namespace Shcool.Data.Entity
{
    public class DepartmetSubject
    {


        public int DID { get; set; }

        public int SubID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Department? Department { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("DepartmetsSubjects")]
        public virtual Subjects? Subjects { get; set; }
    }
}
