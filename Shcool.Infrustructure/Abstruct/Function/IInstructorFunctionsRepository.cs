using System.Data.Common;

namespace Shcool.Infrustructure.Abstruct.Function
{
    public interface IInstructorFunctionsRepository
    {
        public decimal GetSalarySummationOfInstructor(string query, DbCommand Cmd);
    }
}
