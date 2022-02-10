using SendGrid;
using SendGrid.Helpers.Mail;

namespace DesafioSky.Services;

public class EmailService
{
    public void Send()
    {
        try
        {
            // ToDo hidden sensity informations
<<<<<<< HEAD
            var apiKey = "API KEY sendgrid";
=======
            var apiKey = "suachave";
>>>>>>> 58caf55944224921f961ba651377d4587eb9c084
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("email remetente", "usuário remetente");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("email destino", "Usuário destino");
            var plainTextContent = "Cuidado, observe o inventório";
            var htmlContent = "Cuidado, observe o inventório";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response =  client.SendEmailAsync(msg);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
