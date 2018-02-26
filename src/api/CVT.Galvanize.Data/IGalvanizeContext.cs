using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CVT.Galvanize.Data
{
    public interface IGalvanizeContext
    {
        DbSet<ClientProvider> ClientProvider { get; set; }
        DbSet<CvtSites> CvtSites { get; set; }
        DbSet<Interactions> Interactions { get; set; }
        DbSet<Languages> Languages { get; set; }
        DbSet<Matches> Matches { get; set; }
        DbSet<MatchesClientProviders> MatchesClientProviders { get; set; }
        DbSet<MatchesVolunteerRoles> MatchesVolunteerRoles { get; set; }
        DbSet<VolunteerCvtSites> VolunteerCvtSites { get; set; }
        DbSet<VolunteerInterests> VolunteerInterests { get; set; }
        DbSet<VolunteerLanguages> VolunteerLanguages { get; set; }
        DbSet<VolunteerNotes> VolunteerNotes { get; set; }
        DbSet<VolunteerRoles> VolunteerRoles { get; set; }
        DbSet<Volunteers> Volunteers { get; set; }
        DbSet<VolunteringCategories> VolunteringCategories { get; set; }
        DatabaseFacade Database { get; }
        ChangeTracker ChangeTracker { get; }
        IModel Model { get; }
        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);
        void Dispose();
    }
}