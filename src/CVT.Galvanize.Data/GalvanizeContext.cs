using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CVT.Galvanize.Data
{
    public partial class GalvanizeContext : DbContext
    {
        public virtual DbSet<ClientProvider> ClientProvider { get; set; }
        public virtual DbSet<CvtSites> CvtSites { get; set; }
        public virtual DbSet<Interactions> Interactions { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<MatchesClientProviders> MatchesClientProviders { get; set; }
        public virtual DbSet<MatchesVolunteerRoles> MatchesVolunteerRoles { get; set; }
        public virtual DbSet<VolunteerCvtSites> VolunteerCvtSites { get; set; }
        public virtual DbSet<VolunteerInterests> VolunteerInterests { get; set; }
        public virtual DbSet<VolunteerLanguages> VolunteerLanguages { get; set; }
        public virtual DbSet<VolunteerNotes> VolunteerNotes { get; set; }
        public virtual DbSet<VolunteerRoles> VolunteerRoles { get; set; }
        public virtual DbSet<Volunteers> Volunteers { get; set; }
        public virtual DbSet<VolunteringCategories> VolunteringCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.;Database=cvt;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientProvider>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CvtSites>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Interactions>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.NoteText).HasColumnType("text");
            });

            modelBuilder.Entity<Languages>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.VolunteerCoordinator)
                    .WithMany(p => p.MatchesVolunteerCoordinator)
                    .HasForeignKey(d => d.VolunteerCoordinatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Volunteers");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.Matches)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Interactions");

                entity.HasOne(d => d.VolunteerNavigation)
                    .WithMany(p => p.MatchesVolunteerNavigation)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Matches_Volunteers1");
            });

            modelBuilder.Entity<MatchesClientProviders>(entity =>
            {
                entity.HasOne(d => d.ClientProvider)
                    .WithMany(p => p.MatchesClientProviders)
                    .HasForeignKey(d => d.ClientProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchesClientProviders_ClientProvider");

                entity.HasOne(d => d.Matches)
                    .WithMany(p => p.MatchesClientProviders)
                    .HasForeignKey(d => d.MatchesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchesClientProviders_Matches");
            });

            modelBuilder.Entity<MatchesVolunteerRoles>(entity =>
            {
                entity.HasOne(d => d.Matches)
                    .WithMany(p => p.MatchesVolunteerRoles)
                    .HasForeignKey(d => d.MatchesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MatchesVolunteerRoles_Matches");

                entity.HasOne(d => d.VolunteerRole)
                    .WithMany(p => p.MatchesVolunteerRoles)
                    .HasForeignKey(d => d.VolunteerRoleId)
                    .HasConstraintName("FK_MatchesVolunteerRoles_VolunteerRoles");
            });

            modelBuilder.Entity<VolunteerCvtSites>(entity =>
            {
                entity.HasOne(d => d.CvtSite)
                    .WithMany(p => p.VolunteerCvtSites)
                    .HasForeignKey(d => d.CvtSiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerCvtSites_CvtSites");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerCvtSites)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerCvtSites_Volunteers");
            });

            modelBuilder.Entity<VolunteerInterests>(entity =>
            {
                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerInterests)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerInterests_Volunteers");

                entity.HasOne(d => d.VolunteeringCategory)
                    .WithMany(p => p.VolunteerInterests)
                    .HasForeignKey(d => d.VolunteeringCategoryId)
                    .HasConstraintName("FK_VolunteerInterests_VolunteringCategories");
            });

            modelBuilder.Entity<VolunteerLanguages>(entity =>
            {
                entity.HasOne(d => d.Language)
                    .WithMany(p => p.VolunteerLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerLanguages_Languages");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerLanguages)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerLanguages_Volunteers");
            });

            modelBuilder.Entity<VolunteerNotes>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.NoteText).HasColumnType("text");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.VolunteerNotes)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VolunteerNotes_Volunteers");
            });

            modelBuilder.Entity<VolunteerRoles>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Volunteers>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.AddressLine1).HasMaxLength(150);

                entity.Property(e => e.AddressLine2).HasMaxLength(150);

                entity.Property(e => e.BusinessPhone).HasMaxLength(150);

                entity.Property(e => e.CellPhone).HasMaxLength(150);

                entity.Property(e => e.City).HasMaxLength(150);

                entity.Property(e => e.CsOrientationdate).HasColumnType("datetime");

                entity.Property(e => e.DateInterviewed).HasColumnType("datetime");

                entity.Property(e => e.Email1).HasMaxLength(150);

                entity.Property(e => e.Email2).HasMaxLength(150);

                entity.Property(e => e.FirstName).HasMaxLength(150);

                entity.Property(e => e.HomePhone).HasMaxLength(150);

                entity.Property(e => e.ImportantNames).HasColumnType("text");

                entity.Property(e => e.LastName).HasMaxLength(150);

                entity.Property(e => e.PostOrientationFollowupDate).HasColumnType("datetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(50);
            });

            modelBuilder.Entity<VolunteringCategories>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });
        }
    }
}
