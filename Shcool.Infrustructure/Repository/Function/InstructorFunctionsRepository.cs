using Shcool.Infrustructure.Abstruct.Function;
using Shcool.Infrustructure.Application_Data;
using System.Data.Common;

namespace Shcool.Infrustructure.Repository.Function
{
    public class InstructorFunctionsRepository : IInstructorFunctionsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public InstructorFunctionsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public decimal GetSalarySummationOfInstructor(string query, DbCommand cmd)
        {
            decimal respons = 0;
            cmd.CommandText = query;
            var value = cmd.ExecuteScalar();
            var result = value.ToString();
            if (decimal.TryParse(result, out decimal d))
                respons = d;

            return respons;

        }
    }
}
