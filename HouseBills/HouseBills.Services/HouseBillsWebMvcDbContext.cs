
using HouseBills.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;


namespace HouseBills.Infrastructure;

public class HouseBillsWebMvcDbContext : IdentityDbContext<UserApp>
{
    public DbSet<Bill> Bills { get; set; } = default!;

    public HouseBillsWebMvcDbContext(DbContextOptions<HouseBillsWebMvcDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=DataBills;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AppUserEntityConfiguration());
    }
}
public class AppUserEntityConfiguration : IEntityTypeConfiguration<UserApp>
{
    
    public void Configure(EntityTypeBuilder<UserApp> builder)
    {
        
        builder.Property(p => p.FirstName).HasMaxLength(50);
        builder.Property(p => p.LastName).HasMaxLength(50);
    }
}

