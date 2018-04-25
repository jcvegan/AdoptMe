﻿// <auto-generated />
using AdoptMe.Data.Container.Context;
using AdoptMe.Data.Domains.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AdoptMe.Data.Container.Migrations
{
    [DbContext(typeof(AdoptMeDataContext))]
    [Migration("20180421213650_ModifyingAdoptionRequestsMigration")]
    partial class ModifyingAdoptionRequestsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdoptMe.Data.Domains.Master.PetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("PetTypes","Master");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.Adoption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("From");

                    b.Property<string>("OwnerId");

                    b.Property<long>("PetId");

                    b.Property<DateTime?>("To");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetId");

                    b.ToTable("Adoptions");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.AdoptionRequest", b =>
                {
                    b.Property<long>("PetId");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<DateTime>("LastModifiedTime");

                    b.Property<string>("LastModifiedUserId");

                    b.Property<string>("Request");

                    b.Property<string>("RequestedById");

                    b.Property<int>("State");

                    b.HasKey("PetId", "Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastModifiedUserId");

                    b.HasIndex("RequestedById");

                    b.ToTable("AdoptionRequests","Pets");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.Pet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BirthDate");

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<int>("Gender");

                    b.Property<string>("History");

                    b.Property<bool>("IsAdoptionAvailable");

                    b.Property<DateTime>("LastModifiedTime");

                    b.Property<string>("LastModifiedUserId");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerId");

                    b.Property<int>("PetTypeId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastModifiedUserId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Pets","Pet");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.Photo", b =>
                {
                    b.Property<long>("PetId");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDefault");

                    b.Property<DateTime>("LastModifiedTime");

                    b.Property<string>("LastModifiedUserId");

                    b.Property<string>("MimeType");

                    b.Property<byte[]>("PhotoContent");

                    b.HasKey("PetId", "Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastModifiedUserId");

                    b.ToTable("Photos","Pets");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Security.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<DateTime>("LastModifiedTime");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Roles","Security");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Security.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnName("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedTime");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(150);

                    b.Property<DateTime>("LastModifiedTime");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LastName")
                        .HasMaxLength(150);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users","Security");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.Adoption", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("AdoptMe.Data.Domains.Pets.Pet", "Pet")
                        .WithMany("Adoptions")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.AdoptionRequest", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User", "CreatedUser")
                        .WithMany("CreatedRequests")
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("AdoptMe.Data.Domains.Security.User", "LastModifiedUser")
                        .WithMany("LastModifiedRequests")
                        .HasForeignKey("LastModifiedUserId");

                    b.HasOne("AdoptMe.Data.Domains.Pets.Pet", "Pet")
                        .WithMany("Requests")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdoptMe.Data.Domains.Security.User", "RequestedBy")
                        .WithMany("Requests")
                        .HasForeignKey("RequestedById");
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.Pet", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User", "CreatedUser")
                        .WithMany("CreatedPets")
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("AdoptMe.Data.Domains.Security.User", "LastModifiedUser")
                        .WithMany("LastModifiedPets")
                        .HasForeignKey("LastModifiedUserId");

                    b.HasOne("AdoptMe.Data.Domains.Security.User", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdoptMe.Data.Domains.Master.PetType", "PetType")
                        .WithMany("Pets")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdoptMe.Data.Domains.Pets.Photo", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("AdoptMe.Data.Domains.Security.User", "LastModifiedUser")
                        .WithMany()
                        .HasForeignKey("LastModifiedUserId");

                    b.HasOne("AdoptMe.Data.Domains.Pets.Pet", "Pet")
                        .WithMany("Photos")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdoptMe.Data.Domains.Security.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AdoptMe.Data.Domains.Security.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
