namespace Shcool.Service.Abstruct
{
    public interface IEmailsService
    {
        public Task<string> SendEmailAsync(string email, string Massege, string reason);
    }
}
