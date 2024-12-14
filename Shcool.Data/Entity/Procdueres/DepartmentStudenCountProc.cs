namespace Shcool.Data.Entity.Procdueres
{
    public class DepartmentStudenCountProc
    {
        public string DID { get; set; }
        public string? DName { get; set; }
        public int? StudentCount { get; set; }
    }
    public class DepartmentStudenCountProcParameters
    {
        public string DiD { get; set; } = "0";
    }
}
