using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Shcool.Data.Entity.Views;
using Shcool.Infrustructure.Abstruct.Views;
using Shcool.Infrustructure.Application_Data;
using Shcool.Infrustructure.InfrustructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shcool.Infrustructure.Repository.Views
{
    public class ViewDepartmentRepository :GenericRepositoryAsync<ViewDepartment>,IViewDepartmentRepository<ViewDepartment>
    {
        private DbSet< ViewDepartment> ViewDepartment { get; set; }
        public ViewDepartmentRepository(ApplicationDbContext dbContext) :base (dbContext)
        {
            ViewDepartment =dbContext.Set<ViewDepartment>() ;
        }
    }
}
