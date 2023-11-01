using System;
using System.Collections.Generic;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess;

public partial class BirdCageProductionContext : DbContext
{
    public BirdCageProductionContext()
    {
    }

    public BirdCageProductionContext(DbContextOptions<BirdCageProductionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountStatus> AccountStatuses { get; set; }

    public virtual DbSet<BirdCage> BirdCages { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<PartItem> PartItems { get; set; }

    public virtual DbSet<Procedure> Procedures { get; set; }

    public virtual DbSet<ProcedureStep> ProcedureSteps { get; set; }

    public virtual DbSet<Progress> Progresses { get; set; }

    public virtual DbSet<ProgressStatus> ProgressStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var connectionString = configuration.GetConnectionString("DbCoreConnectionString");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=123456;database=Bird_Cage_Production;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A68EE8C803");

            entity.ToTable("Account");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(256);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__AccountS__C8EE2063614579EF");

            entity.ToTable("AccountStatus");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BirdCage>(entity =>
        {
            entity.HasKey(e => e.BirdCageId).HasName("PK__BirdCage__E6877683696EFE61");

            entity.ToTable("BirdCage");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__8DA7674D37F36181");

            entity.ToTable("Color");

            entity.Property(e => e.ColorId).ValueGeneratedNever();
            entity.Property(e => e.ColorName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8C9A5B27B");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E38B02AB565").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D10534306557C8").IsUnique();

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Customer__C8EE20634E1BC75F");

            entity.ToTable("CustomerStatus");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFF8CA5F9B");

            entity.ToTable("Order");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DayCreated).HasColumnType("datetime");
            entity.Property(e => e.StatusId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Order__AccountId__48CFD27E");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__49C3F6B7");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36CC4A25D0E");

            entity.ToTable("OrderDetail");

            entity.HasOne(d => d.BirdCage).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BirdCageId)
                .HasConstraintName("FK__OrderDeta__BirdC__5441852A");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__5535A963");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__OrderSta__C8EE206306DA25AA");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Part__7C3F0D5009F50565");

            entity.ToTable("Part");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Shape)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Size)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartItem>(entity =>
        {
            entity.HasKey(e => e.PartItemId).HasName("PK__PartItem__186811EA90D17AFE");

            entity.ToTable("PartItem");

            entity.HasOne(d => d.BirdCage).WithMany(p => p.PartItems)
                .HasForeignKey(d => d.BirdCageId)
                .HasConstraintName("FK__PartItem__BirdCa__5165187F");

            entity.HasOne(d => d.Part).WithMany(p => p.PartItems)
                .HasForeignKey(d => d.PartId)
                .HasConstraintName("FK__PartItem__PartId__5070F446");
        });

        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(e => e.ProcedureId).HasName("PK__Procedur__54C2E52D12D5CF20");

            entity.ToTable("Procedure");

            entity.HasOne(d => d.BirdCage).WithMany(p => p.Procedures)
                .HasForeignKey(d => d.BirdCageId)
                .HasConstraintName("FK__Procedure__BirdC__5812160E");
        });

        modelBuilder.Entity<ProcedureStep>(entity =>
        {
            entity.HasKey(e => e.ProcedureStepId).HasName("PK__Procedur__6B0AD28380039F53");

            entity.ToTable("ProcedureStep");

            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Procedure).WithMany(p => p.ProcedureSteps)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("FK__Procedure__Proce__5AEE82B9");
        });

        modelBuilder.Entity<Progress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("PK__Progress__BAE29CA5BA094772");

            entity.ToTable("Progress");

            entity.Property(e => e.EndDay).HasColumnType("date");
            entity.Property(e => e.StartDay).HasColumnType("date");

            entity.HasOne(d => d.Account).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Progress__Accoun__5EBF139D");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Progresses)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK__Progress__OrderD__5DCAEF64");
        });

        modelBuilder.Entity<ProgressStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Progress__C8EE206395023636");

            entity.ToTable("ProgressStatus");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AE1AAAE30");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
