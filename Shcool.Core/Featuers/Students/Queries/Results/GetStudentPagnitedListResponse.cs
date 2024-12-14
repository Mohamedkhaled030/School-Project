namespace Shcool.Core.Featuers.Students.Queries.Results
{
    public class GetStudentPagnitedListResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }
        public GetStudentPagnitedListResponse(int studId, string name, string adress, string phone, string departName)
        {
            StudID = studId;
            Name = name;
            Address = adress;
            Phone = phone;
            DepartmentName = departName;
        }
    }
}
