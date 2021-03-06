using Microsoft.EntityFrameworkCore;

namespace Ticket_System.Models
{
    public class TicketDBContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketAction> TicketAction { get; set; }
        public DbSet<TicketActionRules> TicketActionRules { get; set; }
        public TicketDBContext(DbContextOptions<TicketDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tickets>(ob =>
            {
                ob.Property(p => p.Summary).IsRequired();
                ob.Property(p => p.Description).IsRequired();
                ob.Property(p => p.Resolved).HasDefaultValue(false);
                ob.HasData(
                    new Tickets { TicketsId = 1, Description = "👾", Summary = "12qqqq3rrr", CreateTime = DateTime.Now, TicketTypeId = 1, UserId = 1 },
                    new Tickets { TicketsId = 2, Description = "😂", Summary = "123rttrtrrr", CreateTime = DateTime.Now, TicketTypeId = 1, UserId = 1 },
                    new Tickets { TicketsId = 3, Description = "😀", Summary = "123xxxxrrr", CreateTime = DateTime.Now, TicketTypeId = 2, UserId = 3 },
                    new Tickets { TicketsId = 4, Description = "😎", Summary = "123ssssrrr", CreateTime = DateTime.Now, TicketTypeId = 3, UserId = 1 }
                    );
            });

            modelBuilder.Entity<Role>()
                .HasData(
                new Role { RoleId = 1, Name = "QA", },
                new Role { RoleId = 2, Name = "RD", },
                new Role { RoleId = 3, Name = "PM", },
                new Role { RoleId = 4, Name = "Admin" });

            modelBuilder.Entity<Role>()
                .HasMany(p => p.TicketTypes)
                .WithMany(p => p.Roles)
                .UsingEntity<TicketTypeRules>(
                    j => j
                    .HasOne(pt => pt.TicketType)
                    .WithMany(t => t.TicketRules)
                    .HasForeignKey(pt => pt.TicketTypeId),
                    j => j
                    .HasOne(pt => pt.Role)
                    .WithMany(p => p.TicketRules)
                    .HasForeignKey(pt => pt.RoleId),
                    j =>
                    {
                        j.HasKey(t => new { t.RoleId, t.TicketTypeId });
                        j.Property(pt => pt.CreateTime).HasDefaultValueSql("GETDATE()");
                    }
                );

            modelBuilder.Entity<Role>()
                .HasMany(p => p.TicketActions)
                .WithMany(p => p.Roles)
                .UsingEntity<TicketActionRules>(
                    j => j
                    .HasOne(pt => pt.TicketAction)
                    .WithMany(t => t.TicketActionRules)
                    .HasForeignKey(pt => pt.TicketActionId),
                    j => j
                    .HasOne(pt => pt.Role)
                    .WithMany(p => p.TicketActionRules)
                    .HasForeignKey(pt => pt.RoleId),
                    j =>
                    {
                        j.HasKey(t => new { t.RoleId, t.TicketActionId });
                        j.Property(pt => pt.CreateTime).HasDefaultValueSql("GETDATE()");
                    });

            modelBuilder.Entity<TicketType>()
                .HasData(
                new TicketType { TicketTypeId = 1, Name = "Bug" },
                new TicketType { TicketTypeId = 2, Name = "Feature Request" },
                new TicketType { TicketTypeId = 3, Name = "Test Case" }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "QA", Password = "QA", UserRoleId = 1 },
                new User { Id = 2, Name = "RD", Password = "RD", UserRoleId = 2 },
                new User { Id = 3, Name = "PM", Password = "PM", UserRoleId = 3 },
                new User { Id = 4, Name = "Admin", Password = "Admin", UserRoleId = 4 }
                );

            modelBuilder.Entity<TicketAction>().HasData(
                new TicketAction { ActionId = 1, TicketTypeId = 1, ActionName = "Add" },
                new TicketAction { ActionId = 2, TicketTypeId = 1, ActionName = "Delete" },
                new TicketAction { ActionId = 3, TicketTypeId = 1, ActionName = "Edit" },
                new TicketAction { ActionId = 4, TicketTypeId = 1, ActionName = "Resolve" },
                new TicketAction { ActionId = 5, TicketTypeId = 2, ActionName = "Add" },
                new TicketAction { ActionId = 6, TicketTypeId = 2, ActionName = "Delete" },
                new TicketAction { ActionId = 7, TicketTypeId = 2, ActionName = "Edit" },
                new TicketAction { ActionId = 8, TicketTypeId = 2, ActionName = "Resolve" },
                new TicketAction { ActionId = 9, TicketTypeId = 3, ActionName = "Add" },
                new TicketAction { ActionId = 10, TicketTypeId = 3, ActionName = "Delete" },
                new TicketAction { ActionId = 11, TicketTypeId = 3, ActionName = "Edit" },
                new TicketAction { ActionId = 12, TicketTypeId = 3, ActionName = "Resolve" }
                );
            var TicketTypeRules = new List<TicketTypeRules>()
            {
                new TicketTypeRules{ RoleId = 1, TicketTypeId=1 },
                new TicketTypeRules{ RoleId = 1,  TicketTypeId= 3 },
                new TicketTypeRules{ RoleId = 3, TicketTypeId = 2},
                new TicketTypeRules{ RoleId = 4, TicketTypeId = 1},
                new TicketTypeRules{ RoleId = 4, TicketTypeId = 2},
                new TicketTypeRules{ RoleId = 4, TicketTypeId = 3},
            };
            modelBuilder.Entity<TicketTypeRules>().HasData(TicketTypeRules);

            var SystemFunctionRules = new List<TicketActionRules>()
            {
                new TicketActionRules{ RoleId = 1,   TicketActionId = 1 },
                new TicketActionRules{ RoleId = 1,   TicketActionId = 2 },
                new TicketActionRules{ RoleId = 1,   TicketActionId = 3 },
                new TicketActionRules{ RoleId = 1,   TicketActionId = 9 },
                new TicketActionRules{ RoleId = 1,   TicketActionId = 12 },
                new TicketActionRules{ RoleId = 2,   TicketActionId = 4 },
                new TicketActionRules{ RoleId = 2,   TicketActionId = 8 },
                new TicketActionRules{ RoleId = 3,   TicketActionId = 9 },
                new TicketActionRules{ RoleId = 4,   TicketActionId = 1},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 2},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 3},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 4},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 5},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 6},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 7},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 8},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 9},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 10},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 11},
                new TicketActionRules{ RoleId = 4,   TicketActionId = 12},
            };
            modelBuilder.Entity<TicketActionRules>().HasData(SystemFunctionRules);

        }
    }
}
