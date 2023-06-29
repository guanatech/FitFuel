using System.Net.Mail;

namespace Fitfuel.Notifications.API.Common.Utils;

public static class EmailUtil
{
    // TODO заменить на реализацию с email - value object
    public static bool IsValidEmail(this string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}