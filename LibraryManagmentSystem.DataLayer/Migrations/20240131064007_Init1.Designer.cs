﻿// <auto-generated />
using System;
using LibraryManagmentSystem.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryManagmentSystem.DataLayer.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240131064007_Init1")]
    partial class Init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.EnumState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.Module", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.RoleModule", b =>
                {
                    b.Property<long>("ModuleId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ModuleId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StateId");

                    b.ToTable("role_modules");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EnumStateId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<int?>("StateId1")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.HasIndex("StateId1");

                    b.ToTable("users");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.UserRole", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("StateId")
                        .HasColumnType("integer");

                    b.Property<int?>("StateId1")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("StateId");

                    b.HasIndex("StateId1");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.Module", b =>
                {
                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", "State")
                        .WithMany("Modules")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.Role", b =>
                {
                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", "State")
                        .WithMany("Roles")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.RoleModule", b =>
                {
                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.Module", "Module")
                        .WithMany("RoleModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.Role", "Role")
                        .WithMany("RoleModules")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", "State")
                        .WithMany("RoleModules")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Role");

                    b.Navigation("State");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.User", b =>
                {
                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", null)
                        .WithMany("Users")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", "State")
                        .WithMany()
                        .HasForeignKey("StateId1");

                    b.Navigation("State");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.UserRole", b =>
                {
                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.EnumState", "State")
                        .WithMany()
                        .HasForeignKey("StateId1");

                    b.HasOne("LibraryManagmentSystem.DataLayer.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("State");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.EnumState", b =>
                {
                    b.Navigation("Modules");

                    b.Navigation("RoleModules");

                    b.Navigation("Roles");

                    b.Navigation("UserRoles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.Module", b =>
                {
                    b.Navigation("RoleModules");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.Role", b =>
                {
                    b.Navigation("RoleModules");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("LibraryManagmentSystem.DataLayer.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
