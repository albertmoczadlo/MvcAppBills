
using HouseBills.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using System.Reflection.Emit;


namespace HouseBills.Infrastructure;

public class HouseBillsWebMvcDbContext : IdentityDbContext<UserApp>
{
    public virtual DbSet<Bill> Bills { get; set; } = default!;
    public virtual DbSet<UserApp> Users { get; set; }

    public HouseBillsWebMvcDbContext()
    {

    }
    public HouseBillsWebMvcDbContext(DbContextOptions<HouseBillsWebMvcDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=DataBills;Trusted_Connection=True;");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        
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
       
        //builder.Property(c => c.Id).HasColumnName("ID").IsRequired();
    }
}

