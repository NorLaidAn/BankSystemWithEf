using System.Globalization;
using System.Net.Mail;

namespace BankSystem.Services.Helpers;

public static class ValidationService
{
    public static bool IsCurrencyValid(this string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode) || currencyCode.Length != 3)
        {
            return false;
        }

        return CultureInfo
            .GetCultures(CultureTypes.SpecificCultures)
            .Select(culture => new RegionInfo(culture.Name).ISOCurrencySymbol)
            .Contains(currencyCode, StringComparer.OrdinalIgnoreCase);
    }

    public static bool IsEmailValid(this string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        return MailAddress.TryCreate(email, out _);
    }

    // методы вне задания для валидаации свойств
    public static T ValidateNotNull<T>(this T value, string? paramName = null)
    {
        ArgumentNullException.ThrowIfNull(value, paramName);
        return value;
    }

    public static string ValidateStringNotNullOrEmptyOrWhiteSpace(this string value, string? paramName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);
        return value;
    }
}
