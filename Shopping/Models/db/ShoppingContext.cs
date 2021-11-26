using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shopping.Models.db
{
    public partial class ShoppingContext : DbContext
    {
        public ShoppingContext()
        {
        }

        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdminstrator> TbAdminstrator { get; set; }
        public virtual DbSet<TbBill> TbBill { get; set; }
        public virtual DbSet<TbCart> TbCart { get; set; }
        public virtual DbSet<TbCategory> TbCategory { get; set; }
        public virtual DbSet<TbCustomer> TbCustomer { get; set; }
        public virtual DbSet<TbProduct> TbProduct { get; set; }
        public virtual DbSet<TbReview> TbReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Shopping;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAdminstrator>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdminName)
                    .HasColumnName("Admin_name")
                    .HasMaxLength(50);

                entity.Property(e => e.AdminPw)
                    .HasColumnName("Admin_Pw")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TbBill>(entity =>
            {
                entity.HasKey(e => e.BillId);

                entity.Property(e => e.BillId).HasColumnName("Bill_ID");

                entity.Property(e => e.BillDate)
                    .HasColumnName("Bill_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.BillQty).HasColumnName("Bill_Qty");

                entity.Property(e => e.BillTotal).HasColumnName("Bill_Total");

                entity.Property(e => e.CusId).HasColumnName("Cus_ID");

                entity.Property(e => e.PdId).HasColumnName("Pd_ID");

                entity.Property(e => e.PdName).HasColumnName("Pd_Name");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.TbBill)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK_TbBill_TbCustomer");

                entity.HasOne(d => d.Pd)
                    .WithMany(p => p.TbBill)
                    .HasForeignKey(d => d.PdId)
                    .HasConstraintName("FK_TbBill_TbProduct");
            });

            modelBuilder.Entity<TbCart>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.Property(e => e.CartId)
                    .HasColumnName("Cart_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CartImg).HasColumnName("Cart_Img");

                entity.Property(e => e.CartName).HasColumnName("Cart_Name");

                entity.Property(e => e.CartPrice).HasColumnName("Cart_Price");

                entity.Property(e => e.CartQty).HasColumnName("Cart_Qty");

                entity.Property(e => e.CartTotal).HasColumnName("Cart_Total");
            });

            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CateId);

                entity.Property(e => e.CateId)
                    .HasColumnName("Cate_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CateName).HasColumnName("Cate_Name");
            });

            modelBuilder.Entity<TbCustomer>(entity =>
            {
                entity.HasKey(e => e.CusId);

                entity.Property(e => e.CusId).HasColumnName("Cus_ID");

                entity.Property(e => e.CusAddress).HasColumnName("Cus_Address");

                entity.Property(e => e.CusEmail).HasColumnName("Cus_Email");

                entity.Property(e => e.CusName).HasColumnName("Cus_Name");

                entity.Property(e => e.CusPhone).HasColumnName("Cus_Phone");

                entity.Property(e => e.CusReceipt).HasColumnName("Cus_Receipt");
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.PdId)
                    .HasName("PK_Tb_Product");

                entity.Property(e => e.PdId)
                    .HasColumnName("Pd_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CateId).HasColumnName("Cate_ID");

                entity.Property(e => e.PdDelete).HasColumnName("Pd_Delete");

                entity.Property(e => e.PdDetail).HasColumnName("Pd_Detail");

                entity.Property(e => e.PdImg).HasColumnName("Pd_Img");

                entity.Property(e => e.PdName).HasColumnName("Pd_Name");

                entity.Property(e => e.PdPrice).HasColumnName("Pd_Price");

                entity.Property(e => e.PdStatus).HasColumnName("Pd_Status");

                entity.Property(e => e.PdStock).HasColumnName("Pd_Stock");

                entity.Property(e => e.PdSubHead).HasColumnName("Pd_SubHead");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.TbProduct)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_TbProduct_TbCategory");
            });

            modelBuilder.Entity<TbReview>(entity =>
            {
                entity.HasKey(e => e.RevId);

                entity.Property(e => e.RevId).HasColumnName("Rev_ID");

                entity.Property(e => e.PdName).HasColumnName("Pd_Name");

                entity.Property(e => e.RevDate)
                    .HasColumnName("Rev_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.RevMessage).HasColumnName("Rev_Message");

                entity.Property(e => e.RevTitle).HasColumnName("Rev_Title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
