using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shcool.Data.Entity;

namespace Shcool.Data.Configratuon
{
    public class Ins_SubjectConfigration : IEntityTypeConfiguration<Inst_Subject>
    {
        public void Configure(EntityTypeBuilder<Inst_Subject> builder)
        {
            builder.HasKey(x => new { x.SubId, x.InsId });

            builder.HasOne(ds => ds.instructor)
                 .WithMany(d => d.Inst_Subjects)
                 .HasForeignKey(ds => ds.InsId);

            builder.HasOne(ds => ds.Subject)
                 .WithMany(d => d.InsSubjects)
                 .HasForeignKey(ds => ds.SubId);
        }
    }
}
