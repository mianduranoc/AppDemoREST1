using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDemoREST.Models;
using static AppDemoREST.Models.FicModInventarios;

namespace AppDemoREST.Data
{
    public class FicDBContext : DbContext
    {
        public FicDBContext(DbContextOptions<FicDBContext> options) : base(options)
        {

        }//constructor

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionsBuilder)
        {
            try
            {

            }
            catch (Exception e) { }
        }//config conection
        public DbSet<zt_cat_estatus> zt_cat_estatus { get; set; }
        public DbSet<zt_cat_cedis> zt_cat_cedis { get; set; }
        public DbSet<zt_cat_almacenes> zt_cat_almacenes { get; set; }
        public DbSet<zt_inventarios> zt_inventarios { get; set; }
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
        public DbSet<zt_almacenes_ubicaciones> zt_almacenes_ubicaciones { get; set; }
        public DbSet<zt_cat_grupos_sku> zt_cat_grupos_sku { get; set; }
        public DbSet<zt_cat_productos> zt_cat_productos { get; set; }
        public DbSet<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        public DbSet<zt_cat_ubicaciones> zt_cat_ubicaciones { get; set; }
        public DbSet<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //      *** LLAVES PRIMARIAS ***     //
            //INVENTARIOS
            modelBuilder.Entity<zt_cat_cedis>().HasKey(c => new { c.IdCEDI });
            modelBuilder.Entity<zt_cat_almacenes>().HasKey(c => new { c.IdAlmacen });
            modelBuilder.Entity<zt_inventarios_acumulados>().HasKey(a => new { a.IdInventario, a.IdSKU, a.IdUnidadMedida });
            modelBuilder.Entity<zt_almacenes_ubicaciones>().HasKey(c => new { c.IdAlmacen, c.IdUbicacion });
            modelBuilder.Entity<zt_cat_estatus>().HasKey(c => new { c.IdEstatus });
            modelBuilder.Entity<zt_cat_grupos_sku>().HasKey(c => new { c.IdGrupoSKU });
            modelBuilder.Entity<zt_cat_productos>().HasKey(c => new { c.IdSKU });
            modelBuilder.Entity<zt_cat_productos_medidas>().HasKey(c => new { c.IdSKU, c.IdUMedidaBase });
            modelBuilder.Entity<zt_cat_ubicaciones>().HasKey(c => new { c.IdUbicacion });
            modelBuilder.Entity<zt_cat_unidad_medidas>().HasKey(c => new { c.IdUnidadMedida });
            modelBuilder.Entity<zt_inventarios>().HasKey(c => new { c.IdInventario });
            modelBuilder.Entity<zt_inventarios_conteos>().HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida, c.IdAlmacen, c.IdUbicacion, c.NumConteo });

            //    ***  LLAVES FORANEAS  ***    //
            //INVENTARIOS
            modelBuilder.Entity<zt_cat_almacenes>().HasOne(b => b.zt_cat_cedis).WithMany().HasForeignKey(
                b => new { b.IdCEDI });
            modelBuilder.Entity<zt_almacenes_ubicaciones>().HasOne(
                b =>b.zt_cat_almacenes ).WithMany().HasForeignKey(
                b => new { b.IdAlmacen });
            modelBuilder.Entity<zt_almacenes_ubicaciones>().HasOne(
                b => b.zt_cat_ubicaciones ).WithMany().HasForeignKey(
                b => new { b.IdUbicacion });
            modelBuilder.Entity<zt_cat_productos_medidas>().HasOne(
                b => b.zt_cat_productos ).WithMany().HasForeignKey(
                d => new { d.IdSKU });
            modelBuilder.Entity<zt_cat_productos_medidas>().HasOne(
                b => b.zt_cat_unidad_medidas ).WithMany().HasForeignKey(
                d => new { d.IdUMedidaBase });
            modelBuilder.Entity<zt_cat_productos>().HasOne(
                b => b.zt_cat_grupos_sku ).WithMany().HasForeignKey(
                d => new { d.IdGrupoSKU });
            modelBuilder.Entity<zt_cat_productos>().HasOne(
                b =>  b.zt_cat_unidad_medidas ).WithMany().HasForeignKey(
                d => new { d.IdUMedidaBase });
            modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                b => b.zt_cat_almacenes ).WithMany().HasForeignKey(
                d => new { d.IdAlmacen });
            modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                b => b.zt_cat_productos).WithMany().HasForeignKey(
                d => new { d.IdSKU });
            modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                b => b.zt_cat_ubicaciones).WithMany().HasForeignKey(
                d => new { d.IdUbicacion });
            modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                b =>b.zt_cat_unidad_medidas).WithMany().HasForeignKey(
                d => new { d.IdUnidadMedida });
            modelBuilder.Entity<zt_inventarios_conteos>().HasOne(
                b => b.zt_inventarios).WithMany().HasForeignKey(
                d => new { d.IdInventario });
            modelBuilder.Entity<zt_inventarios_acumulados>().HasOne(
                b => b.zt_inventarios).WithMany().HasForeignKey(
                d => new { d.IdInventario });
            modelBuilder.Entity<zt_inventarios_acumulados>().HasOne(
               b =>b.zt_cat_productos).WithMany().HasForeignKey(
               d => new { d.IdSKU });
            modelBuilder.Entity<zt_inventarios_acumulados>().HasOne(
               b => b.zt_cat_unidad_medidas).WithMany().HasForeignKey(
               d => new { d.IdUnidadMedida });
            modelBuilder.Entity<zt_inventarios>().HasOne(
                b => b.zt_cat_almacenes).WithMany().HasForeignKey(
                d => new { d.IdAlmacen });
            modelBuilder.Entity<zt_inventarios>().HasOne(
                b => b.zt_cat_cedis).WithMany().HasForeignKey(
                d => new { d.IdCEDI });
            modelBuilder.Entity<zt_inventarios>().HasOne(
                b =>b.zt_cat_estatus).WithMany().HasForeignKey(
                d => new { d.IdEstatus });
        }
    }
}

