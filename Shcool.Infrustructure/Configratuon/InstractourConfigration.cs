using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shcool.Data.Entity;

namespace Shcool.Data.Configratuon
{
    public class InstractourConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasOne(x => x.SuperVisor)
                   .WithMany(x => x.Instructors)
                   .HasForeignKey(x => x.SupervisorId)
                   .OnDelete(DeleteBehavior.Restrict);

            //.HasOne(x => x.Supervisor)
            // .WithMany(x => x.Instructors)
            // .HasForeignKey(x => x.SupervisorId)
            // .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
