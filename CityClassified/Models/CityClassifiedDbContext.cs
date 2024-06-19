using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CityClassified.Models;

public partial class CityClassifiedDbContext : DbContext
{
    public CityClassifiedDbContext()
    {
    }

    public CityClassifiedDbContext(DbContextOptions<CityClassifiedDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Clasificado> Clasificados { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=PC-CHAN\\SQLEXPRESS; database=CityClassifiedDB; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.IdCiudad);

            entity.ToTable("ciudades");

            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.Detalles)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("detalles");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Clasificado>(entity =>
        {
            entity.HasKey(e => e.IdClasificado);

            entity.ToTable("clasificados");

            entity.Property(e => e.IdClasificado).HasColumnName("idClasificado");
            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.CorreoC)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("correoC");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.NumeroC).HasColumnName("numeroC");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Clasificados)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clasificados_ciudades");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clasificados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clasificados_usuarios");
        });

        modelBuilder.Entity<Detalle>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("detalle");

            entity.Property(e => e.IdDetalle).HasColumnName("idDetalle");
            entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.DetallesNavigation)
                .HasForeignKey(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detalle_ciudades");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("usuarios");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
