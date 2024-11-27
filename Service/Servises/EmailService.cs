using System;
using Lab9.Service.Interfaces;

namespace Lab9.Service.Servises
{
    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject: {subject}");
        }
    }
}