using System.Net.Mail;
using System.Net;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace OdontoSchedule.Services
{
    public class EmailSender
    {
        public static bool Send(string subject, string body, string pacient)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("odontoschedule@gmail.com");
            mail.To.Add(pacient); // para
            mail.Subject = subject; // assunto
            mail.Body = body; // mensagem

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential("odontoschedule@gmail.com", "owpp knxl gpsx rozn");

                // envia o e-mail
                smtp.Send(mail);
            }
                return true;
        }
    }
}
