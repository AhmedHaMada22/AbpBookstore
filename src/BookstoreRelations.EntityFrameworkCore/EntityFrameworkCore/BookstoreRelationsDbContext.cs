﻿using BookstoreRelations.Authors;
using BookstoreRelations.Books;
using BookstoreRelations.Categories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace BookstoreRelations.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class BookstoreRelationsDbContext :
    AbpDbContext<BookstoreRelationsDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<AuthorEntity> Authors { get; set; }
    public DbSet<BookEntity> Books { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public BookstoreRelationsDbContext(DbContextOptions<BookstoreRelationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(BookstoreRelationsConsts.DbTablePrefix + "YourEntities", BookstoreRelationsConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
        builder.Entity<AuthorEntity>(b =>
        {
            b.ConfigureByConvention();

        });

        builder.Entity<BookEntity>(b =>
        {
            b.ConfigureByConvention();

            b.Property(x => x.Name)
                .IsRequired();

            //one-to-many relationship with Author table
            b.HasOne<AuthorEntity>().WithMany().HasForeignKey(x => x.AuthorId).IsRequired();

            //many-to-many relationship with Category table => BookCategories
            b.HasMany(x => x.BookCategoriesCollection).WithOne().HasForeignKey(x => x.BookId).IsRequired();
        });

        builder.Entity<CategoryEntity>(b =>
        {
            b.ConfigureByConvention();

            b.Property(x => x.Name)
                .IsRequired();
        });

        builder.Entity<BookCategoryEntity>(b =>
        {
            b.ConfigureByConvention();

            //define composite key
            b.HasKey(x => new { x.BookId, x.CategoryId });

            //many-to-many configuration
            b.HasOne<BookEntity>().WithMany(x => x.BookCategoriesCollection).HasForeignKey(x => x.BookId).IsRequired();
            b.HasOne<CategoryEntity>().WithMany().HasForeignKey(x => x.CategoryId).IsRequired();

            b.HasIndex(x => new { x.BookId, x.CategoryId });
        });
    }
}
