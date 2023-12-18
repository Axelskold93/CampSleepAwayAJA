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
    [Migration("20231215141436_fourth1")]
    partial class fourth1
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

                    b.HasKey("CabinID");

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

                    b.Property<int?>("NextOfKinID")
                        .HasColumnType("int");

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

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactInfoID");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Counselor", b =>
                {
                    b.Property<int>("CounselorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CounselorID"));

                    b.Property<int?>("CabinID")
                        .HasColumnType("int");

                    b.Property<int>("CounselorInfoID")
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

                    b.HasKey("CounselorID");

                    b.HasIndex("CabinID")
                        .IsUnique()
                        .HasFilter("[CabinID] IS NOT NULL");

                    b.HasIndex("CounselorInfoID");

                    b.ToTable("Counselors");
                });

            modelBuilder.Entity("CampSleepAwayAJA.CounselorInfo", b =>
                {
                    b.Property<int>("CounselorInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CounselorInfoID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CounselorInfoID");

                    b.ToTable("CounselorInfos");
                });

            modelBuilder.Entity("CampSleepAwayAJA.NextOfKin", b =>
                {
                    b.Property<int>("NextOfKinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NextOfKinID"));

                    b.Property<int>("CamperID")
                        .HasColumnType("int");

                    b.Property<int>("CounselorID")
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

                    b.HasIndex("CounselorID");

                    b.ToTable("NextOfKins");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Camper", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Cabin", "Cabin")
                        .WithMany()
                        .HasForeignKey("CabinID");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Counselor", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Cabin", "Cabin")
                        .WithOne("Counselor")
                        .HasForeignKey("CampSleepAwayAJA.Counselor", "CabinID");

                    b.HasOne("CampSleepAwayAJA.CounselorInfo", "CounselorInfo")
                        .WithMany()
                        .HasForeignKey("CounselorInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cabin");

                    b.Navigation("CounselorInfo");
                });

            modelBuilder.Entity("CampSleepAwayAJA.NextOfKin", b =>
                {
                    b.HasOne("CampSleepAwayAJA.Camper", "Camper")
                        .WithMany("NextOfKin")
                        .HasForeignKey("CamperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CampSleepAwayAJA.Counselor", "Counselor")
                        .WithMany()
                        .HasForeignKey("CounselorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Camper");

                    b.Navigation("Counselor");
                });

            modelBuilder.Entity("CampSleepAwayAJA.Cabin", b =>
                {
                    b.Navigation("Counselor")
                        .IsRequired();
                });

            modelBuilder.Entity("CampSleepAwayAJA.Camper", b =>
                {
                    b.Navigation("NextOfKin");
                });
#pragma warning restore 612, 618
        }
    }
}
