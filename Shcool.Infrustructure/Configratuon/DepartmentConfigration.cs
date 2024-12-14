using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shcool.Data.Entity;

namespace Shcool.Data.Configratuon
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DID);
            builder.HasMany(x => x.Students)
                   .WithOne(x => x.Department)
                   .HasForeignKey(x => x.DID).OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Instructor)
                   .WithOne(x => x.departmentManger)
                   .HasForeignKey<Department>(x => x.InsManger).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
