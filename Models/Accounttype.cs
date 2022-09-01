using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Exsm3945_Assignment.Data;

namespace Exsm3945_Assignment.Models
{
    [Table("account_type")]
    public partial class AccountType
    {
        public AccountType()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [StringLength(15)]
        public string Name { get; set; } = null!;
        [Column("Interest_Rate")]
        [Precision(10, 2)]
        public decimal InterestRate { get; set; }


        [InverseProperty("AccountType")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
