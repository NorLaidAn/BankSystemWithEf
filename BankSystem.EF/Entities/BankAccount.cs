using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

[Table("bank_account")]
public class BankAccount
{
    [Key]
    [Column("bank_account_id", TypeName = "int")]

    public int Id { get; set; }

    [Column("account_owner_id", TypeName = "int")]
    public int AccountOwnerId { get; set; }

    [Column("account_number", TypeName = "char(20)")]
    public string Number { get; set; }

    [Column("balance", TypeName = "real")]
    public decimal Balance { get; set; }

    [Column("currency_code_id", TypeName = "int")]
    public int CurrencyCodeId { get; set; }

    [Column("bonus_points", TypeName = "int")]
    public int BonusPoints { get; set; }

    [Column("overdraft", TypeName = "real")]
    public decimal Overdraft { get; set; }

    [ForeignKey(nameof(AccountOwnerId))]
    public AccountOwner AccountOwner { get; set; }

    [ForeignKey(nameof(CurrencyCodeId))]
    public CurrencyCode CurrencyCode { get; set; }
}
