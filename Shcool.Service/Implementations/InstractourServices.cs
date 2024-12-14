using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Shcool.Data.Entity;
using Shcool.Infrustructure.Abstruct;
using Shcool.Infrustructure.Abstruct.Function;
using Shcool.Infrustructure.Application_Data;
using Shcool.Service.Abstruct;
using System.Data;

namespace Shcool.Service.Implementations
{
    public class InstractourServices : IInstractourServices
    {
        private readonly IInstractourRepository _InstractourRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IformServices _IfileService;
        private readonly IInstructorFunctionsRepository _instructorFunctionsRepository;
        private readonly ApplicationDbContext _dbContext;

        public InstractourServices(IInstractourRepository instractourRepository, IHttpContextAccessor httpContextAccessor,
            IformServices ifileService, IInstructorFunctionsRepository instructorFunctionsRepository,
            ApplicationDbContext dbContext)
        {
            _InstractourRepository = instractourRepository;
            _httpContextAccessor = httpContextAccessor;
            _IfileService = ifileService;
            _instructorFunctionsRepository = instructorFunctionsRepository;
            _dbContext = dbContext;
        }
        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _InstractourRepository.GetTableNoTracking().ToListAsync();

        }
        public async Task<Instructor> GetInstructorByIdAsync(int id)
        {
            return await _InstractourRepository.GetByIdAsync(id);
        }
        public async Task<string> AddInstructorAsync(Instructor Instructor, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseurl = context.Scheme + "://" + context.Host;
            var imageUrl = await _IfileService.UploadImage("Instractors", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FaildUpload": return "FaildUpload";
            }
            Instructor.Image = baseurl + imageUrl;
            try
            {

                await _InstractourRepository.AddAsync(Instructor);
                return "Success";
            }
            catch (Exception)
            {
                return "Faild";
            }
        }


        public async Task<string> UpdateInstructorAsync(Instructor Instructor)
        {
            await _InstractourRepository.UpdateAsync(Instructor);

            return "Success";
        }
        public async Task<string> DleteInstructorAsync(Instructor Instructor)
        {
            var trans = _InstractourRepository.BeginTransaction();
            try
            {
                await _InstractourRepository.DeleteAsync(Instructor);
                await trans.CommitAsync();
                return "Success";

            }
            catch
            {
                await trans.RollbackAsync();
                return "Faild";
            }
        }

        public Task<decimal> GetSalarySummationOfInstructor()
        {
            decimal result = 0;
            using (var cmd = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                result = _instructorFunctionsRepository.GetSalarySummationOfInstructor("Select dbo.GetSalarySummation()", cmd);

            }
            return Task.FromResult(result);
        }
    }
}
