using Fitfuel.Notifications.API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ErrorOr;
using Fitfuel.Notifications.API.Common.Errors;
using Fitfuel.Notifications.API.Common.Utils;
using MimeKit;
using MimeKit.Text;
using MailKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Fitfuel.Notifications.API.Services;

internal sealed class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    private readonly EmailOptions _emailOptions;

    public EmailSender(ILogger<EmailSender> logger, IOptions<EmailOptions> emailOptions)
    {
        _logger = logger;
        _emailOptions = emailOptions.Value;
    }

    public async Task<ErrorOr<Success>> SendAsync(string email, string subject, string message)
    {
        if (!email.IsValidEmail())
            return Errors.EmailSender.EmailNotValid;
        
        using var client = new SmtpClient(new ProtocolLogger(EmailOptions.SmtpLogFilePath));
        await client.ConnectAsync(_emailOptions.SmtpAddress, _emailOptions.SmtpPort, true);
        await client.AuthenticateAsync(_emailOptions.Email, _emailOptions.Password);
        
        var emailMessage = new MimeMessage() 
        { 
            Subject = subject, 
            Body = new TextPart(TextFormat.Html) 
            {
                Text = message
            }
        };
        emailMessage.From.Add(new MailboxAddress(_emailOptions.EmailName, _emailOptions.Email));
        emailMessage.To.Add(new MailboxAddress("", email));
        
        try
        {
            await client.SendAsync(emailMessage);
        }
        catch (Exception)
        {
            _logger.LogError("Sending a message: \'{Message}\' to: \'{Email}\' failed...", message, email);
            return Errors.EmailSender.EmailNotFound;
        }

        await client.DisconnectAsync(true);
        _logger.LogInformation("Sending an email to: \'{Email}\', message: \'{Message}\'...", email, message);
        return new Success();
    }
}