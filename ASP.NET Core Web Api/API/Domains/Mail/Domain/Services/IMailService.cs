namespace API.Domains.Mail.Domain.Services;

public interface IMailService
{
   void Send(string subject, string message);
}
