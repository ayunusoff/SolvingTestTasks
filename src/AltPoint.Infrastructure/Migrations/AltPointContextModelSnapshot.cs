﻿// <auto-generated />
using System;
using AltPoint.Infrastructure.Persistance.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AltPoint.Infrastructure.Migrations
{
    [DbContext(typeof(AltPointContext))]
    partial class AltPointContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AltPoint.Domain.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Appartment")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Childs");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CurWorkExp")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LivingAddressId")
                        .HasColumnType("uuid");

                    b.Property<double>("MonExpenses")
                        .HasColumnType("double precision");

                    b.Property<double>("MonIncome")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("RegAddressId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SpouseId")
                        .HasColumnType("uuid");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeEducation")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dob")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.HasIndex("LivingAddressId");

                    b.HasIndex("RegAddressId");

                    b.HasIndex("SpouseId")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Communication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Communications");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateDismissal")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateEmp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("FactAddressId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("JurAddressId")
                        .HasColumnType("uuid");

                    b.Property<double>("MonIncome")
                        .HasColumnType("double precision");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Tin")
                        .HasColumnType("text");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FactAddressId");

                    b.HasIndex("JurAddressId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Passport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateIssued")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Giver")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Series")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("ChildClient", b =>
                {
                    b.Property<Guid>("ParentsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("СhildrensId")
                        .HasColumnType("uuid");

                    b.HasKey("ParentsId", "СhildrensId");

                    b.HasIndex("СhildrensId");

                    b.ToTable("ChildClient");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Client", b =>
                {
                    b.HasOne("AltPoint.Domain.Entities.Address", "LivingAddress")
                        .WithMany()
                        .HasForeignKey("LivingAddressId");

                    b.HasOne("AltPoint.Domain.Entities.Address", "RegAddress")
                        .WithMany()
                        .HasForeignKey("RegAddressId");

                    b.HasOne("AltPoint.Domain.Entities.Client", "Spouse")
                        .WithOne()
                        .HasForeignKey("AltPoint.Domain.Entities.Client", "SpouseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("LivingAddress");

                    b.Navigation("RegAddress");

                    b.Navigation("Spouse");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Communication", b =>
                {
                    b.HasOne("AltPoint.Domain.Entities.Client", "Client")
                        .WithMany("Communications")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Document", b =>
                {
                    b.HasOne("AltPoint.Domain.Entities.Client", "Client")
                        .WithMany("Documents")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Job", b =>
                {
                    b.HasOne("AltPoint.Domain.Entities.Client", "Client")
                        .WithMany("Jobs")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AltPoint.Domain.Entities.Address", "FactAddress")
                        .WithMany()
                        .HasForeignKey("FactAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AltPoint.Domain.Entities.Address", "JurAddress")
                        .WithMany()
                        .HasForeignKey("JurAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("FactAddress");

                    b.Navigation("JurAddress");
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Passport", b =>
                {
                    b.HasOne("AltPoint.Domain.Entities.Client", "Client")
                        .WithOne("Passport")
                        .HasForeignKey("AltPoint.Domain.Entities.Passport", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ChildClient", b =>
                {
                    b.HasOne("AltPoint.Domain.Entities.Client", null)
                        .WithMany()
                        .HasForeignKey("ParentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AltPoint.Domain.Entities.Child", null)
                        .WithMany()
                        .HasForeignKey("СhildrensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AltPoint.Domain.Entities.Client", b =>
                {
                    b.Navigation("Communications");

                    b.Navigation("Documents");

                    b.Navigation("Jobs");

                    b.Navigation("Passport")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
