using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<BirdCageCategory> BirdCageCategories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Part> Parts { get; set; }

    public virtual DbSet<PartItem> PartItems { get; set; }

    public virtual DbSet<Procedure> Procedures { get; set; }

    public virtual DbSet<ProcedureStep> ProcedureSteps { get; set; }

    public virtual DbSet<ProductionPlan> ProductionPlans { get; set; }

    public virtual DbSet<ProductionPlanStep> ProductionPlanSteps { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Bird_Cage_Production; TrustServerCertificate=true; Uid=sa; Pwd=1234567890");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5863C5E415D");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BirdCageCategory>(entity =>
        {
            entity.HasKey(e => e.BirdCageCategoryId).HasName("PK__BirdCage__360B3567737DAC32");

            entity.ToTable("BirdCageCategory");

            entity.Property(e => e.BirdCageCategoryId).HasColumnName("BirdCageCategoryID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8905BEA05");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAFAC43121A");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DayCreated).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Order__AccountID__4F7CD00D");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__5070F446");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C3BBC1A77");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.BirdCageCategoryId).HasColumnName("BirdCageCategoryID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.BirdCageCategory).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.BirdCageCategoryId)
                .HasConstraintName("FK__OrderDeta__BirdC__5AEE82B9");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__5BE2A6F2");
        });

        modelBuilder.Entity<Part>(entity =>
        {
            entity.HasKey(e => e.PartId).HasName("PK__Part__7C3F0D308210E109");

            entity.ToTable("Part");

            entity.Property(e => e.PartId).HasColumnName("PartID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(20)
                .IsUnicode(false);
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
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PartItem>(entity =>
        {
            entity.HasKey(e => e.PartItemId).HasName("PK__PartItem__186811CA12B6246D");

            entity.ToTable("PartItem");

            entity.Property(e => e.PartItemId).HasColumnName("PartItemID");
            entity.Property(e => e.BirdCageCategoryId).HasColumnName("BirdCageCategoryID");
            entity.Property(e => e.PartId).HasColumnName("PartID");

            entity.HasOne(d => d.BirdCageCategory).WithMany(p => p.PartItems)
                .HasForeignKey(d => d.BirdCageCategoryId)
                .HasConstraintName("FK__PartItem__BirdCa__5812160E");

            entity.HasOne(d => d.Part).WithMany(p => p.PartItems)
                .HasForeignKey(d => d.PartId)
                .HasConstraintName("FK__PartItem__PartID__571DF1D5");
        });

        modelBuilder.Entity<Procedure>(entity =>
        {
            entity.HasKey(e => e.ProcedureId).HasName("PK__Procedur__54C2E50DB95C640A");

            entity.ToTable("Procedure");

            entity.Property(e => e.ProcedureId).HasColumnName("ProcedureID");
            entity.Property(e => e.BirdCageCategoryId).HasColumnName("BirdCageCategoryID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BirdCageCategory).WithMany(p => p.Procedures)
                .HasForeignKey(d => d.BirdCageCategoryId)
                .HasConstraintName("FK__Procedure__BirdC__5EBF139D");
        });

        modelBuilder.Entity<ProcedureStep>(entity =>
        {
            entity.HasKey(e => e.ProcedureStepId).HasName("PK__Procedur__6B0AD2A30E4C315D");

            entity.ToTable("ProcedureStep");

            entity.Property(e => e.ProcedureStepId).HasColumnName("ProcedureStepID");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartItemId).HasColumnName("PartItemID");
            entity.Property(e => e.ProcedureId).HasColumnName("ProcedureID");
            entity.Property(e => e.TimeNeeded).HasColumnType("date");

            entity.HasOne(d => d.PartItem).WithMany(p => p.ProcedureSteps)
                .HasForeignKey(d => d.PartItemId)
                .HasConstraintName("FK__Procedure__PartI__628FA481");

            entity.HasOne(d => d.Procedure).WithMany(p => p.ProcedureSteps)
                .HasForeignKey(d => d.ProcedureId)
                .HasConstraintName("FK__Procedure__Proce__619B8048");
        });

        modelBuilder.Entity<ProductionPlan>(entity =>
        {
            entity.HasKey(e => e.ProductionPlanId).HasName("PK__Producti__B58D523AC13BD2E5");

            entity.ToTable("ProductionPlan");

            entity.Property(e => e.ProductionPlanId).HasColumnName("ProductionPlanID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

            entity.HasOne(d => d.Account).WithMany(p => p.ProductionPlans)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Productio__Accou__66603565");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.ProductionPlans)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK__Productio__Order__656C112C");
        });

        modelBuilder.Entity<ProductionPlanStep>(entity =>
        {
            entity.HasKey(e => e.ProductionPlanStepId).HasName("PK__Producti__798314A3BC80997F");

            entity.ToTable("ProductionPlanStep");

            entity.Property(e => e.ProductionPlanStepId).HasColumnName("ProductionPlanStepID");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.ProcedureStepId).HasColumnName("ProcedureStepID");
            entity.Property(e => e.ProductionPlanId).HasColumnName("ProductionPlanID");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.ProcedureStep).WithMany(p => p.ProductionPlanSteps)
                .HasForeignKey(d => d.ProcedureStepId)
                .HasConstraintName("FK__Productio__Proce__6A30C649");

            entity.HasOne(d => d.ProductionPlan).WithMany(p => p.ProductionPlanSteps)
                .HasForeignKey(d => d.ProductionPlanId)
                .HasConstraintName("FK__Productio__Produ__693CA210");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE2043B412D7C2");

            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
