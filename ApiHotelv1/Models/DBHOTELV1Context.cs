using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiHotelv1.Models
{
    public partial class DBHOTELV1Context : DbContext
    {
        public DBHOTELV1Context()
        {
        }

        public DBHOTELV1Context(DbContextOptions<DBHOTELV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alquiler> Alquiler { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Habitacion> Habitacion { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CVA4KO0;Database=DBHOTELV1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alquiler>(entity =>
            {
                entity.HasKey(e => e.IdAlquiler);

                entity.Property(e => e.IdAlquiler).HasColumnName("idAlquiler");

                entity.Property(e => e.FechaEntrada)
                    .HasColumnName("fechaEntrada")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSalida)
                    .HasColumnName("fechaSalida")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Alquiler)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Alquiler_Cliente");

                entity.HasOne(d => d.IdHabitacionNavigation)
                    .WithMany(p => p.Alquiler)
                    .HasForeignKey(d => d.IdHabitacion)
                    .HasConstraintName("FK_Alquiler_Habitacion");

                entity.HasOne(d => d.IdVendedorNavigation)
                    .WithMany(p => p.Alquiler)
                    .HasForeignKey(d => d.IdVendedor)
                    .HasConstraintName("FK_Alquiler_Vendedor");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente).HasColumnName("idCLiente");

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNac)
                    .HasColumnName("fechaNac")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("sexo")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habitacion>(entity =>
            {
                entity.HasKey(e => e.IdHabitacion);

                entity.Property(e => e.IdHabitacion).HasColumnName("idHabitacion");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.NumeroCamas).HasColumnName("numeroCamas");

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Habitacion)
                    .HasForeignKey(d => d.IdTipo)
                    .HasConstraintName("FK_Habitacion_Tipo");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendedor>(entity =>
            {
                entity.HasKey(e => e.IdVendedor);

                entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasColumnName("direccion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacion)
                    .HasColumnName("observacion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sueldo)
                    .HasColumnName("sueldo")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(9)
                    .IsUnicode(false);
            });
        }
    }
}
