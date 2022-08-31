using Exsm3945_Assignment.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exsm3945_Assignment.Models
{
    [Table("client")]
    public partial class Client
    {
        public Client()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        [Column("ID", TypeName = "int(11)")]
        public int Id { get; set; }
        [Column("First_Name")]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [Column("Last_Name")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [Column("DOB")]
        public DateOnly Dob { get; set; }
        [Column("Address")]
        [StringLength(250)]
        public string Address { get; set; } = null!;

        [NotMapped]
        public decimal TotalDeposits
        {
            get
            {
                decimal total = 0.00m;
                using (ApplicationDbContext dbcntxt = new())
                {
                    foreach (Account account in dbcntxt.Accounts.ToList())
                    {
                        if (account.ClientId == this.Id)
                        {
                            total += account.Balance;
                        }
                    }
                }
                return total;
            }
        }


        [NotMapped]
        public bool VIPClient
        {
            get
            {
                return this.TotalDeposits >= 100000.00m;
            }
        }

        [InverseProperty("Client")]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
