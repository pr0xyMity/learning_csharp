using API.Domains.Mail.Domain.Services;
namespace API.Domains.Mail.Data;

public class CloudMailService : IMailService
{
   private string _mailTo = "admin@mail.com";
   private string _mailFrom = "noreply@mail.com";

   public void Send(string subject, string message)
   {
      Console.WriteLine($"Mail from {_mailFrom} to {_mailTo} via cloud");
      Console.WriteLine($"Subject: {subject}");
      Console.WriteLine($"Message: {message}");
      Console.WriteLine("Sending mail...");
   }
}