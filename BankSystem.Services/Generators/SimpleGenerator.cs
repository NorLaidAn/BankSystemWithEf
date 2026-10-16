using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class SimpleGenerator : IUniqueNumberGenerator
{
    private static int counter = 1234567890; // тут в теории можно и тип побольше поставить, но думаю этого для учебного проекта хватит
    public static SimpleGenerator Instance { get; }

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    private SimpleGenerator()
    {
    }

    public string Generate()
    {
        counter++;
        return CryptoHelper.GenerateHash(
            counter.ToString(CultureInfo.InvariantCulture));
    }
}
