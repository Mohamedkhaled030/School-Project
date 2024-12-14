using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shcool.Data.Entity
{
    public class Instructor
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Inst_Subjects = new HashSet<Inst_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        [ForeignKey("SuperVisor")]
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public string? Image { get; set; }

        public int DID { get; set; }
        [ForeignKey("DID")]
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }
        [InverseProperty("Instructor")]
        public Department? departmentManger { get; set; }


        [InverseProperty("Instructors")]
        public Instructor SuperVisor { get; set; }
        [InverseProperty("SuperVisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [InverseProperty("instructor")]
        public virtual ICollection<Inst_Subject> Inst_Subjects { get; set; }
    }
}
