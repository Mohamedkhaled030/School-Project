using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Shcool.Data.Entity;
using Shcool.Data.Entity.Identity;
using Shcool.Data.Entity.Views;
using System.Reflection;



namespace Shcool.Infrustructure.Application_Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private readonly IEncryptionProvider _provider;


        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this._provider = new GenerateEncryptionProvider("11890720b7c04538b521e470a4605f33bbdf672c2");
        }
        public DbSet<User> users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }
        #region view
        public DbSet<ViewDepartment>  viewDepartment { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //modelBuilder.UseEncryption(_provider);
        }


    }
}
