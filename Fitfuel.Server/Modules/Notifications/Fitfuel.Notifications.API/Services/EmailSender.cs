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

    public async Task<ErrorOr<Success>> SendAsync(string email, string receiver, string message)
    {
        if (!email.IsValidEmail())
            return Errors.EmailSender.EmailNotValid;

        var emailMessage = new MimeMessage();

        var emailName = _emailOptions.EmailName;
        var emailPassword = _emailOptions.Password;
        var emailAddress = _emailOptions.Email;
        
        emailMessage.From.Add(new MailboxAddress(emailName, emailAddress));
        emailMessage.To.Add(new MailboxAddress("", email));
        emailMessage.Subject = receiver;
        emailMessage.Body = new TextPart(TextFormat.Html)
        {
            Text = message
        };

        using var client = new SmtpClient(new ProtocolLogger("smtp.log"));
        await client.ConnectAsync(_emailOptions.SmtpAddress, _emailOptions.SmtpPort, true);
        await client.AuthenticateAsync(emailAddress, emailPassword);
        try
        {
            await client.SendAsync(emailMessage);
        }
        catch (Exception)
        {
            _logger.LogError("Sending a message: \'{Message}\' to: \'{Receiver}\' failed...", message, receiver);
            return Errors.EmailSender.EmailNotFound;
        }

        await client.DisconnectAsync(true);
        _logger.LogInformation("Sending an email to: \'{Receiver}\', message: \'{Message}\'...", receiver, message);
        return new Success();
    }
}