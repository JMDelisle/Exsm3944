using Exsm3945_Assignment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//^[a-zA-Z]{1,15}$
//@"^[a-zA-Z.-]{1,15}$"
namespace Exsm3945_Assignment.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AccountType> AccountTypes { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;database=csharp2_assignment_jeanmarc", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<AccountType>()
               .HasData(new AccountType { Id = 1, Name = "Chequing", InterestRate = 0.35m },
                       new AccountType { Id = 2, Name = "Savings", InterestRate = 0.86m },
                       new AccountType { Id = 3, Name = "Retirement", InterestRate = 1.50m }
                      );

            modelBuilder.Entity<Client>()
              .HasData(new Client
              {
                  Id = 1,
                  FirstName = "Johnny",
                  LastName = "English",
                  Dob = new DateOnly(1958, 03, 05),
                  Address = "151 Military Ave"
              },
                       new Client
                       {
                           Id = 2,
                           FirstName = "Kirk ",
                           LastName = "Grimes",
                           Dob = new DateOnly(1960, 05, 22),
                           Address = "915 Halifax Rd."
                       },
                       new Client
                       {
                           Id = 3,
                           FirstName = "Izzie ",
                           LastName = "Cash",
                           Dob = new DateOnly(1963, 06, 04),
                           Address = "919 Old Theatre Court"
                       },
                       new Client
                       {
                           Id = 4,
                           FirstName = "Lachlan ",
                           LastName = "Kent",
                           Dob = new DateOnly(1964, 10, 30),
                           Address = "7363 South Gulf St"
                       }
                      );

            modelBuilder.Entity<Account>()
              .HasData(new Account()
              {
                  Id = 1,
                  ClientId = 1,
                  AccountTypeId = 1,
                  Balance = 15693.15m,// added so you can view it on website, otherwise it wouldn't be here!!
                  InterestAppliedDate = new DateTime(1998, 01, 09)
              },
                       new Account()
                       {
                           Id = 2,
                           ClientId = 1,
                           AccountTypeId = 2,
                           Balance = 54789.00m,// added so you can view it on website, otherwise it wouldn't be here!!
                           InterestAppliedDate = new DateTime(1979, 5, 25)
                       },
                       new Account()
                       {
                           Id = 3,
                           ClientId = 2,
                           AccountTypeId = 3,
                           Balance = 1000000000.25m,// added so you can view it on website, otherwise it wouldn't be here!!
                           InterestAppliedDate = new DateTime(2004, 04, 28)
                       },
                       new Account()
                       {
                           Id = 4,
                           ClientId = 3,
                           AccountTypeId = 2,
                           Balance = 35607.78m,// added so you can view it on website, otherwise it wouldn't be here!!
                           InterestAppliedDate = new DateTime(2010, 08, 03)
                       },
                       new Account()
                       {
                           Id = 5,
                           ClientId = 3,
                           AccountTypeId = 1,
                           Balance = 505.25m,// added so you can view it on website, otherwise it wouldn't be here!!
                           InterestAppliedDate = new DateTime(2001, 05, 16)
                       },
                       new Account()
                       {
                           Id = 6,
                           ClientId = 4,
                           AccountTypeId = 2,
                           Balance = 255803.01m,// added so you can view it on website, otherwise it wouldn't be here!!
                           InterestAppliedDate = new DateTime(2008, 02, 14)
                       },
                       new Account()
                       {
                           Id = 7,
                           ClientId = 2,
                           AccountTypeId = 3,
                           Balance = 103678.23m,// added so you can view it on website, otherwise it wouldn't be here!!
                           InterestAppliedDate = new DateTime(2019, 10, 05)
                       }
                      );

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_2");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("account_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}