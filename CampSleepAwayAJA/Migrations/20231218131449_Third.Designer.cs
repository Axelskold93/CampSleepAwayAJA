﻿// <auto-generated />
using System;
using CampSleepAwayAJA;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CampSleepAwayAJA.Migrations
{
    [DbContext(typeof(CSAContext))]
    [Migration("20231218131449_Third")]
    partial class Third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CampSleepAwayAJA.Cabin", b =>
                {
                    b.Property<int>("CabinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CabinID"));

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CounselorID")
                        .HasColumnType("int");

                    b.HasKey("CabinID");

                    b.HasIndex("CounselorID");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Camper", b =>
                {
                    b.Property<int>("CamperID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CamperID"));

                    b.Property<int?>("CabinID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CamperID");

                    b.HasIndex("CabinID");

                    b.ToTable("Campers");
                });

            modelBuilder.Entity("CampSleepAwayAJA.ContactInfo", b =>
                {
                    b.Property<int>("ContactInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactInfoID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CounselorID")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NextOfKinID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactInfoID");

                    b.HasIndex("CounselorID");

                    b.HasIndex("NextOfKinID");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Counselor", b =>
                {
                    b.Property<int>("CounselorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CounselorID"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CounselorID");

                    b.ToTable("Counselors");
                });

            modelBuilder.Entity("CampSleepAwayAJA.NextOfKin", b =>
                {
                    b.Property<int>("NextOfKinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NextOfKinID"));

                    b.Property<int>("CamperID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NextOfKinID");

                    b.HasIndex("CamperID");

                    b.ToTable("NextOfKins");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Cabin", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Counselor", "Counselor")
                        .WithMany()
                        .HasForeignKey("CounselorID");

                    b.Navigation("Counselor");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Camper", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Cabin", "Cabin")
                        .WithMany()
                        .HasForeignKey("CabinID");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("CampSleepAwayAJA.ContactInfo", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Counselor", "Counselor")
                        .WithMany()
                        .HasForeignKey("CounselorID");

                    b.HasOne("CampSleepAwayAJA.NextOfKin", "NextOfKin")
                        .WithMany()
                        .HasForeignKey("NextOfKinID");

                    b.Navigation("Counselor");

                    b.Navigation("NextOfKin");
                });

            modelBuilder.Entity("CampSleepAwayAJA.NextOfKin", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Camper", "Camper")
                        .WithMany("NextOfKin")
                        .HasForeignKey("CamperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camper");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Camper", b =>
                {
                    b.Navigation("NextOfKin");
                });
#pragma warning restore 612, 618
        }
    }
}