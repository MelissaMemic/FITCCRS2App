using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FITCCRS2App.Services.Database
{
    public partial class FITCCRS2v2Context : DbContext
    {
        public FITCCRS2v2Context()
        {
        }

        public FITCCRS2v2Context(DbContextOptions<FITCCRS2v2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendum> Agenda { get; set; } = null!;
        public virtual DbSet<Dogadjaj> Dogadjajs { get; set; } = null!;
        public virtual DbSet<City> Citys { get; set; } = null!;
        public virtual DbSet<Country> Countrys { get; set; } = null!;
        public virtual DbSet<Kategorija> Kategorijas { get; set; } = null!;
        public virtual DbSet<Komisija> Komisijas { get; set; } = null!;
        public virtual DbSet<Kriterij> Kriterijs { get; set; } = null!;
        public virtual DbSet<Napomena> Napomenas { get; set; } = null!;
        public virtual DbSet<Predavac> Predavacs { get; set; } = null!;
        public virtual DbSet<PredavacDogadjaj> PredavacDogadjajs { get; set; } = null!;
        public virtual DbSet<Projekat> Projekats { get; set; } = null!;
        public virtual DbSet<Rezultat> Rezultats { get; set; } = null!;
        public virtual DbSet<Skategorije> Skategorijes { get; set; } = null!;
        public virtual DbSet<Sponzor> Sponzors { get; set; } = null!;
        public virtual DbSet<Takmicenje> Takmicenjes { get; set; } = null!;
        public virtual DbSet<Tim> Tims { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Trusted_Connection=false;MultipleActiveResultSets=False;Encrypt=true;TrustServerCertificate=true;Initial Catalog=RS190039; User Id=SA; Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Agendum>(entity =>
            {
                entity.HasKey(e => e.AgendaId);

                entity.HasIndex(e => e.TakmicenjeId, "IX_Agenda_TakmicenjeID");

                entity.Property(e => e.AgendaId).HasColumnName("AgendaID");

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.HasOne(d => d.Takmicenje)
                    .WithMany(p => p.Agenda)
                    .HasForeignKey(d => d.TakmicenjeId)
                    .HasConstraintName("FK_Agenda_Takmicenje");
            });

            modelBuilder.Entity<Dogadjaj>(entity =>
            {
                entity.ToTable("Dogadjaj");

                entity.HasIndex(e => e.AgendaId, "IX_Dogadjaj_AgendaID");

                entity.Property(e => e.DogadjajId).HasColumnName("DogadjajID");

                entity.Property(e => e.AgendaId).HasColumnName("AgendaID");

                entity.Property(e => e.Kraj).HasColumnType("datetime");

                entity.Property(e => e.Napomena).HasMaxLength(255);

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Pocetak).HasColumnType("datetime");

                entity.HasOne(d => d.Agenda)
                    .WithMany(p => p.Dogadjajs)
                    .HasForeignKey(d => d.AgendaId)
                    .HasConstraintName("FK_Dogadjaj_Agenda");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.ToTable("Kategorija");

                entity.HasIndex(e => e.TakmicenjeId, "IX_Kategorija_TakmicenjeID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Opis).HasMaxLength(255);

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.HasOne(d => d.Takmicenje)
                    .WithMany(p => p.Kategorijas)
                    .HasForeignKey(d => d.TakmicenjeId)
                    .HasConstraintName("FK_Kategorija_Takmicenje");
            });

            modelBuilder.Entity<Komisija>(entity =>
            {
                entity.ToTable("Komisija");

                entity.Property(e => e.KomisijaId).HasColumnName("komisijaId");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.Ime)
                    .HasMaxLength(255)
                    .HasColumnName("ime");

                entity.Property(e => e.KategorijaId).HasColumnName("kategorijaId");

                entity.Property(e => e.Prezime)
                    .HasMaxLength(255)
                    .HasColumnName("prezime");

                //entity.Property(e => e.UlogaKomisijeId).HasColumnName("ulogaKomisijeId");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Komisijas)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK_Komisija_Kategorija");
            });

            modelBuilder.Entity<Kriterij>(entity =>
            {
                entity.ToTable("Kriterij");

                entity.HasIndex(e => e.KategorijaId, "IX_Kriterij_KategorijaID");

                entity.Property(e => e.KriterijId).HasColumnName("KriterijID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Vrijednost).HasMaxLength(50);

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Kriterijs)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK_Kriterij_Kategorija");
            });

            modelBuilder.Entity<Napomena>(entity =>
            {
                entity.ToTable("Napomena");

                entity.Property(e => e.Poruka).HasMaxLength(255);

                entity.Property(e => e.UserName).HasMaxLength(255);

                entity.Property(e => e.UsernameTakmicar).HasMaxLength(255);
            });

            modelBuilder.Entity<Predavac>(entity =>
            {
                entity.ToTable("Predavac");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Ime).HasMaxLength(255);

                entity.Property(e => e.Prezime).HasMaxLength(255);

                entity.Property(e => e.Ustanova).HasMaxLength(255);

                entity.Property(e => e.Zvanje).HasMaxLength(255);
            });

            modelBuilder.Entity<PredavacDogadjaj>(entity =>
            {
                entity.HasKey(e => new { e.DogadjajId, e.PredavacId });

                entity.ToTable("PredavacDogadjaj");
            });

            modelBuilder.Entity<Projekat>(entity =>
            {
                entity.ToTable("Projekat");

                entity.Property(e => e.ProjekatId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProjekatID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.Opis).HasMaxLength(50);

                entity.Property(e => e.TimId).HasColumnName("TimID");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Projekats)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projekat__Katego__6442E2C9");

                entity.HasOne(d => d.Tim)
                    .WithMany(p => p.Projekats)
                    .HasForeignKey(d => d.TimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Projekat__TimID__65370702");
            });

            modelBuilder.Entity<Rezultat>(entity =>
            {
                entity.ToTable("Rezultat");

                entity.Property(e => e.RezultatId)
                    .ValueGeneratedNever()
                    .HasColumnName("RezultatID");

                entity.Property(e => e.ProjekatId).HasColumnName("ProjekatID");

                entity.HasOne(d => d.Projekat)
                    .WithMany(p => p.Rezultats)
                    .HasForeignKey(d => d.ProjekatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rezultat__Projek__681373AD");
            });

            modelBuilder.Entity<Skategorije>(entity =>
            {
                entity.ToTable("SKategorije");

                entity.Property(e => e.SkategorijeId)
                    .ValueGeneratedNever()
                    .HasColumnName("SKategorijeID");

                entity.Property(e => e.Naziv).HasMaxLength(50);
            });

            modelBuilder.Entity<Sponzor>(entity =>
            {
                entity.ToTable("Sponzor");

                entity.Property(e => e.SponzorId)
                    .ValueGeneratedNever()
                    .HasColumnName("SponzorID");

                entity.Property(e => e.KategorijaId).HasColumnName("KategorijaID");

                entity.Property(e => e.Naziv).HasMaxLength(50);

                entity.Property(e => e.SkategorijeId).HasColumnName("SKategorijeID");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Sponzors)
                    .HasForeignKey(d => d.KategorijaId)
                    .HasConstraintName("FK__Sponzor__Kategor__756D6ECB");

                entity.HasOne(d => d.Skategorije)
                    .WithMany(p => p.Sponzors)
                    .HasForeignKey(d => d.SkategorijeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sponzor__SKatego__76619304");
            });

            modelBuilder.Entity<Takmicenje>(entity =>
            {
                entity.ToTable("Takmicenje");

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.Property(e => e.Kraj).HasColumnType("datetime");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Pocetak).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tim>(entity =>
            {
                entity.ToTable("Tim");

                entity.Property(e => e.TimId)
                    .ValueGeneratedNever()
                    .HasColumnName("TimID");

                entity.Property(e => e.TakmicenjeId).HasColumnName("TakmicenjeID");

                entity.HasOne(d => d.Takmicenje)
                    .WithMany(p => p.Tims)
                    .HasForeignKey(d => d.TakmicenjeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tim__TakmicenjeI__6166761E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
