using API.Domains.Mail.Domain.Services;
namespace API.Domains.Mail.Data;

public class LocalMailService : IMailService
{
   private string _mailTo = String.Empty;
   private string _mailFrom = String.Empty;

   public LocalMailService(IConfiguration configuration)
   {
      _mailTo = configuration["mailSettings:mailToAddress"];
      _mailFrom = configuration["mailSettings:mailFromAddress"];
   }

   public void Send(string subject, string message)
   {
      Console.WriteLine($"Mail from {_mailFrom} to {_mailTo} via local email");
      Console.WriteLine($"Subject: {subject}");
      Console.WriteLine($"Message: {message}");
      Console.WriteLine("Sending mail...");
   }
}