using Shcool.Data.Entity.Views;
using Shcool.Infrustructure.InfrustructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shcool.Infrustructure.Abstruct.Views
{
    public interface IViewDepartmentRepository<T>:IGenericRepositoryAsync<T> where T : class
    {
    }
}
