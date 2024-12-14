using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shcool.Data.Entity;

namespace Shcool.Data.Configratuon
{
    public class DepartmentSubjectConfigration : IEntityTypeConfiguration<DepartmetSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.DID });
            builder.HasOne(x => x.Department)
                   .WithMany(x => x.DepartmentSubjects)
                   .HasForeignKey(x => x.DID).OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Subjects)
                   .WithMany(x => x.DepartmetsSubjects)
                   .HasForeignKey(x => x.SubID);
        }
    }
}
