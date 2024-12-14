using AutoMapper;
using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Instructor.Query.Model;
using Shcool.Core.Featuers.Instructor.Query.Result;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Instructor.Query.Handlers
{
    public class InstructorHandler : ResponseHandler, IRequestHandler<GetListInstructorQuery, Response<List<GetInstructorListResponse>>>,
                                                      IRequestHandler<GetSalarySummationQuery, Response<decimal>>
    {
        private readonly IMapper _mapper;
        private readonly IInstractourServices _InstractourServices;

        public InstructorHandler(IMapper mapper, IInstractourServices instractourServices)
        {
            this._mapper = mapper;
            this._InstractourServices = instractourServices;
        }

        public async Task<Response<List<GetInstructorListResponse>>> Handle(GetListInstructorQuery request, CancellationToken cancellationToken)
        {
            var InstractorList = await _InstractourServices.GetAllInstructorsAsync();
            var InstractorMapping = _mapper.Map<List<GetInstructorListResponse>>(InstractorList);
            return Success(InstractorMapping);
        }

        public async Task<Response<decimal>> Handle(GetSalarySummationQuery request, CancellationToken cancellationToken)
        {
            var result = await _InstractourServices.GetSalarySummationOfInstructor();
            return Success(result);
        }
    }
}
