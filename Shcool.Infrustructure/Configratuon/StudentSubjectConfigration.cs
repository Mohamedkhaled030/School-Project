using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shcool.Data.Entity;

namespace Shcool.Data.Configratuon
{
    public class StudentSubjectConfigration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.StudID });
            builder.HasOne(ds => ds.Student)
                  .WithMany(d => d.studentSubjects)
                  .HasForeignKey(ds => ds.StudID);

            builder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.StudentsSubjects)
                 .HasForeignKey(ds => ds.SubID);
        }
    }
}
