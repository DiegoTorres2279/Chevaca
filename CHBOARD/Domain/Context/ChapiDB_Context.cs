using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Chapi;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Context
{
    public partial class ChapiDB_Context : DbContext
    {
        //Configuraciones _configuraciones = new();
        public ChapiDB_Context()
        {
        }

        public ChapiDB_Context(DbContextOptions<ChapiDB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Paquetes_Lora> paquetes_lora { get; set; }
        public virtual DbSet<Payload> payloads { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         bool isLocal = false;
        //         if (!string.IsNullOrWhiteSpace(_configuraciones.ConnectionString_isLocal))
        //         {
        //             if (!bool.TryParse(_configuraciones.ConnectionString_isLocal, out isLocal))
        //             {
        //                 isLocal = false;
        //             }
        //         }
        //
        //         if (isLocal)
        //         {
        //             if (!string.IsNullOrWhiteSpace(_configuraciones.ConnectionString_chapi))
        //             {
        //                 optionsBuilder.UseSqlServer(_configuraciones.ConnectionString_chapi);
        //             }
        //         }
        //         else
        //         {
        //             if (!string.IsNullOrWhiteSpace(_configuraciones.ConnectionString_chapi_remoto))
        //             {
        //                 optionsBuilder.UseSqlServer(_configuraciones.ConnectionString_chapi_remoto);
        //             }
        //         }
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paquetes_Lora>(entity =>
            {
                entity.HasKey(e => e.Paquete_lora_ID)
                    .HasName("PK_paquetes_lora");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(100);

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(150);

                entity.Property(e => e.DevEUI)
                    .HasMaxLength(100);

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Payload>(entity =>
            {
                entity.HasKey(e => e.Payload_ID)
                    .HasName("PK_payloads");

                entity.Property(e => e.ApplicationID).IsUnicode(false);

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(100);

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(150);;

                entity.Property(e => e.DevEUI)                    
                    .HasMaxLength(100);

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(100);
            });
            
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e=>e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Use the entity name instead of the Context.DbSet<T> name
                // refs https://docs.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name

                IEnumerable<IMutableProperty> propeties = entityType.GetProperties();
                foreach (var VARIABLE in propeties)
                {
                    string typename = VARIABLE.ClrType.Name;
                    if (typename == "String" )
                    {
                        VARIABLE.SetColumnType("varchar");
                    }
                }
            }
        }
        
        


    }
}
