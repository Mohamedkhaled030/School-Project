using Shcool.Core.Warrapers;

namespace Shcool.Core.Featuers.Department.Query.Result
{
    public class GetDepartmentIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }
        public PaginatedResult<StudentResponse>? StudentsList { get; set; }
        public List<SubjectResponse>? SubjectsList { get; set; }
        public List<InstractourResponse>? InstractoursList { get; set; }
    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class InstractourResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
