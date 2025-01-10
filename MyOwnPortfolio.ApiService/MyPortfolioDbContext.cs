using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyOwnPortfolio.ApiService.Entities;
using System.Reflection;

namespace MyOwnPortfolio.ApiService
{
    public class MyPortfolioDbContext : DbContext
    {
        public MyPortfolioDbContext(DbContextOptions<MyPortfolioDbContext> options)
        : base(options)
        {
        }

        public DbSet<PortfolioType> PortfolioTypes { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MyPortal> MyPortals { get; set; }
        public DbSet<AboutMe> About { get; set; }
        public DbSet<PortfolioSummary> PortfolioSummaries { get; set; }
        public DbSet<PortfolioUser> PortfolioUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=Database\\MyPortfolioLiteDB.db", options =>
            //{
            //    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            //});

            optionsBuilder.ConfigureWarnings(warnings =>
         warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<PortfolioType>().ToTable("PortfolioType");
            modelBuilder.Entity<PortfolioType>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Type).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Description).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<MyPortal>().ToTable("MyPortal");

            modelBuilder.Entity<MyPortal>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Username).IsUnique(); 
                entity.HasIndex(e => e.Passwordhash).IsUnique();
                entity.HasIndex(e => e.Passwordsalt).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            

            modelBuilder.Entity<AboutMe>().ToTable("AboutMe");
            modelBuilder.Entity<AboutMe>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.address1);
                entity.HasIndex(e => e.address2);
                entity.HasIndex(e => e.City);
                entity.HasIndex(e => e.State);
                entity.HasIndex(e => e.Country);
                entity.HasIndex(e => e.zip);
                entity.HasIndex(e => e.ContactNumber).IsUnique();
                entity.HasIndex(e => e.SkypeId).IsUnique();
                entity.HasIndex(e => e.Linkedin).IsUnique();
                entity.HasIndex(e => e.Twitter).IsUnique();
                entity.HasIndex(e => e.Others).IsUnique();

                entity.HasIndex(e => e.Github).IsUnique();

                entity.HasIndex(e => e.Title);
                entity.HasIndex(e => e.ShortTitle);
                entity.HasIndex(e => e.Summary);

                entity.HasIndex(e => e.HappyClientsCount);
                entity.HasIndex(e => e.HappyClientsShortSummary);
                entity.HasIndex(e => e.ProjectsCount);
                entity.HasIndex(e => e.ProjectsShortSummary);
                entity.HasIndex(e => e.Yearsofexperience);
                entity.HasIndex(e => e.YearsofexperienceShortSummary);
                entity.HasIndex(e => e.Awards);
                entity.HasIndex(e => e.AwardsShortSummary);

                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<AboutMe>()
               .HasOne(x => x.myPortal)
               .WithOne(p => p.AboutMe)
               .HasForeignKey<AboutMe>(p => p.MyPortalID);

            modelBuilder.Entity<MyPortal>()
              .HasOne(x => x.AboutMe)
              .WithOne(p => p.myPortal);
             

            modelBuilder.Entity<PortfolioSummary>().ToTable("PortfolioSummary");
            modelBuilder.Entity<PortfolioSummary>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.PortfolioID).IsUnique();
                entity.HasIndex(e => e.Title).IsUnique();
                entity.HasIndex(e => e.ShortTitle).IsUnique();
                entity.HasIndex(e => e.Summary).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            //modelBuilder.Entity<PortfolioSummary>()
            //  .HasOne(x => x.Portfolio)
            //  .WithMany(d => d.PortfolioSummaries)
            //  .HasForeignKey(x => x.PortfolioID)
            //  .IsRequired();
            //modelBuilder.Entity<Entities.MyPortal>()
            //    .HasMany(x => x.PortfolioSummaries)
            //    .WithOne(p => p.Portfolio)
            //    .IsRequired();

            modelBuilder.Entity<PortfolioUser>().ToTable("PortfolioUser");
            modelBuilder.Entity<PortfolioUser>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.HasIndex(e => e.PortfolioID).IsUnique();
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.ContactNumber).IsUnique();
                entity.HasIndex(e => e.SkypeId).IsUnique();
                entity.HasIndex(e => e.Linkedin).IsUnique();
                entity.HasIndex(e => e.Twitter).IsUnique();
                entity.HasIndex(e => e.Others).IsUnique();
                entity.HasIndex(e => e.IsActive).IsUnique();
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            //modelBuilder.Entity<PortfolioUser>()
            //      .HasOne(x => x.Portfolio)
            //      .WithMany(x => x.PortfolioUsers)
            //      .HasForeignKey(x => x.PortfolioID);
            //modelBuilder.Entity<Entities.MyPortal>()
            //    .HasMany(x => x.PortfolioUsers)
            //    .WithOne(x => x.Portfolio)
            //    .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
