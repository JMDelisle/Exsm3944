using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace Exsm3945_Assignment.Models
{
    [Table("account")]
    [Index("AccountTypeId", Name = "Account_Type_ID")]
    [Index("ClientId", Name = "Client_ID")]
    public partial class Account
    {
        /*public Account(decimal balance)
        {
            Balance = balance;
        }*/

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("Client_ID", TypeName = "int(11)")]
        public int ClientId { get; set; }
        [Column("Account_Type_ID", TypeName = "int(11)")]
        public int AccountTypeId { get; set; }
        [Column("Interest_Applied_Date")]
        public DateTime? InterestAppliedDate { get; set; }
        [Precision(10, 2)]
        public decimal Balance { get; set; }

        [NotMapped]
        public string appliedDate => InterestAppliedDate.ToString();

        public decimal ApplyInterest()
        {
            bool vip = this.Client.VIPClient;
            decimal apply_rate = this.AccountType.InterestRate;
            if (vip) { apply_rate += 1.00m; }
            Balance = Decimal.Round(Balance * (1.00m + apply_rate / 100.00m), 2);
            return Balance;
        }


        public decimal Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\n\n*** DEPOSIT AMOUNT MUST BE POSITIVE ***\n\n");
            }
            else
            {
                Balance = Decimal.Round(Balance + amount, 2);
            }
            return Balance;
        }


        public decimal Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\n\n\t\tYou can NOT WITHDRAW a negative Number!!*** AMOUNT MUST BE POSITIVE ***\n\n");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("\n\nt\tNot enough money to make that transaction!!!\n\n");
            }
            else
            {
                Balance = Decimal.Round(Balance - amount, 2);
            }
            return Balance;
        }

        [ForeignKey("AccountTypeId")]
        [InverseProperty("Accounts")]
        public virtual AccountType AccountType { get; set; } = null!;
        [ForeignKey("ClientId")]
        [InverseProperty("Accounts")]
        public virtual Client Client { get; set; } = null!;
    }
}