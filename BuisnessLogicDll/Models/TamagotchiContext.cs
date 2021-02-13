using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BuisnessLogicDll.Models
{
    public partial class TamagotchiContext : DbContext
    {
        public TamagotchiContext()
        {
        }

        public TamagotchiContext(DbContextOptions<TamagotchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalStatus> AnimalStatuses { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<FunctionsType> FunctionsTypes { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<LifeStage> LifeStages { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = localhost\\SQLEXPRESS01; Database=Tamagotchi; Trusted_Connection=true; MultipleActiveResultSets = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalName).IsUnicode(false);

                entity.Property(e => e.AnimalStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.AnimalWeight).HasDefaultValueSql("(floor(rand()*((8)-(2))+(2)))");

                entity.Property(e => e.DateOfBirth).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Happiness).HasDefaultValueSql("((75))");

                entity.Property(e => e.Hunger).HasDefaultValueSql("((75))");

                entity.Property(e => e.Hygiene).HasDefaultValueSql("((75))");

                entity.Property(e => e.LifeStageId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.AnimalStatus)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.AnimalStatusId)
                    .HasConstraintName("FK_AnimalStatusIDInAnimals");

                entity.HasOne(d => d.LifeStage)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.LifeStageId)
                    .HasConstraintName("FK_LifeStageIdInAnimals");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_PlayerIdInAnimals");
            });

            modelBuilder.Entity<AnimalStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__AnimalSt__C8EE206325670019");

                entity.Property(e => e.AnimalStatus1).IsUnicode(false);
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.FunctionName).IsUnicode(false);

                entity.HasOne(d => d.FunctionType)
                    .WithMany(p => p.Functions)
                    .HasForeignKey(d => d.FunctionTypeId)
                    .HasConstraintName("FK_FunctionTypeId");
            });

            modelBuilder.Entity<FunctionsType>(entity =>
            {
                entity.HasKey(e => e.FunctionTypeId)
                    .HasName("PK__Function__34AD9E81580F8406");

                entity.Property(e => e.FunctionType).IsUnicode(false);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => new { e.AnimalId, e.FunctionTime });

                entity.Property(e => e.FunctionTime).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalId");

                entity.HasOne(d => d.AnimalStatus)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.AnimalStatusId)
                    .HasConstraintName("FK_AnimalStatusIdInHistory");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_FunctionId");

                entity.HasOne(d => d.LifeStage)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.LifeStageId)
                    .HasConstraintName("FK_LifeStageIdInHistory");
            });

            modelBuilder.Entity<LifeStage>(entity =>
            {
                entity.HasKey(e => e.StageId)
                    .HasName("PK__LifeStag__03EB7AD86D883AF1");

                entity.Property(e => e.Stage).IsUnicode(false);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.ActiveAnimal, "UI_ActiveAnimal")
                    .IsUnique()
                    .HasFilter("([ActiveAnimal] IS NOT NULL)");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PWord).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.ActiveAnimalNavigation)
                    .WithOne(p => p.PlayerNavigation)
                    .HasForeignKey<Player>(d => d.ActiveAnimal)
                    .HasConstraintName("FK_ActiveAnimal");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
