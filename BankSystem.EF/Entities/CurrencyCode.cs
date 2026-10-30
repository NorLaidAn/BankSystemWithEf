using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

[Table("currency_code")]
public class CurrencyCode
{
    [Key]
    [Column("currency_code_id", TypeName = "int")]
    public int Id { get; set; }

    [Column("currency_code", TypeName = "char(5)")]
    [MaxLength(5)]
    public string CurrenciesCode { get; set; }
    public IList<BankAccount> BankAccounts { get; set; }
}
