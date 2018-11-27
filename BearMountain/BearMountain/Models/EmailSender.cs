using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearMountain.Models
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task SendEmailAsync(string recipient, string subject, string message)
        {
            var client = new SendGridClient(Configuration["SendGrid_Api_Key"]);

            var from = new EmailAddress("admin@BearMountain.com");

            EmailAddress to = new EmailAddress(recipient);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, message);

            var response = await client.SendEmailAsync(msg);
        }
    }
}
