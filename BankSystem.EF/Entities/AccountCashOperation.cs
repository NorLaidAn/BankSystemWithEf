using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.EF.Entities;

[Table("account_cash_operation")]
public class AccountCashOperation
{
    [Key]
    [Column("account_cash_operation_id", TypeName = "int")]
    public int Id { get; set; }

    [Column("bank_account_id", TypeName = "int")]
    public int BankAccountId { get; set; }

    [Column("amount", TypeName = "real")]
    public decimal Amount { get; set; }

    [Column("operation_date_time", TypeName = "datetime")]
    public string OperationDateTime { get; set; } // странно но по заданию тут должен быть string, хотя явно выглядит как DateTime

    [Column("note", TypeName = "varchar(160)")]
    public string Note { get; set; }

    [ForeignKey(nameof(BankAccountId))]
    public BankAccount BankAccount { get; set; }
}
