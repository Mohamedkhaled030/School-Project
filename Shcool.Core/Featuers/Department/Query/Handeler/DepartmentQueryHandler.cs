using AutoMapper;
using MediatR;
using Serilog;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Department.Query.Model;
using Shcool.Core.Featuers.Department.Query.Result;
using Shcool.Core.Warrapers;
using Shcool.Data.Entity;
using Shcool.Data.Entity.Procdueres;
using Shcool.Service.Abstruct;
using System.Linq.Expressions;

namespace Shcool.Core.Featuers.Department.Query.Handeler
{
    public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentIdQuery, Bases.Response<GetDepartmentIdResponse>>,
                                                           IRequestHandler<GetDepartmentListStudentCountQuery, Response<List<GetDepartmentListStudentCountResult>>>,
                                                           IRequestHandler<GetDepartmentStudenCountByIdQuery, Response<GetDepartmentStudenCountByIdResult>>

    {
        private readonly IDepartmentServices _departmentServices;
        private readonly IMapper _mapper;
        private readonly IstudentServices _IstudentServices;

        public DepartmentQueryHandler(IDepartmentServices departmentServices, IMapper mapper, IstudentServices istudentServices)
        {
            _departmentServices = departmentServices;
            _mapper = mapper;
            _IstudentServices = istudentServices;
        }
        #region Handle Function
        public async Task<Bases.Response<GetDepartmentIdResponse>> Handle(GetDepartmentIdQuery request, CancellationToken cancellationToken)
        {
            var Response = await _departmentServices.GetDepartmentById(request.id);
            if (Response == null) return NotFound<GetDepartmentIdResponse>("Department is Not Found");

            var Mapper = _mapper.Map<GetDepartmentIdResponse>(Response);
            //pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Name);
            var StudentQueryable = _IstudentServices.GetAllStudentsbyDepartmentIdQueryable(request.id);
            var StudentPeganted = await StudentQueryable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            Mapper.StudentsList = StudentPeganted;
            Log.Information($"Get Department By Id {request.id}!");
            return Success(Mapper);

        }

        public async Task<Response<List<GetDepartmentListStudentCountResult>>> Handle(GetDepartmentListStudentCountQuery request, CancellationToken cancellationToken)
        {
            var ViewDepartmentResult = await _departmentServices.GetviewDepartmentsDataAsync();
            var Mapper = _mapper.Map<List<GetDepartmentListStudentCountResult>>(ViewDepartmentResult);
            return Success(Mapper);
        }

        public async Task<Response<GetDepartmentStudenCountByIdResult>> Handle(GetDepartmentStudenCountByIdQuery request, CancellationToken cancellationToken)
        {
            var parameter = _mapper.Map<DepartmentStudenCountProcParameters>(request);
            var ProcResult = await _departmentServices.GetDepartmentStudenCountProcs(parameter);
            var Result = _mapper.Map<GetDepartmentStudenCountByIdResult>(ProcResult.FirstOrDefault());
            return Success(Result);
        }


        #endregion
    }
}
