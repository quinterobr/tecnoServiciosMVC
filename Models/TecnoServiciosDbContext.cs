using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AplicacionProyectoMVC.Models;

public partial class TecnoServiciosDbContext : DbContext
{
    public TecnoServiciosDbContext()
    {
    }

    public TecnoServiciosDbContext(DbContextOptions<TecnoServiciosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Incidente> Incidentes { get; set; }

    public virtual DbSet<OrdenDeCambio> OrdenDeCambios { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 

    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseSqlServer("Server=tcp:serverdistribuida.database.windows.net,1433;Initial Catalog=tecnoServiciosDB;Persist Security Info=False;User ID=adminDB;Password=1001Bq**;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D5946642AB3B735C");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__CE6D8B9E7FF56E02");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Incidente>(entity =>
        {
            entity.HasKey(e => e.IdIncidente).HasName("PK__Incident__E92B13DF07A20D81");

            entity.ToTable("Incidente");

            entity.Property(e => e.IdIncidente).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Prioridad)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRegistroNavigation).WithMany(p => p.Incidentes)
                .HasForeignKey(d => d.IdRegistro)
                .HasConstraintName("FK__Incidente__IdReg__787EE5A0");
        });

        modelBuilder.Entity<OrdenDeCambio>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCambio).HasName("PK__OrdenDeC__AFDB84F622539A77");

            entity.ToTable("OrdenDeCambio");

            entity.Property(e => e.IdOrdenCambio).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRegistroNavigation).WithMany(p => p.OrdenDeCambios)
                .HasForeignKey(d => d.IdRegistro)
                .HasConstraintName("FK__OrdenDeCa__IdReg__7B5B524B");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro).HasName("PK__Registro__FFA45A9995406F48");

            entity.ToTable("Registro");

            entity.Property(e => e.IdRegistro).ValueGeneratedNever();
            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Registro__IdClie__71D1E811");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdEmpleado)
                .HasConstraintName("FK__Registro__IdEmpl__72C60C4A");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__Solicitu__36899CEF1B4C1D59");

            entity.ToTable("Solicitud");

            entity.Property(e => e.IdSolicitud).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRegistroNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.IdRegistro)
                .HasConstraintName("FK__Solicitud__IdReg__75A278F5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
