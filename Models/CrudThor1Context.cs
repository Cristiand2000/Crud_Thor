using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudThor1.Models
{
    public partial class CrudThor1Context : DbContext
    {
        public CrudThor1Context()
        {
        }

        public CrudThor1Context(DbContextOptions<CrudThor1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cita> Citas { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-KS03NT4\\SQLEXPRESS01;Initial Catalog=CrudThor1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cita>(entity =>
            {
                entity.HasKey(e => e.IdCitas)
                    .HasName("PK__Citas__B6881B510AF300F2");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Recomendacion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cita)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Citas__id_client__07C12930");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.Property(e => e.ClaseId)
                    .ValueGeneratedNever()
                    .HasColumnName("clase_id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__677F38F5984E049D");

                entity.HasIndex(e => e.Cedula, "UQ__Clientes__B4ADFE3864473EB9")
                    .IsUnique();

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Restricciones)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Empleado__B4ADFE39B8DD6AFC");

                entity.ToTable("Empleado");

                entity.Property(e => e.Cedula).ValueGeneratedNever();

                entity.Property(e => e.CodigoRoles).HasColumnName("Codigo_Roles");

                entity.Property(e => e.Empleado1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Empleado");

                entity.HasOne(d => d.CodigoRolesNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.CodigoRoles)
                    .HasConstraintName("FK__Empleado__Codigo__4F7CD00D");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Permisos__153CFB6D30BE06AA");

                entity.HasIndex(e => e.Permisos, "UQ__Permisos__0EF6B00223118BC8")
                    .IsUnique();

                entity.Property(e => e.IdPermiso)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_Permiso");

                entity.Property(e => e.Permisos)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.IdProgramacion)
                    .HasName("PK__Programa__3B2418FB8A5C8A05");

                entity.ToTable("Programacion");

                entity.Property(e => e.IdProgramacion).HasColumnName("id_programacion");

                entity.Property(e => e.ClaseId).HasColumnName("clase_id");

                entity.Property(e => e.DiaLaboral)
                    .HasColumnName("dia_laboral")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaProgramacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_programacion");

                entity.Property(e => e.Instructor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("instructor");

                entity.HasOne(d => d.Clase)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.ClaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Programac__clase__71D1E811");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.CodigoRoles)
                    .HasName("PK__Roles__553D54325F314808");

                entity.Property(e => e.CodigoRoles)
                    .ValueGeneratedNever()
                    .HasColumnName("Codigo_Roles");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Permisos)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PermisosNavigation)
                    .WithMany(p => p.Roles)
                    .HasPrincipalKey(p => p.Permisos)
                    .HasForeignKey(d => d.Permisos)
                    .HasConstraintName("FK__Roles__Permisos__4CA06362");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
