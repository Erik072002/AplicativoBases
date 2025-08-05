using AplicativoBases.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoAeropuerto.Models
{
    public class MiDbContext : DbContext
    {
        public MiDbContext() : base("AzureBibliotecaConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Personas> Personas { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Biblioteca> Biblioteca { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Autor> Autor { get; set; }
        public DbSet<Libro> Libro { get; set; }
        public DbSet<Estantes> Estantes { get; set; }
        public DbSet<TipoDeLibro> TipoDeLibro { get; set; }
        public DbSet<Telefonos> Telefonos { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Historico_De_Cargos> Historico_De_Cargos { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<HistoricoDeAreas> HistoricoDeAreas { get; set; }
        public DbSet<AreaDeTrabajo> AreasDeTrabajo { get; set; }
        public DbSet<Historico_De_Jefes> Historico_De_Jefes { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<PlanillaDePago> PlanillaDePago { get; set; }
        public DbSet<EMPLEADO_PLANILLA> EMPLEADO_PLANILLA { get; set; }
        public DbSet<NivelDeSuscripcion> NivelDeSuscripcion { get; set; }
        public DbSet<EstadoDeLaSuscripcion> EstadoDeLaSuscripcion { get; set; }
        public DbSet<Beneficios> Beneficios { get; set; }
        public DbSet<Metodo_De_Pago> Metodo_De_Pago { get; set; }
        public DbSet<Sucripcion> Sucripcion { get; set; }
        public DbSet<Beneficios_has_Sucripcion> Beneficios_has_Sucripcion { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Resena> Resena { get; set; }
        public DbSet<Facturacion> Facturacion { get; set; }
        public DbSet<Empleado_has_Facturacion> Empleado_has_Facturacion { get; set; }

        public DbSet<Libro_has_Prestamos> Libro_has_Prestamos { get; set; }
        public DbSet<Libro_has_Facturacion> Libro_has_Facturacion { get; set; }
        public DbSet<VistaPersonaEmpleado> VistaPersonaEmpleado { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Clave compuesta para Historico_De_Cargos
            modelBuilder.Entity<Historico_De_Cargos>()
                .HasKey(h => new { h.idCargo, h.idEmpleado });

            modelBuilder.Entity<Historico_De_Cargos>()
                .HasRequired(h => h.Cargo)
                .WithMany()
                .HasForeignKey(h => h.idCargo);

            modelBuilder.Entity<Historico_De_Cargos>()
                .HasRequired(h => h.Empleado)
                .WithMany()
                .HasForeignKey(h => h.idEmpleado);

            // Clave compuesta para HistoricoDeAreas
            modelBuilder.Entity<HistoricoDeAreas>()
                .HasKey(h => new { h.idAreaDeTrabajo, h.idEmpleado });

            modelBuilder.Entity<HistoricoDeAreas>()
                .HasRequired(h => h.AreaDeTrabajo)
                .WithMany()
                .HasForeignKey(h => h.idAreaDeTrabajo);

            modelBuilder.Entity<HistoricoDeAreas>()
                .HasRequired(h => h.Empleado)
                .WithMany()
                .HasForeignKey(h => h.idEmpleado);

            // Relaciones dobles en Historico_De_Jefes
            modelBuilder.Entity<Historico_De_Jefes>()
                .HasKey(h => new { h.idEmpleadoJefe, h.idEmpleadoJefe1 });

            modelBuilder.Entity<Historico_De_Jefes>()
                .HasRequired(h => h.EmpleadoJefe)
                .WithMany()
                .HasForeignKey(h => h.idEmpleadoJefe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Historico_De_Jefes>()
                .HasRequired(h => h.EmpleadoJefe1)
                .WithMany()
                .HasForeignKey(h => h.idEmpleadoJefe1)
                .WillCascadeOnDelete(false);

            // Clave compuesta para EMPLEADO_PLANILLA
            modelBuilder.Entity<EMPLEADO_PLANILLA>()
                .HasKey(e => new { e.idEmpleado, e.idPlanillaDePago });

            modelBuilder.Entity<EMPLEADO_PLANILLA>()
                .HasRequired(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.idEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EMPLEADO_PLANILLA>()
                .HasRequired(e => e.PlanillaDePago)
                .WithMany()
                .HasForeignKey(e => e.idPlanillaDePago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beneficios_has_Sucripcion>()
                .HasKey(b => new { b.idBeneficios, b.idSucripcion });

            modelBuilder.Entity<Beneficios_has_Sucripcion>()
                .HasRequired(b => b.Beneficios)
                .WithMany()
                .HasForeignKey(b => b.idBeneficios)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beneficios_has_Sucripcion>()
                .HasRequired(b => b.Sucripcion)
                .WithMany()
                .HasForeignKey(b => b.idSucripcion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado_has_Facturacion>()
            .HasKey(e => new { e.idEmpleado, e.idFacturacion });

            modelBuilder.Entity<Libro_has_Prestamos>()
    .HasKey(lp => new { lp.idLibro, lp.idPrestamos });

            modelBuilder.Entity<Libro_has_Prestamos>()
                .HasRequired(lp => lp.Libro)
                .WithMany()
                .HasForeignKey(lp => lp.idLibro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Libro_has_Prestamos>()
                .HasRequired(lp => lp.Prestamos)
                .WithMany()
                .HasForeignKey(lp => lp.idPrestamos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Libro_has_Prestamos>()
                .HasRequired(lp => lp.EmpleadoEstadoLibro)
                .WithMany()
                .HasForeignKey(lp => lp.idEmpleadoEstadoLibro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Libro_has_Facturacion>()
                .HasKey(lf => new { lf.Libro_idLibro, lf.Facturacion_idFacturacion });

            modelBuilder.Entity<Libro_has_Facturacion>()
                .HasRequired(lf => lf.Libro)
                .WithMany()
                .HasForeignKey(lf => lf.Libro_idLibro)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Libro_has_Facturacion>()
                .HasRequired(lf => lf.Facturacion)
                .WithMany()
                .HasForeignKey(lf => lf.Facturacion_idFacturacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VistaPersonaEmpleado>()
                .ToTable("vw_vistaPersonaEmpleado") 
                .HasKey(v => v.idPersonas);



            base.OnModelCreating(modelBuilder);
        }



    }
}
