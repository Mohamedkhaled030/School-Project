﻿namespace Shcool.Core.Featuers.Students.Queries.Results
{
    public class GetSingleStudentResponse
    {
        public int StudID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string? DepartmentName { get; set; }

    }
}
