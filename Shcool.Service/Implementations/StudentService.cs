using Microsoft.EntityFrameworkCore;
using Serilog;
using Shcool.Data.Entity;
using Shcool.Data.Enum;
using Shcool.Infrustructure.Abstruct;
using Shcool.Service.Abstruct;

namespace Shcool.Service.Implementations
{
    public class StudentService : IstudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #region Handel function 

        public async Task<List<Data.Entity.Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsListstAsync();
        }

        public async Task<Data.Entity.Student?> GetStudentByIdWithIncloudAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                                             .Include(x => x.Department)
                                             .Where(St => St.StudID == id).FirstOrDefault();
            return student;
        }
        public async Task<string> AddAsync(Data.Entity.Student student)
        {
            //check name exiest or not
            var studentResult = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(student.Name)).FirstOrDefaultAsync();
            if (studentResult != null)
                return "Exist";

            await _studentRepository.AddAsync(student);
            return "Success";
        }


        public async void IsNameExist(string name)
        {
            string result = "";
            var NameExiest = _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (NameExiest != null)
                result = "Exite";
            else result = "Sucsees";

        }
        public async Task<string> IsNameExiestEdite(int id, string name)
        {
            var NameExiest = await _studentRepository.GetTableNoTracking().Where(x => x.Name.Equals(name) & !x.StudID.Equals(id)).FirstOrDefaultAsync();
            if (NameExiest == null)
                return "Exist";
            return "Success";
        }

        public async Task<string> UpdateStudentAsync(Student student)
        {
            //var checkName = IsNameExiestEdite(student.StudID, student.Name);
            //if (checkName != null)
            //    return "Exist";
            var studentResult = await _studentRepository.GetTableNoTracking().
                Where(x => x.Name.Equals(student.Name) & !x.StudID.Equals(student.StudID)).FirstOrDefaultAsync();
            if (studentResult != null)
                return "Exist";
            await _studentRepository.UpdateAsync(student);
            return "Sucsses";
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<string> DleteStudentAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                trans.Commit();
                return "Sucsses";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error("Delete Student", ex.Message);
                return "Falied";
            }
        }

        public IQueryable<Student> GetAllStudentsQueryable()
        {
            return _studentRepository.GetTableNoTracking().AsQueryable();
        }
        public IQueryable<Student> GetAllStudentsbyDepartmentIdQueryable(int id)
        {
            return _studentRepository.GetTableNoTracking().Where(x => x.DID == id).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderEnum studentOrder, string? Search)
        {
            var Querybale = _studentRepository.GetTableNoTracking().AsQueryable();
            if (Search != null)
            {
                Querybale = Querybale.Where(x => x.Name.Equals(Search) || x.Address.Equals(Search));
            }
            switch (studentOrder)
            {
                case StudentOrderEnum.StudID:
                    Querybale = Querybale.OrderBy(x => x.StudID);
                    break;
                case StudentOrderEnum.Name:
                    Querybale = Querybale.OrderBy(x => x.Name);
                    break;
                case StudentOrderEnum.Address:
                    Querybale = Querybale.OrderBy(x => x.Address);
                    break;
                case StudentOrderEnum.DepartmentName:
                    Querybale = Querybale.OrderBy(x => x.Department.DName);
                    break;
            }
            return Querybale;
        }



        #endregion

    }
}
