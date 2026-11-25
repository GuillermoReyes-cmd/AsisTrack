// DbContext generado con Entity Framework Core (Database First) a partir de la base AsisTrackDB.
// Comando usado (Consola del Administrador de paquetes, proyecto predeterminado: CapaDatos):
//   Scaffold-DbContext "Server=localhost;Database=AsisTrackDB;Trusted_Connection=True;TrustServerCertificate=True"
//       Microsoft.EntityFrameworkCore.SqlServer -Context AsisTrackDBContext -NoPluralize -UseDatabaseNames -Force
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapaDatos
{
    public partial class AsisTrackDBContext : DbContext
    {
        // Si se usa otra computadora, cambiar "Server" por el nombre de la instancia de SQL Server
        // (por ejemplo: Server=.\SQLEXPRESS).
        public const string CadenaConexion =
            "Server=localhost;Database=AsisTrackDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

        public AsisTrackDBContext()
        {
        }

        public AsisTrackDBContext(DbContextOptions<AsisTrackDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Justificacion> Justificacion { get; set; }
        public virtual DbSet<Marcacion> Marcacion { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(CadenaConexion);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.RolID).HasName("PK_Rol");
                entity.ToTable("Rol");
                entity.HasIndex(e => e.NombreRol, "UQ_Rol_Nombre").IsUnique();
                entity.Property(e => e.NombreRol).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Descripcion).HasMaxLength(150).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioID).HasName("PK_Usuario");
                entity.ToTable("Usuario");
                entity.HasIndex(e => e.NombreUsuario, "UQ_Usuario_Nombre").IsUnique();
                entity.Property(e => e.NombreCompleto).IsRequired().HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.NombreUsuario).IsRequired().HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Correo).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(256).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Rol).WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.RolID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.TurnoID).HasName("PK_Turno");
                entity.ToTable("Turno");
                entity.Property(e => e.NombreTurno).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.HoraInicio).HasPrecision(0);
                entity.Property(e => e.HoraFin).HasPrecision(0);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.HasKey(e => e.ColaboradorID).HasName("PK_Colaborador");
                entity.ToTable("Colaborador");
                entity.HasIndex(e => e.DNI, "UQ_Colaborador_DNI").IsUnique();
                entity.Property(e => e.Nombres).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Apellidos).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.DNI).IsRequired().HasMaxLength(8).IsUnicode(false).IsFixedLength();
                entity.Property(e => e.Cargo).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Departamento).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Turno).WithMany(p => p.Colaborador)
                    .HasForeignKey(d => d.TurnoID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colaborador_Turno");

                entity.HasOne(d => d.Usuario).WithMany(p => p.Colaborador)
                    .HasForeignKey(d => d.UsuarioID)
                    .HasConstraintName("FK_Colaborador_Usuario");
            });

            modelBuilder.Entity<Marcacion>(entity =>
            {
                entity.HasKey(e => e.MarcacionID).HasName("PK_Marcacion");
                entity.ToTable("Marcacion");
                entity.Property(e => e.FechaHora).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.TipoMarcacion).IsRequired().HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(15).IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Colaborador).WithMany(p => p.Marcacion)
                    .HasForeignKey(d => d.ColaboradorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Marcacion_Colaborador");
            });

            modelBuilder.Entity<Justificacion>(entity =>
            {
                entity.HasKey(e => e.JustificacionID).HasName("PK_Justificacion");
                entity.ToTable("Justificacion");
                entity.Property(e => e.Motivo).IsRequired().HasMaxLength(250).IsUnicode(false);
                entity.Property(e => e.FechaInicio).HasColumnType("date");
                entity.Property(e => e.FechaFin).HasColumnType("date");
                entity.Property(e => e.EstadoAprobacion).IsRequired().HasMaxLength(15).IsUnicode(false)
                    .HasDefaultValue("Pendiente");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())").HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Colaborador).WithMany(p => p.Justificacion)
                    .HasForeignKey(d => d.ColaboradorID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Justificacion_Colaborador");

                entity.HasOne(d => d.Marcacion).WithMany(p => p.Justificacion)
                    .HasForeignKey(d => d.MarcacionID)
                    .HasConstraintName("FK_Justificacion_Marcacion");

                entity.HasOne(d => d.AprobadoPorNavigation).WithMany(p => p.Justificacion)
                    .HasForeignKey(d => d.AprobadoPor)
                    .HasConstraintName("FK_Justificacion_AprobadoPor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
