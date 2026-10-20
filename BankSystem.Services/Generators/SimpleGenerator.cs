using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class SimpleGenerator : IUniqueNumberGenerator
{
    #region Fields

    // тут в теории можно и тип побольше поставить, но думаю этого для учебного проекта хватит
    // а ещё интересно что будет с коунтером если приложение умрет, он же по новой начнет генерировать
    private static int counter = 1234567890;

    #endregion

    #region Properties

    public static SimpleGenerator Instance { get; }

    #endregion

    #region Constructors

    static SimpleGenerator()
    {
        Instance = new SimpleGenerator();
    }

    private SimpleGenerator()
    {
    }

    #endregion

    #region Methods

    public string Generate()
    {
        counter++;
        return CryptoHelper.GenerateHash(
            counter.ToString(CultureInfo.InvariantCulture));
    }

    #endregion
}
