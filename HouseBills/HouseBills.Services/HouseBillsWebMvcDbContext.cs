using HouseBills.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseBills.WebMvc.Areas.Identity.Data;

public class HouseBillsWebMvcDbContext : IdentityDbContext<UserApp>
{
    public DbSet<Bill> Bills { get; set; } = default!;

    public HouseBillsWebMvcDbContext(DbContextOptions<HouseBillsWebMvcDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

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