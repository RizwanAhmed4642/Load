using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SAS.DBFirst;

public partial class SasContext : DbContext
{
    public SasContext()
    {
    }

    public SasContext(DbContextOptions<SasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Chaplain> Chaplains { get; set; }

    public virtual DbSet<ChaplainTask> ChaplainTasks { get; set; }

    public virtual DbSet<ChaplainTaskType> ChaplainTaskTypes { get; set; }

    public virtual DbSet<Church> Churches { get; set; }

    public virtual DbSet<ChurchMinister> ChurchMinisters { get; set; }

    public virtual DbSet<CurrentStatus> CurrentStatuses { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<GeoAccuracy> GeoAccuracies { get; set; }

    public virtual DbSet<GeoStatus> GeoStatuses { get; set; }

    public virtual DbSet<HighSchool> HighSchools { get; set; }

    public virtual DbSet<HsSchoolGrade> HsSchoolGrades { get; set; }

    public virtual DbSet<HsSrecoordinator> HsSrecoordinators { get; set; }

    public virtual DbSet<Minister> Ministers { get; set; }

    public virtual DbSet<MinisterFraternal> MinisterFraternals { get; set; }

    public virtual DbSet<MinisterFraternalTask> MinisterFraternalTasks { get; set; }

    public virtual DbSet<MinisterFraternalTaskType> MinisterFraternalTaskTypes { get; set; }

    public virtual DbSet<Ministry> Ministries { get; set; }

    public virtual DbSet<MinistryType> MinistryTypes { get; set; }

    public virtual DbSet<Overide> Overides { get; set; }

    public virtual DbSet<PrimarySchool> PrimarySchools { get; set; }

    public virtual DbSet<PrivateHigh> PrivateHighs { get; set; }

    public virtual DbSet<PrivatePrimary> PrivatePrimaries { get; set; }

    public virtual DbSet<PsSchoolGrade> PsSchoolGrades { get; set; }

    public virtual DbSet<PsSrecoordinator> PsSrecoordinators { get; set; }

    public virtual DbSet<PublicHigh> PublicHighs { get; set; }

    public virtual DbSet<PublicPrimary> PublicPrimaries { get; set; }

    public virtual DbSet<SaschurchPartner> SaschurchPartners { get; set; }

    public virtual DbSet<SaschurchPartnerTask> SaschurchPartnerTasks { get; set; }

    public virtual DbSet<SaschurchPartnerTaskType> SaschurchPartnerTaskTypes { get; set; }

    public virtual DbSet<SchoolGrade> SchoolGrades { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<Sreboard> Sreboards { get; set; }

    public virtual DbSet<SreboardTask> SreboardTasks { get; set; }

    public virtual DbSet<SreboardTaskType> SreboardTaskTypes { get; set; }

    public virtual DbSet<Srecoordinator> Srecoordinators { get; set; }

    public virtual DbSet<SrecoordinatorTask> SrecoordinatorTasks { get; set; }

    public virtual DbSet<SrecoordinatorTaskType> SrecoordinatorTaskTypes { get; set; }

    public virtual DbSet<Srerep> Srereps { get; set; }

    public virtual DbSet<Srestatus> Srestatuses { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Suburb> Suburbs { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskType> TaskTypes { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<UserArea> UserAreas { get; set; }

    public virtual DbSet<UserAuditEvent> UserAuditEvents { get; set; }

    public virtual DbSet<UserwithUserArea> UserwithUserAreas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-SC3NMJS;Database=SAS;Persist Security Info=False;User Id=sa;Password=sa@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.ToTable("Area");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Colour).HasMaxLength(255);
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.SaschurchPartnerId).HasColumnName("SASChurchPartnerID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.Property(e => e.RoleId).IsRequired();

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.AvatarUrl).HasColumnName("AvatarURL");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Chaplain>(entity =>
        {
            entity.ToTable("Chaplain");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<ChaplainTask>(entity =>
        {
            entity.ToTable("ChaplainTask");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignToId).HasColumnName("AssignToID");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.ChaplainTaskTypeId).HasColumnName("ChaplainTaskTypeID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<ChaplainTaskType>(entity =>
        {
            entity.ToTable("ChaplainTaskType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Church>(entity =>
        {
            entity.ToTable("Church");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Donation).HasColumnType("money");
            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasColumnName("email2");
            entity.Property(e => e.ExternalContactUpdated)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated");
            entity.Property(e => e.ExternalContactUpdated2)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated2");
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.HighSchoolId).HasColumnName("HighSchoolID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("LockAreaID");
            entity.Property(e => e.MapLink).HasColumnType("ntext");
            entity.Property(e => e.MinisterFraternalId).HasColumnName("MinisterFraternalID");
            entity.Property(e => e.Nm).HasMaxLength(255);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.Pastor).HasMaxLength(255);
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(255);
            entity.Property(e => e.Phone2).HasMaxLength(255);
            entity.Property(e => e.PostalAddress).HasMaxLength(255);
            entity.Property(e => e.Postalcode).HasMaxLength(255);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SreboardId).HasColumnName("SREBoardID");
            entity.Property(e => e.SrecoordinatorId).HasColumnName("SRECoordinatorID");
            entity.Property(e => e.StreetAddress).HasMaxLength(255);
            entity.Property(e => e.SuburbId).HasColumnName("SuburbID");
            entity.Property(e => e.SupporterNumber).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.WebSite).HasColumnType("ntext");
            entity.Property(e => e.Ypnum).HasColumnName("YPNum");
        });

        modelBuilder.Entity<ChurchMinister>(entity =>
        {
            entity.ToTable("Church_Minister");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChurchId).HasColumnName("ChurchID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MinisterId).HasColumnName("MinisterID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<CurrentStatus>(entity =>
        {
            entity.ToTable("CurrentStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.HighSchoolIcon).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.Opportunity)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.PrimSchoolIcon).HasMaxLength(255);
            entity.Property(e => e.PrivateHighIcon).HasMaxLength(255);
            entity.Property(e => e.PrivatePrimaryIcon).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.FromEmail).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Subject).HasMaxLength(512);
            entity.Property(e => e.ToEmail).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<GeoAccuracy>(entity =>
        {
            entity.ToTable("GeoAccuracy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Description).HasMaxLength(10);
            entity.Property(e => e.GoogleMeaning).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<GeoStatus>(entity =>
        {
            entity.ToTable("GeoStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Meaning).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<HighSchool>(entity =>
        {
            entity.ToTable("HighSchool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .HasColumnName("email2");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("LockAreaID");
            entity.Property(e => e.Nm).HasMaxLength(80);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.OverideId).HasColumnName("OverideID");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.Principal).HasMaxLength(50);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SreboardId).HasColumnName("SREBoardID");
            entity.Property(e => e.SrestatusId).HasColumnName("SREStatusID");
            entity.Property(e => e.StreetAddress).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.WebSite).HasMaxLength(80);
        });

        modelBuilder.Entity<HsSchoolGrade>(entity =>
        {
            entity.ToTable("HS_SchoolGrade");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Hsid).HasColumnName("HSID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Sastt).HasColumnName("SASTT");
            entity.Property(e => e.SchoolGradeId).HasColumnName("SchoolGradeID");
            entity.Property(e => e.Srett).HasColumnName("SRETT");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<HsSrecoordinator>(entity =>
        {
            entity.ToTable("HS_SRECoordinator");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Hsid).HasColumnName("HSID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.SrecoordinatorId).HasColumnName("SRECoordinatorID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Minister>(entity =>
        {
            entity.ToTable("Minister");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Current)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.StreetAddress).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<MinisterFraternal>(entity =>
        {
            entity.ToTable("MinisterFraternal");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChurchId).HasColumnName("ChurchID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<MinisterFraternalTask>(entity =>
        {
            entity.ToTable("MinisterFraternalTask");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignToId).HasColumnName("AssignToID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.MinisterFraternalId).HasColumnName("MinisterFraternalID");
            entity.Property(e => e.MinisterFraternalTaskTypeId).HasColumnName("MinisterFraternalTaskTypeID");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<MinisterFraternalTaskType>(entity =>
        {
            entity.ToTable("MinisterFraternalTaskType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Ministry>(entity =>
        {
            entity.ToTable("Ministry");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ChurchId).HasColumnName("ChurchID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .HasColumnName("email");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.MinistryTypeId).HasColumnName("MinistryTypeID");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.StreetAddress).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<MinistryType>(entity =>
        {
            entity.ToTable("MinistryType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Overide>(entity =>
        {
            entity.ToTable("Overide");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<PrimarySchool>(entity =>
        {
            entity.ToTable("PrimarySchool");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(100)
                .HasColumnName("email2");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.HighSchoolId).HasColumnName("HighSchoolID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsCombinedWithSelectedHs)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("IsCombinedWithSelectedHS");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("LockAreaID");
            entity.Property(e => e.Nm).HasMaxLength(80);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.OverideId).HasColumnName("OverideID");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.Principal).HasMaxLength(50);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SchoolCode).HasMaxLength(50);
            entity.Property(e => e.SreboardId).HasColumnName("SREBoardID");
            entity.Property(e => e.SrestatusId).HasColumnName("SREStatusID");
            entity.Property(e => e.StreetAddress).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.WebSite).HasMaxLength(80);
        });

        modelBuilder.Entity<PrivateHigh>(entity =>
        {
            entity.ToTable("PrivateHigh");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Campus)
                .HasMaxLength(255)
                .HasColumnName("campus");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.Combtext)
                .HasMaxLength(255)
                .HasColumnName("combtext");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CurrentStatusId).HasColumnName("CurrentStatusID");
            entity.Property(e => e.Domain)
                .HasMaxLength(255)
                .HasColumnName("domain");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasColumnName("email2");
            entity.Property(e => e.ExternalContactUpdated)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated");
            entity.Property(e => e.ExternalContactUpdated2)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated2");
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .HasColumnName("fax");
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("LockAreaID");
            entity.Property(e => e.Nm).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OverideId).HasColumnName("OverideID");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1)
                .HasMaxLength(255)
                .HasColumnName("phone1");
            entity.Property(e => e.Phone2)
                .HasMaxLength(255)
                .HasColumnName("phone2");
            entity.Property(e => e.PostalAddress).HasMaxLength(255);
            entity.Property(e => e.Postcode)
                .HasMaxLength(255)
                .HasColumnName("postcode");
            entity.Property(e => e.Principal).HasMaxLength(255);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SchoolType).HasMaxLength(255);
            entity.Property(e => e.SreboardId).HasColumnName("SREBoardID");
            entity.Property(e => e.SrestatusId).HasColumnName("SREStatusID");
            entity.Property(e => e.Streetaddress)
                .HasMaxLength(255)
                .HasColumnName("streetaddress");
            entity.Property(e => e.Studentnumber).HasColumnName("studentnumber");
            entity.Property(e => e.Suburb)
                .HasMaxLength(255)
                .HasColumnName("suburb");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");
        });

        modelBuilder.Entity<PrivatePrimary>(entity =>
        {
            entity.ToTable("PrivatePrimary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Campus)
                .HasMaxLength(255)
                .HasColumnName("campus");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.Combtext)
                .HasMaxLength(255)
                .HasColumnName("combtext");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CurrentStatusId).HasColumnName("CurrentStatusID");
            entity.Property(e => e.Domain)
                .HasMaxLength(255)
                .HasColumnName("domain");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasColumnName("email2");
            entity.Property(e => e.ExternalContactUpdated)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated");
            entity.Property(e => e.ExternalContactUpdated2)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated2");
            entity.Property(e => e.Fax)
                .HasMaxLength(255)
                .HasColumnName("fax");
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.HighSchoolId).HasColumnName("HighSchoolID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsCombinedWithSelectedHs)
                .HasMaxLength(255)
                .HasColumnName("IsCombinedWithSelectedHS");
            entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId).HasColumnName("LockAreaID");
            entity.Property(e => e.Nm).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OverideId).HasColumnName("OverideID");
            entity.Property(e => e.PasameAsSa)
                .HasMaxLength(255)
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1)
                .HasMaxLength(255)
                .HasColumnName("phone1");
            entity.Property(e => e.Phone2)
                .HasMaxLength(255)
                .HasColumnName("phone2");
            entity.Property(e => e.PostalAddress).HasMaxLength(255);
            entity.Property(e => e.Postcode)
                .HasMaxLength(255)
                .HasColumnName("postcode");
            entity.Property(e => e.Principal).HasMaxLength(255);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SchoolCode).HasMaxLength(255);
            entity.Property(e => e.SchoolType).HasMaxLength(255);
            entity.Property(e => e.SrestatusId).HasColumnName("SREStatusID");
            entity.Property(e => e.Streetaddress)
                .HasMaxLength(255)
                .HasColumnName("streetaddress");
            entity.Property(e => e.Studentnumber)
                .HasMaxLength(255)
                .HasColumnName("studentnumber");
            entity.Property(e => e.Suburb)
                .HasMaxLength(255)
                .HasColumnName("suburb");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Website)
                .HasColumnType("ntext")
                .HasColumnName("website");
        });

        modelBuilder.Entity<PsSchoolGrade>(entity =>
        {
            entity.ToTable("PS_SchoolGrade");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Psid).HasColumnName("PSID");
            entity.Property(e => e.Sastt).HasColumnName("SASTT");
            entity.Property(e => e.SchoolGradeId).HasColumnName("SchoolGradeID");
            entity.Property(e => e.Srett).HasColumnName("SRETT");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<PsSrecoordinator>(entity =>
        {
            entity.ToTable("PS_SRECoordinator");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Psid).HasColumnName("PSID");
            entity.Property(e => e.SrecoordinatorId).HasColumnName("SRECoordinatorID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<PublicHigh>(entity =>
        {
            entity.ToTable("PublicHigh");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.Campus)
                .HasMaxLength(255)
                .HasColumnName("campus");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.Combtext)
                .HasMaxLength(255)
                .HasColumnName("combtext");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CurrentStatusId).HasColumnName("CurrentStatusID");
            entity.Property(e => e.Domain)
                .HasMaxLength(255)
                .HasColumnName("domain");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasColumnName("email2");
            entity.Property(e => e.ExternalContactUpdated)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated");
            entity.Property(e => e.ExternalContactUpdated2)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated2");
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("LockAreaID");
            entity.Property(e => e.Nm).HasMaxLength(255);
            entity.Property(e => e.Note).HasMaxLength(255);
            entity.Property(e => e.OverideId).HasColumnName("OverideID");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1)
                .HasMaxLength(255)
                .HasColumnName("phone1");
            entity.Property(e => e.Phone2)
                .HasMaxLength(255)
                .HasColumnName("phone2");
            entity.Property(e => e.PostalAddress).HasMaxLength(255);
            entity.Property(e => e.Postcode)
                .HasMaxLength(255)
                .HasColumnName("postcode");
            entity.Property(e => e.Principal).HasMaxLength(255);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SchoolType).HasMaxLength(255);
            entity.Property(e => e.SreboardId).HasColumnName("SREBoardID");
            entity.Property(e => e.SrestatusId).HasColumnName("SREStatusID");
            entity.Property(e => e.Streetaddress)
                .HasMaxLength(255)
                .HasColumnName("streetaddress");
            entity.Property(e => e.Studentnumber)
                .HasMaxLength(255)
                .HasColumnName("studentnumber");
            entity.Property(e => e.Suburb)
                .HasMaxLength(255)
                .HasColumnName("suburb");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");
        });

        modelBuilder.Entity<PublicPrimary>(entity =>
        {
            entity.ToTable("PublicPrimary");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Campus)
                .HasMaxLength(255)
                .HasColumnName("campus");
            entity.Property(e => e.ChaplainId).HasColumnName("ChaplainID");
            entity.Property(e => e.Combtext)
                .HasMaxLength(255)
                .HasColumnName("combtext");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CurrentStatusId).HasColumnName("CurrentStatusID");
            entity.Property(e => e.Domain)
                .HasMaxLength(255)
                .HasColumnName("domain");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Email2)
                .HasMaxLength(255)
                .HasColumnName("email2");
            entity.Property(e => e.ExternalContactUpdated)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated");
            entity.Property(e => e.ExternalContactUpdated2)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("externalContactUpdated2");
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.GeoAccuracyId).HasColumnName("GeoAccuracyID");
            entity.Property(e => e.GeoStatusId).HasColumnName("GeoStatusID");
            entity.Property(e => e.HighSchoolId).HasColumnName("HighSchoolID");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsCombinedWithSelectedHs).HasColumnName("IsCombinedWithSelectedHS");
            entity.Property(e => e.LastUpdated).HasColumnName("lastUpdated");
            entity.Property(e => e.LatLongSetByUser)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.LockAreaId).HasColumnName("LockAreaID");
            entity.Property(e => e.Nm).HasMaxLength(255);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.OverideId).HasColumnName("OverideID");
            entity.Property(e => e.PasameAsSa).HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1)
                .HasMaxLength(255)
                .HasColumnName("phone1");
            entity.Property(e => e.Phone2)
                .HasMaxLength(255)
                .HasColumnName("phone2");
            entity.Property(e => e.PostalAddress).HasMaxLength(255);
            entity.Property(e => e.Postcode)
                .HasMaxLength(255)
                .HasColumnName("postcode");
            entity.Property(e => e.Principal).HasMaxLength(255);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.SchoolCode).HasMaxLength(255);
            entity.Property(e => e.SchoolType).HasMaxLength(255);
            entity.Property(e => e.SrestatusId).HasColumnName("SREStatusID");
            entity.Property(e => e.Streetaddress)
                .HasMaxLength(255)
                .HasColumnName("streetaddress");
            entity.Property(e => e.Studentnumber)
                .HasMaxLength(255)
                .HasColumnName("studentnumber");
            entity.Property(e => e.Suburb)
                .HasMaxLength(255)
                .HasColumnName("suburb");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.WantsNewsletter)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Website)
                .HasMaxLength(255)
                .HasColumnName("website");
        });

        modelBuilder.Entity<SaschurchPartner>(entity =>
        {
            entity.ToTable("SASChurchPartner");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SaschurchPartnerTask>(entity =>
        {
            entity.ToTable("SASChurchPartnerTask");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignToId).HasColumnName("AssignToID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.SaschurchPartnerId).HasColumnName("SASChurchPartnerID");
            entity.Property(e => e.SaschurchPartnerTaskTypeId).HasColumnName("SASChurchPartnerTaskTypeID");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SaschurchPartnerTaskType>(entity =>
        {
            entity.ToTable("SASChurchPartnerTaskType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SchoolGrade>(entity =>
        {
            entity.ToTable("SchoolGrade");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Default)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(255);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.ToTable("Setting");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.Txt).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Sreboard>(entity =>
        {
            entity.ToTable("SREBoard");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.Nm).HasMaxLength(100);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SreboardTask>(entity =>
        {
            entity.ToTable("SREBoardTask");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignToId).HasColumnName("AssignToID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.SreboardId).HasColumnName("SREBoardID");
            entity.Property(e => e.SreboardTaskTypeId).HasColumnName("SREBoardTaskTypeID");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SreboardTaskType>(entity =>
        {
            entity.ToTable("SREBoardTaskType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Srecoordinator>(entity =>
        {
            entity.ToTable("SRECoordinator");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.SrecoordinatorRepId).HasColumnName("SRECoordinatorRepID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SrecoordinatorTask>(entity =>
        {
            entity.ToTable("SRECoordinatorTask");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignToId).HasColumnName("AssignToID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.SrecoordinatorId).HasColumnName("SRECoordinatorID");
            entity.Property(e => e.SrecoordinatorTaskTypeId).HasColumnName("SRECoordinatorTaskTypeID");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<SrecoordinatorTaskType>(entity =>
        {
            entity.ToTable("SRECoordinatorTaskType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Srerep>(entity =>
        {
            entity.ToTable("SRERep");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.Current)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Fax).HasMaxLength(20);
            entity.Property(e => e.FirstName).HasMaxLength(35);
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.LastName).HasMaxLength(35);
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.PasameAsSa)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))")
                .HasColumnName("PASameAsSA");
            entity.Property(e => e.PasuburbId).HasColumnName("PASuburbID");
            entity.Property(e => e.Phone1).HasMaxLength(20);
            entity.Property(e => e.Phone2).HasMaxLength(20);
            entity.Property(e => e.PostalAddress).HasMaxLength(50);
            entity.Property(e => e.SasuburbId).HasColumnName("SASuburbID");
            entity.Property(e => e.StreetAddress).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Srestatus>(entity =>
        {
            entity.ToTable("SREStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Suburb>(entity =>
        {
            entity.ToTable("Suburb");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.PostCode).HasMaxLength(255);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.ToTable("Task");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignToId).HasColumnName("AssignToID");
            entity.Property(e => e.Complete)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.ResponseRecieved)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.TaskTypeId).HasColumnName("TaskTypeID");
            entity.Property(e => e.TripId).HasColumnName("TripID");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.VenueId).HasColumnName("VenueID");
            entity.Property(e => e.VenueTypeId).HasColumnName("VenueTypeID");
        });

        modelBuilder.Entity<TaskType>(entity =>
        {
            entity.ToTable("TaskType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Nm).HasMaxLength(30);
            entity.Property(e => e.ResponseRequired)
                .IsRequired()
                .HasDefaultValueSql("(CONVERT([bit],(0)))");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.ToTable("Trip");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.SrerepId).HasColumnName("SRERepID");
            entity.Property(e => e.Subject).HasMaxLength(35);
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
        });

        modelBuilder.Entity<UserArea>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AreaId).HasColumnName("AreaID");
            entity.Property(e => e.CreatedAt).HasColumnName("Created_At");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.UpdatedAt).HasColumnName("Updated_At");
            entity.Property(e => e.UpdatedBy).HasColumnName("Updated_By");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<UserAuditEvent>(entity =>
        {
            entity.HasKey(e => e.UserAuditId);

            entity.Property(e => e.UserId).IsRequired();
        });

        modelBuilder.Entity<UserwithUserArea>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("UserwithUserArea");

            entity.Property(e => e.Nm).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(450)
                .HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
