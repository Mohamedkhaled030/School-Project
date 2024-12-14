using AutoMapper;
using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Instructor.Commands.Model;
using Shcool.Service.Abstruct;


namespace Shcool.Core.Featuers.Instructor.Commands.Handlers
{
    public class AddInstructorHandelr : ResponseHandler, IRequestHandler<AddInstructorCommand, Response<string>>
    {
        private readonly IInstractourServices _instractourServices;
        private readonly IMapper _mapper;

        public AddInstructorHandelr(IInstractourServices instractourServices, IMapper mapper)
        {
            _instractourServices = instractourServices;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddInstructorCommand request, CancellationToken cancellationToken)
        {
            var Instractor = _mapper.Map<Shcool.Data.Entity.Instructor>(request);
            var result = await _instractourServices.AddInstructorAsync(Instractor, request.Image);
            switch (result)
            {
                case "NoImage": return BadRequest<string>("No Image");
                case "FaildUpload": return BadRequest<string>("Faild Upload");
                case "Faild": return BadRequest<string>("Faild Upload");
            }
            return Success("");
        }
    }
}
