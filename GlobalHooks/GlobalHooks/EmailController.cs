using System.Net.Mail;

namespace GlobalHooks
{
    public class EmailController
    {
        private readonly SmtpClient _smtpClient;
        private const string Sender = "";
        private const string Password = "";

        private const string Host = "smtp.gmail.com";
        private const int Port = 587;

        public EmailController()
        {
            _smtpClient = new SmtpClient(Host, Port)
            {
                Credentials = new System.Net.NetworkCredential(Sender, Password),
                EnableSsl = true
            };
        }

        public void SendEmail(string receiver, string topic, string filePath)
        {
            var mail = new MailMessage(Sender, receiver, topic, string.Empty);
            using (var attachment = new Attachment(filePath))
            {
                mail.Attachments.Add(attachment);
                _smtpClient.Send(mail);
            }
        }
    }
}
