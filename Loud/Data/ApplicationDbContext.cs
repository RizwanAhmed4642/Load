using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAS.Models;
using SAS.Models.SASModels;

namespace SAS.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserAudit> UserAuditEvents { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Chaplain> Chaplain { get; set; }
        public virtual DbSet<ChaplainTask> ChaplainTask { get; set; }
        public virtual DbSet<ChaplainTaskType> ChaplainTaskType { get; set; }
        public virtual DbSet<Church> Church { get; set; }
        public virtual DbSet<Church_Minister> Church_Minister { get; set; }
        public virtual DbSet<CurrentStatus> CurrentStatus { get; set; }
        public virtual DbSet<GeoAccuracy> GeoAccuracy { get; set; }
        public virtual DbSet<GeoStatus> GeoStatus { get; set; }
        public virtual DbSet<HS_SRECoordinator> HS_SRECoordinator { get; set; }
        public virtual DbSet<HS_SchoolGrade> HS_SchoolGrade { get; set; }
        public virtual DbSet<HighSchool> HighSchool { get; set; }
        public virtual DbSet<Minister> Minister { get; set; }
        public virtual DbSet<MinisterFraternal> MinisterFraternal { get; set; }
        public virtual DbSet<MinisterFraternalTask> MinisterFraternalTask { get; set; }
        public virtual DbSet<MinisterFraternalTaskType> MinisterFraternalTaskType { get; set; }
        public virtual DbSet<Ministry> Ministry { get; set; }
        public virtual DbSet<MinistryType> MinistryType { get; set; }
        public virtual DbSet<Overide> Overide { get; set; }
        public virtual DbSet<PS_SRECoordinator> PS_SRECoordinator { get; set; }
        public virtual DbSet<PS_SchoolGrade> PS_SchoolGrade { get; set; }
        public virtual DbSet<PrimarySchool> PrimarySchool { get; set; }
        public virtual DbSet<PrivateHigh> PrivateHigh { get; set; }
        public virtual DbSet<PrivatePrimary> PrivatePrimary { get; set; }
        public virtual DbSet<PublicHigh> PublicHigh { get; set; }
        public virtual DbSet<PublicPrimary> PublicPrimary { get; set; }
        public virtual DbSet<SASChurchPartner> SASChurchPartner { get; set; }
        public virtual DbSet<SASChurchPartnerTask> SASChurchPartnerTask { get; set; }
        public virtual DbSet<SASChurchPartnerTaskType> SASChurchPartnerTaskType { get; set; }
        public virtual DbSet<SREBoard> SREBoard { get; set; }
        public virtual DbSet<SREBoardTask> SREBoardTask { get; set; }
        public virtual DbSet<SREBoardTaskType> SREBoardTaskType { get; set; }
        public virtual DbSet<SRECoordinator> SRECoordinator { get; set; }
        public virtual DbSet<SRECoordinatorTask> SRECoordinatorTask { get; set; }
        public virtual DbSet<SRECoordinatorTaskType> SRECoordinatorTaskType { get; set; }
        public virtual DbSet<SRERep> SRERep { get; set; }
        public virtual DbSet<SREStatus> SREStatus { get; set; }
        public virtual DbSet<SchoolGrade> SchoolGrade { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Suburb> Suburb { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskType> TaskType { get; set; }
        public virtual DbSet<Trip> Trip { get; set; }
        public virtual DbSet<UserAreas> UserAreas { get; set; }
        public virtual DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AllHigh>(entity =>
            //{
            //    entity.HasNoKey();
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
