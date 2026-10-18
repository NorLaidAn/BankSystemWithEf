using System.Globalization;
using BankSystem.Services.Helpers;

namespace BankSystem.Services.Generators;

public class BasedOnTickUniqueNumberGenerator : IUniqueNumberGenerator
{
    #region Properties

    private DateTime startingPoint { get; }

    #endregion

    #region Constructors

    public BasedOnTickUniqueNumberGenerator(DateTime startingPoint)
    {
        this.startingPoint = startingPoint;
    }

    #endregion

    #region Methods

    public string Generate()
    {
        return CryptoHelper.GenerateHash(
            (DateTime.UtcNow.Ticks - this.startingPoint.Ticks)
            .ToString(CultureInfo.InvariantCulture));
    }

    #endregion
}
