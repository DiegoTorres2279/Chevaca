using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Chevaca;

#nullable disable

namespace Domain.Context
{
    public partial class ChevacaDB_Context : DbContext
    {

        public ChevacaDB_Context(DbContextOptions<ChevacaDB_Context> options)
            : base(options)
        {
        }
        
        public ChevacaDB_Context()
        {
        }

        public virtual DbSet<MGAP_Tag> Db_Mgap_Tags { get; set; }
        public virtual DbSet<Animal_Cow> Db_Animal_Cows { get; set; }
        public virtual DbSet<Animal_Horse> Db_Animal_Horses { get; set; }
        public virtual DbSet<Animal_Sheep> Db_Animal_Sheeps { get; set; }
        public virtual DbSet<Animal> Db_Animals { get; set; }
        public virtual DbSet<Ch_Device> Db_Ch_Devices { get; set; }
        public virtual DbSet<Person> Db_Employees { get; set; }
        public virtual DbSet<History_Animal_Disease> Db_History_Animals_Diseases { get; set; }
        public virtual DbSet<History_animal_vaccine> Db_History_Animals_Vaccines { get; set; }
        public virtual DbSet<Land_Feeder> Db_Land_Feeders { get; set; }
        public virtual DbSet<Land_Roost> Db_Land_Roosts { get; set; }
        public virtual DbSet<Land_Trough> Db_Land_Troughs { get; set; }
        public virtual DbSet<Land> Db_Lands { get; set; }
        public virtual DbSet<Ranch> Db_Ranchs { get; set; }
        public virtual DbSet<list_animals_breeds> Db_List_Animals_Breeds { get; set; }
        public virtual DbSet<list_animals_categories> Db_List_Animals_Categories { get; set; }
        public virtual DbSet<list_animals_types> Db_List_Animals_Types { get; set; }
        public virtual DbSet<Logs> Db_Logs { get; set; }
        public virtual DbSet<Rol> Db_Roles { get; set; }
        public virtual DbSet<User> Db_Users { get; set; }
        

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     if (!optionsBuilder.IsConfigured)
        //     {
        //         bool isLocal = false;
        //         if (!string.IsNullOrWhiteSpace(_configurations.ConnectionString_isLocal))
        //         {
        //             if (!bool.TryParse(_configurations.ConnectionString_isLocal, out isLocal))
        //             {
        //                 isLocal = false;
        //             }
        //         }
        //
        //         if (isLocal)
        //         {
        //             if (!string.IsNullOrWhiteSpace(_configurations.ConnectionString_chboard))
        //             {
        //                 optionsBuilder.UseSqlServer(_configurations.ConnectionString_chboard);
        //             }
        //         }
        //         else
        //         {
        //             if (!string.IsNullOrWhiteSpace(_configurations.ConnectionString_chboard_remoto))
        //             {
        //                 optionsBuilder.UseSqlServer(_configurations.ConnectionString_chboard_remoto);
        //             }
        //         }
        //     }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MGAP_Tag>(entity =>
            {
                entity.ToTable("MGAP_Tag");
                entity.HasKey(e => e.MGAP_Tag_ID)
                    .HasName("PK_MGAP_tag_ID");

                entity.Property(e => e.MGAP_Key)
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Animal_Cow>(entity =>
            {
                entity.HasKey(e => e.Animal_Cow_ID)
                    .HasName("PK_Animal_Cow");
            });

            modelBuilder.Entity<Animal_Horse>(entity =>
            {
                entity.ToTable("Animal_Horse");
                entity.HasKey(e => e.Animal_Horse_ID)
                    .HasName("PK_Animal_Horse");
            });

            modelBuilder.Entity<Animal_Sheep>(entity =>
            {
                entity.ToTable("Animal_Sheep");
                entity.HasKey(e => e.Animal_Sheep_ID)
                    .HasName("PK_Animal_Sheep");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.ToTable("Animal");
                entity.HasKey(e => e.Animal_ID)
                    .HasName("PK_Animal");
                
                entity.Property(e => e.Ch_Device_ID)
                    .IsRequired();
                
                entity.Property(e => e.Land_ID)
                    .IsRequired();

                entity.Property(e => e.Gender_MF)
                    .IsRequired()
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<Ch_Device>(entity =>
            {
                entity.ToTable("Ch_Device");
                entity.HasKey(e => e.Ch_Device_ID)
                    .HasName("PK_Ch_Device");
                
                entity.Property(e => e.Ch_Dev_Eui)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Ch_Profile>(entiy =>
            {
                entiy.ToTable("Ch_Profile");

                entiy.Property(e => e.DeviceProfileId)
                    .ValueGeneratedNever();
                
                entiy.HasKey(e => e.DeviceProfileId)
                    .HasName("Pk_Ch_Profile");
                
                entiy.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entiy.Property(e => e.PayloadDecoderScript)
                    .HasMaxLength(8000);
                entiy.Property(e => e.PayloadEncoderScript)
                    .HasMaxLength(8000);

                entiy.Property(e => e.UplinkInterval)
                    .IsRequired();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");
                entity.HasKey(e => e.Person_ID)
                    .HasName("PK_Employee");

                entity.Property(e => e.Land_ID)
                    .IsRequired();
                entity.Property(e => e.User_ID)
                    .IsRequired();
                entity.Property(e => e.IsOwner)
                    .IsRequired();

                entity.HasOne(e => e.User)
                    .WithOne(e => e.Person)
                    .HasForeignKey<Person>(e => e.User_ID);
            });

            modelBuilder.Entity<History_Animal_Disease>(entity =>
            {
                entity.ToTable("History_Animal_Disease");
                entity.HasKey(e => e.History_animals_diseases_ID)
                    .HasName("PK_History_Animal_Disease");
            });

            modelBuilder.Entity<History_animal_vaccine>(entity =>
            {
                entity.ToTable("History_animal_vaccine");
                entity.HasKey(e => e.History_animals_vaccines_ID)
                    .HasName("PK_History_animal_vaccine");
            });

            modelBuilder.Entity<Land_Feeder>(entity =>
            {
                entity.ToTable("Land_Feeder");
                entity.HasKey(e => e.Land_farm_feeder_ID)
                    .HasName("PK_Land_Feeder");

                entity.Property(e => e.Land_ID)
                    .IsRequired();
            });

            modelBuilder.Entity<Land_Roost>(entity =>
            {
                entity.ToTable("Land_Roost");
                entity.HasKey(e => e.Land_farm_roost_ID)
                    .HasName("PK_Land_Roost");
                
                entity.Property(e => e.Land_ID)
                    .IsRequired();
            });

            modelBuilder.Entity<Land_Trough>(entity =>
            {
                entity.ToTable("Land_Trough");
                entity.HasKey(e => e.Land_farm_trough_ID)
                    .HasName("PK_Land_Through");
                
                entity.Property(e => e.Land_ID)
                    .IsRequired();
            });

            modelBuilder.Entity<Land>(entity =>
            {
                entity.ToTable("Land");
                entity.HasKey(e => e.Land_ID)
                    .HasName("PK_Land");
                entity.Property(e => e.Ranch_ID)
                    .IsRequired();
                entity.Property(e => e.Chirpstack_App_ID)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Land_Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ranch>(entity =>
            {
                entity.ToTable("Ranch");
                entity.HasKey(e => e.Ranch_ID)
                    .HasName("PK_Ranch");
                
                entity.Property(e => e.Company_SocialReason)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ch_Organization_ID)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Company_Rut)
                    .IsRequired()
                    .HasMaxLength(20);
                
                entity.Property(e => e.Company_Domain)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<list_animals_breeds>(entity =>
            {
                entity.ToTable("list_animals_breeds");
                entity.HasKey(e => e.List_animals_breeds_ID)
                    .HasName("PK_list_animals_breeds");

            });

            modelBuilder.Entity<list_animals_categories>(entity =>
            {
                entity.ToTable("list_animals_categories");
                entity.HasKey(e => e.List_animals_categories_ID)
                    .HasName("PK_list_animals_categories");

            });

            modelBuilder.Entity<list_animals_types>(entity =>
            {
                entity.ToTable("list_animals_types");
                entity.HasKey(e => e.List_animals_type_ID)
                    .HasName("PK_list_animals_types");

                entity.Property(e => e.List_animals_type_ID).ValueGeneratedNever();
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.Log_ID)
                    .HasName("PK_Logs");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Rol");
                entity.HasKey(e => e.Rol_ID)
                    .HasName("PK_Rol");
                entity.Property(e => e.Rol_Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.User_ID)
                    .HasName("PK_User");

                entity.Property(e => e.User_Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Rol_ID)
                    .IsRequired();
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.ToTable("Logs");
                entity.HasKey(e => e.Log_ID)
                    .HasName("PK_Log");
                entity.Property(e => e.IP_client)
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.User_ID)
                    .IsRequired();

                entity.Property(e => e.Info)
                    .HasMaxLength(150)
                    .IsRequired();
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
                        VARIABLE.SetColumnType("varchar(200)");
                    }
                }
            }
            
            // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            // {
            //     // Use the entity name instead of the Context.DbSet<T> name
            //     // refs https://docs.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
            //     modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            // }
        }
    }
}
