using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Students.Queries.Models;
using Shcool.Core.Featuers.Students.Queries.Results;
using Shcool.Core.Resourse;
using Shcool.Core.Warrapers;
using Shcool.Data.Entity;
using Shcool.Service.Abstruct;
using System.Linq.Expressions;

namespace Shcool.Core.Featuers.Students.Queries.Handlier
{
    public class StudentHandler : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                                   IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>,
                                                   IRequestHandler<GetStudentPaginatedQuery, PaginatedResult<GetStudentPagnitedListResponse>>
    {
        private readonly IstudentServices _IstudentServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResoursed> _StringLocalizer;

        public StudentHandler(IstudentServices IstudentServices, IMapper mapper, IStringLocalizer<SharedResoursed> StringLocalizer)
        {
            _IstudentServices = IstudentServices;
            _mapper = mapper;
            _StringLocalizer = StringLocalizer;

        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _IstudentServices.GetStudentsAsync();
            var StudentMapping = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success(StudentMapping);
        }


        async Task<Response<GetSingleStudentResponse>> IRequestHandler<GetStudentByIdQuery, Response<GetSingleStudentResponse>>.Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _IstudentServices.GetStudentByIdWithIncloudAsync(request.id);
            if (student == null) return NotFound<GetSingleStudentResponse>(_StringLocalizer[ShareResoursesKeys.NotFound]);
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }
        public async Task<PaginatedResult<GetStudentPagnitedListResponse>> Handle(GetStudentPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPagnitedListResponse>> exception = e => new GetStudentPagnitedListResponse
                                                                                 (e.StudID, e.Name, e.Address, e.Phone, e.Department.DName); ;
            var Quarble = _IstudentServices.GetAllStudentsQueryable();
            var FilterSearch = _IstudentServices.FilterStudentPaginatedQuerable(request.OrderBy, request.SearchBy);
            var PaginetList = await FilterSearch.Select(exception).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return PaginetList;
        }
    }
}
