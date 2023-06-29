using ErrorOr;

namespace Fitfuel.Notifications.API.Common.Errors;

public static class Errors
{
    public static class EmailSender
    {
        public static Error EmailNotFound => Error.Validation(
            "EmailSender.EmailNotFound",
            "Указанного email адреса не существует");
        
        public static Error EmailNotValid => Error.Validation(
            "EmailSender.EmailNotValid",
            "Неверный email адрес");
    }
}