using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Areas.Identity.Data;
using MyStore.Models;

namespace MyStore.Areas.Identity.Data;

public class MyStoreDbContext : IdentityDbContext<MyStoreUser>
{

    public DbSet<CategoryDM> categories { get; set; }
    public DbSet<ProductDM> products { get; set; }
    public DbSet<ProductCategoryDM> productcategories { get; set; }

    public MyStoreDbContext(DbContextOptions<MyStoreDbContext> options)
        : base(options)
    {
    }

   
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

internal class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<MyStoreUser>
{
    void IEntityTypeConfiguration<MyStoreUser>.Configure(EntityTypeBuilder<MyStoreUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);
        
    }
}