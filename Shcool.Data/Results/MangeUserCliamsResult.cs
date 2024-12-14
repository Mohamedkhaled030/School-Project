namespace Shcool.Data.Results
{
    public class MangeUserCliamsResult
    {
        public string UserId { get; set; }
        public List<UserCliams> userCliams { get; set; }
    }
    public class UserCliams
    {

        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
