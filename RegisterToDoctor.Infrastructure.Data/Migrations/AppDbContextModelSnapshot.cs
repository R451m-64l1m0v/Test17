﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegisterToDoctor.Infrastructure.Data.Context;

#nullable disable

namespace RegisterToDoctor.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OfficeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlotId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecializationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.HasIndex("PlotId");

                    b.HasIndex("SpecializationId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.MedicalCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalCard");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Office", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE");

                    b.Property<string>("DmsNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OmsNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nchar(16)")
                        .IsFixedLength();

                    b.Property<Guid>("PlotId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlotId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Plot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Doctor", b =>
                {
                    b.HasOne("RegisterToDoctor.Domen.Core.Entities.Office", "Office")
                        .WithMany("Doctors")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegisterToDoctor.Domen.Core.Entities.Plot", "Plot")
                        .WithMany("Doctors")
                        .HasForeignKey("PlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegisterToDoctor.Domen.Core.Entities.Specialization", "Specialization")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Office");

                    b.Navigation("Plot");

                    b.Navigation("Specialization");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.MedicalCard", b =>
                {
                    b.HasOne("RegisterToDoctor.Domen.Core.Entities.Patient", "Patient")
                        .WithOne("MedicalCard")
                        .HasForeignKey("RegisterToDoctor.Domen.Core.Entities.MedicalCard", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Patient", b =>
                {
                    b.HasOne("RegisterToDoctor.Domen.Core.Entities.Plot", "Plot")
                        .WithMany("Patients")
                        .HasForeignKey("PlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plot");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Office", b =>
                {
                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Patient", b =>
                {
                    b.Navigation("MedicalCard")
                        .IsRequired();
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Plot", b =>
                {
                    b.Navigation("Doctors");

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("RegisterToDoctor.Domen.Core.Entities.Specialization", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
