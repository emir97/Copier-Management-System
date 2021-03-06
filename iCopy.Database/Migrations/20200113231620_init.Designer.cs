﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iCopy.Database.Context;

namespace iCopy.Database.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20200113231620_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("iCopy.Database.Administrator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ApplicationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("PersonID");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("iCopy.Database.ApplicationUserPrintRequestFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ApplicationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("PrintRequestFileId");

                    b.HasKey("ID");

                    b.HasIndex("PrintRequestFileId");

                    b.ToTable("ApplicationUserPrintRequestFile");
                });

            modelBuilder.Entity("iCopy.Database.ApplicationUserProfilePhoto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ApplicationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("ProfilePhotoId");

                    b.HasKey("ID");

                    b.HasIndex("ProfilePhotoId");

                    b.ToTable("ApplicationUserProfilePhotos");
                });

            modelBuilder.Entity("iCopy.Database.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("CountryID");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name");

                    b.Property<int>("PostalCode");

                    b.Property<string>("ShortName");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("iCopy.Database.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ApplicationUserId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("PersonId");

                    b.HasKey("ID");

                    b.HasIndex("PersonId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("iCopy.Database.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Address");

                    b.Property<int>("ApplicationUserId");

                    b.Property<int>("CityId");

                    b.Property<string>("ContactAgent");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Email");

                    b.Property<string>("Jib");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("iCopy.Database.Copier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ApplicationUserId");

                    b.Property<int>("CityId");

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("EndWorkingTime");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<TimeSpan>("StartWorkingTime");

                    b.Property<string>("Url");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Copiers");
                });

            modelBuilder.Entity("iCopy.Database.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumberCode");

                    b.Property<string>("PhoneNumberRegex");

                    b.Property<string>("ShortName");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("iCopy.Database.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ApplicationUserId");

                    b.Property<int>("CopierId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Password");

                    b.Property<int>("PersonId");

                    b.HasKey("ID");

                    b.HasIndex("CopierId");

                    b.HasIndex("PersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("iCopy.Database.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CityId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("iCopy.Database.PrintRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<int>("ClientId");

                    b.Property<string>("Collate")
                        .IsRequired();

                    b.Property<int>("CopierId");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("FilePath");

                    b.Property<string>("Letter")
                        .IsRequired();

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Options")
                        .IsRequired();

                    b.Property<string>("Orientation")
                        .IsRequired();

                    b.Property<string>("Pages")
                        .IsRequired();

                    b.Property<DateTime>("RequestDate");

                    b.Property<string>("Side")
                        .IsRequired();

                    b.Property<string>("Status")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ClientId");

                    b.HasIndex("CopierId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("iCopy.Database.PrintRequestFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Extension");

                    b.Property<string>("FileSystemPath");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<long>("SizeInBytes");

                    b.HasKey("ID");

                    b.ToTable("PrintRequestFiles");
                });

            modelBuilder.Entity("iCopy.Database.ProfilePhoto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Extension");

                    b.Property<string>("FileSystemPath");

                    b.Property<string>("Format");

                    b.Property<decimal>("Height");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<string>("ResolutionUnit");

                    b.Property<long>("SizeInBytes");

                    b.Property<decimal>("Width");

                    b.Property<decimal>("XResolution");

                    b.Property<decimal>("YResolution");

                    b.HasKey("ID");

                    b.ToTable("ProfilePhotos");
                });

            modelBuilder.Entity("iCopy.Database.Administrator", b =>
                {
                    b.HasOne("iCopy.Database.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.ApplicationUserPrintRequestFile", b =>
                {
                    b.HasOne("iCopy.Database.PrintRequestFile", "PrintRequestFile")
                        .WithMany()
                        .HasForeignKey("PrintRequestFileId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.ApplicationUserProfilePhoto", b =>
                {
                    b.HasOne("iCopy.Database.ProfilePhoto", "ProfilePhoto")
                        .WithMany()
                        .HasForeignKey("ProfilePhotoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.City", b =>
                {
                    b.HasOne("iCopy.Database.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.Client", b =>
                {
                    b.HasOne("iCopy.Database.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.Company", b =>
                {
                    b.HasOne("iCopy.Database.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.Copier", b =>
                {
                    b.HasOne("iCopy.Database.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iCopy.Database.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.Employee", b =>
                {
                    b.HasOne("iCopy.Database.Copier", "Copier")
                        .WithMany()
                        .HasForeignKey("CopierId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iCopy.Database.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.Person", b =>
                {
                    b.HasOne("iCopy.Database.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("iCopy.Database.PrintRequest", b =>
                {
                    b.HasOne("iCopy.Database.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iCopy.Database.Copier", "Copier")
                        .WithMany()
                        .HasForeignKey("CopierId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
