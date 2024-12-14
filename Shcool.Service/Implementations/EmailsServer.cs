using MailKit.Net.Smtp;
using MimeKit;
using Shcool.Data.Helper;
using Shcool.Service.Abstruct;




namespace Shcool.Service.Implementations
{
    public class EmailsServer : IEmailsService
    {
        private readonly emailSettings _emailSettings;

        public EmailsServer(emailSettings emailSettings)
        {
            _emailSettings = emailSettings;
        }
        public async Task<string> SendEmailAsync(string email, string Massege, string reason)
        {
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                    client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Massege}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Future Team", _emailSettings.FromEmail));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "no sumbmited" : reason;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }

        }
    }
}
