using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shcool.Data.Entity
{
    public class StudentSubject
    {
        [Key]

        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }

        public decimal? Degree { get; set; }
        [ForeignKey("StudID")]
        [InverseProperty("studentSubjects")]
        public virtual Student? Student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects? Subject { get; set; }

    }
}
