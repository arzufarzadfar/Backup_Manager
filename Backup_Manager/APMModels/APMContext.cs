using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backup_Manager.APMModels
{
    public partial class APMContext : DbContext
    {
        public APMContext()
        {
        }

        public APMContext(DbContextOptions<APMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCostumer> TblCostumer { get; set; }
        public virtual DbSet<TblKey> TblKey { get; set; }
        public object CostumerModel { get; internal set; }
        public object ActionArguments { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=APM;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblCostumer>(entity =>
            {
                entity.HasKey(e => e.IdCostumer);

                entity.ToTable("Tbl_costumer");

                entity.Property(e => e.IdCostumer).HasColumnName("id_costumer");

                entity.Property(e => e.Adresss)
                    .IsRequired()
                    .HasColumnName("adresss")
                    .HasMaxLength(1000);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(200);

                entity.Property(e => e.DateStart)
                    .IsRequired()
                    .HasColumnName("date_start")
                    .HasMaxLength(50);

                entity.Property(e => e.DayStatus)
                    .HasColumnName("day_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasColumnName("family")
                    .HasMaxLength(500);

                entity.Property(e => e.HddNumber)
                    .IsRequired()
                    .HasColumnName("hdd_number")
                    .HasMaxLength(100);

                entity.Property(e => e.MacAdress)
                    .IsRequired()
                    .HasColumnName("mac_adress")
                    .HasMaxLength(100);

                entity.Property(e => e.MailAdress)
                    .IsRequired()
                    .HasColumnName("mail_adress")
                    .HasMaxLength(200);

                entity.Property(e => e.MonthStatus)
                    .HasColumnName("month_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(200);

                entity.Property(e => e.Telephon)
                    .IsRequired()
                    .HasColumnName("telephon")
                    .HasMaxLength(50);

                entity.Property(e => e.WeekStatus)
                    .HasColumnName("week_status")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblKey>(entity =>
            {
                entity.HasKey(e => e.IdKey);

                entity.ToTable("Tbl_key");

                entity.Property(e => e.IdKey).HasColumnName("id_key");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IdCostumer).HasColumnName("id_costumer");

                entity.Property(e => e.LiKey)
                    .HasColumnName("li_key")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdCostumerNavigation)
                    .WithMany(p => p.TblKey)
                    .HasForeignKey(d => d.IdCostumer)
                    .HasConstraintName("FK_Tbl_key_Tbl_costumer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
