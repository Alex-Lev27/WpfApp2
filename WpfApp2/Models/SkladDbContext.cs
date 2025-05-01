using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp2;

public partial class SkladDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<ClientOrder> ClientOrders { get; set; }

    public DbSet<ClientOrderList> ClientOrderLists { get; set; }

    public  DbSet<Contragent> Contragents { get; set; }

    public DbSet<Country> Countries { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Manufacturer> Manufacturers { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Status> Statuses { get; set; }

    public DbSet<SupplierOrder> SupplierOrders { get; set; }

    public DbSet<SupplierOrderList> SupplierOrderLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ALEKS-PC;Database=skladDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC072273A89E");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ClientOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client_o__3214EC073533D2B5");

            entity.ToTable("Client_order");

            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.ContragentId).HasColumnName("Contragent_Id");
            entity.Property(e => e.CreationDate).HasColumnName("Creation_Date");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.ExecutionDate).HasColumnName("Execution_Date");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");

            entity.HasOne(d => d.Contragent).WithMany(p => p.ClientOrders)
                .HasForeignKey(d => d.ContragentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_or__Contr__4AB81AF0");

            entity.HasOne(d => d.Employee).WithMany(p => p.ClientOrders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_or__Emplo__4BAC3F29");

            entity.HasOne(d => d.Status).WithMany(p => p.ClientOrders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_or__Statu__4CA06362");
        });

        modelBuilder.Entity<ClientOrderList>(entity =>
        {
            entity.HasKey(e => new { e.ClientOrderId, e.ProductId }).HasName("Client_order_List_PK");

            entity.ToTable("Client_order_List");

            entity.Property(e => e.ClientOrderId).HasColumnName("Client_order_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("smallmoney")
                .HasColumnName("Purchase_Price");

            entity.HasOne(d => d.ClientOrder).WithMany(p => p.ClientOrderLists)
                .HasForeignKey(d => d.ClientOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_or__Clien__68487DD7");

            entity.HasOne(d => d.Product).WithMany(p => p.ClientOrderLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_or__Produ__693CA210");
        });

        modelBuilder.Entity<Contragent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contrage__3214EC07BF8DDAEC");

            entity.ToTable("Contragent");

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.PhoneNum)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Phone_Num");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07F5B714FC");

            entity.ToTable("Country");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC071C122591");

            entity.ToTable("Employee");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(100);
            entity.Property(e => e.PostId).HasColumnName("Post_Id");
            entity.Property(e => e.Surname).HasMaxLength(100);

            entity.HasOne(d => d.Post).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__Post_I__4316F928");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC078C27E7A5");

            entity.ToTable("Manufacturer");

            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC0704AFA4C9");

            entity.ToTable("Post");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC07C0D944CB");

            entity.ToTable("Product");

            entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.ManufacturerId).HasColumnName("Manufacturer_Id");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__59FA5E80");

            entity.HasOne(d => d.Country).WithMany(p => p.Products)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Country__5BE2A6F2");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Manufac__5AEE82B9");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Status__3214EC07E7554D00");

            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SupplierOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07A4C6F564");

            entity.ToTable("Supplier_order");

            entity.Property(e => e.Comment).HasMaxLength(1000);
            entity.Property(e => e.ContragentId).HasColumnName("Contragent_Id");
            entity.Property(e => e.CreationDate).HasColumnName("Creation_Date");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");
            entity.Property(e => e.ExecutionDate).HasColumnName("Execution_Date");
            entity.Property(e => e.StatusId).HasColumnName("Status_Id");

            entity.HasOne(d => d.Contragent).WithMany(p => p.SupplierOrders)
                .HasForeignKey(d => d.ContragentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Supplier___Contr__45F365D3");

            entity.HasOne(d => d.Employee).WithMany(p => p.SupplierOrders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Supplier___Emplo__46E78A0C");

            entity.HasOne(d => d.Status).WithMany(p => p.SupplierOrders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Supplier___Statu__47DBAE45");
        });

        modelBuilder.Entity<SupplierOrderList>(entity =>
        {
            entity.HasKey(e => new { e.SupplierOrderId, e.ProductId }).HasName("Supplier_order_List_PK");

            entity.ToTable("Supplier_order_List");

            entity.Property(e => e.SupplierOrderId).HasColumnName("Supplier_order_Id");
            entity.Property(e => e.ProductId).HasColumnName("Product_Id");
            entity.Property(e => e.SalePrice)
                .HasColumnType("smallmoney")
                .HasColumnName("Sale_Price");

            entity.HasOne(d => d.Product).WithMany(p => p.SupplierOrderLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Supplier___Produ__656C112C");

            entity.HasOne(d => d.SupplierOrder).WithMany(p => p.SupplierOrderLists)
                .HasForeignKey(d => d.SupplierOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Supplier___Suppl__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
