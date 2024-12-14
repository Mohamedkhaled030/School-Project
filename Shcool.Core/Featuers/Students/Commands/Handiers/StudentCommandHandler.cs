using AutoMapper;
using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Students.Commands.Models;
using Shcool.Data.Entity;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Students.Commands.Handiers
{
    public class StudentCommandHandler : ResponseHandler, IRequestHandler<AddStudenCommand, Response<string>>,
                                                          IRequestHandler<EditeStudenCommand, Response<string>>,
                                                          IRequestHandler<DeleteStudenCommand, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly IstudentServices _IStudentServices;

        public StudentCommandHandler(IMapper mapper, IstudentServices istudentServices)
        {
            _mapper = mapper;
            _IStudentServices = istudentServices;
        }
        public async Task<Response<string>> Handle(AddStudenCommand request, CancellationToken cancellationToken)
        {
            //mapping between Requst and student
            var studentMapping = _mapper.Map<Student>(request);
            //Add
            var Result = await _IStudentServices.AddAsync(studentMapping);
            //Check Condition
            if (Result == "Exist") return UnprocessableEntity<string>("The Name Is Exist");
            //return Response
            else if (Result == "Success") return Created("Add Successfuly");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditeStudenCommand request, CancellationToken cancellationToken)
        {
            //check the Id Exist Or Not
            var student = _IStudentServices.GetStudentByIdWithIncloudAsync(request.Id);
            if (student == null)
                return NotFound<string>("Student Is Not Found");
            //Mapping betwwen student reqest 
            var studentMapping = await _mapper.Map(request, student);
            //Update
            var Result = await _IStudentServices.UpdateStudentAsync(studentMapping);

            if (Result == "Exist") return UnprocessableEntity<string>("The Name Is Exist");
            //return Respobse
            else if (Result == "Sucsses") return Success($"Update Successfuly {studentMapping.StudID}");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudenCommand request, CancellationToken cancellationToken)
        {
            var student = await _IStudentServices.GetStudentByIdAsync(request.id);
            if (student == null) return NotFound<string>("Student Not Found");

            var Result = await _IStudentServices.DleteStudentAsync(student);

            if (Result == "Sucsses") return Deleted<string>($"Delete Successfuly {student.StudID}");
            else return BadRequest<string>();


        }
    }
}
