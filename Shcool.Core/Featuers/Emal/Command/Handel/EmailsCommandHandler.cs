using MediatR;
using Shcool.Core.Bases;
using Shcool.Core.Featuers.Emal.Command.Model;
using Shcool.Service.Abstruct;

namespace Shcool.Core.Featuers.Emal.Command.Handel
{
    public class EmailsCommandHandler : ResponseHandler, IRequestHandler<SendEmailComamnd, Response<string>>
    {
        private readonly IEmailsService _emailsServer;

        public EmailsCommandHandler(IEmailsService emailsServer)
        {
            _emailsServer = emailsServer;
        }

        public async Task<Response<string>> Handle(SendEmailComamnd request, CancellationToken cancellationToken)
        {
            var result = await _emailsServer.SendEmailAsync(request.Email, request.Massege, null);
            if (result == "Success") return Success<string>("");
            return BadRequest<string>("Faild Send");

        }
    }
}
