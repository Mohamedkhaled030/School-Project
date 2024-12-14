using MediatR;
using Shcool.Core.Bases;

namespace Shcool.Core.Featuers.Instructor.Query.Model
{
    public class GetSalarySummationQuery : IRequest<Response<decimal>>
    {
    }
}
