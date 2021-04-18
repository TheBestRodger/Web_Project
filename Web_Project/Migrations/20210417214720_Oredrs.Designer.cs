﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Project.Storage;

namespace Web_Project.Migrations
{
    [DbContext(typeof(AppDBContent))]
    [Migration("20210417214720_Oredrs")]
    partial class Oredrs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Web_Project.Storage.Entity.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("catName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.Functions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaregoryId")
                        .HasColumnType("int");

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.Property<string>("img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isFavor")
                        .HasColumnType("bit");

                    b.Property<string>("longDecs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shortDecs")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.NewPage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Functionsid")
                        .HasColumnType("int");

                    b.Property<string>("WebPage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Functionsid");

                    b.ToTable("PageItem");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ordertime")
                        .HasColumnType("datetime2");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FunID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrdeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("functionsid")
                        .HasColumnType("int");

                    b.Property<int?>("orderid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("functionsid");

                    b.HasIndex("orderid");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.Functions", b =>
                {
                    b.HasOne("Web_Project.Storage.Entity.Category", "Category")
                        .WithMany("Functions")
                        .HasForeignKey("Categoryid");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.NewPage", b =>
                {
                    b.HasOne("Web_Project.Storage.Entity.Functions", "Functions")
                        .WithMany()
                        .HasForeignKey("Functionsid");

                    b.Navigation("Functions");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.OrderDetail", b =>
                {
                    b.HasOne("Web_Project.Storage.Entity.Functions", "functions")
                        .WithMany()
                        .HasForeignKey("functionsid");

                    b.HasOne("Web_Project.Storage.Entity.Order", "order")
                        .WithMany("orderDetail")
                        .HasForeignKey("orderid");

                    b.Navigation("functions");

                    b.Navigation("order");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.Category", b =>
                {
                    b.Navigation("Functions");
                });

            modelBuilder.Entity("Web_Project.Storage.Entity.Order", b =>
                {
                    b.Navigation("orderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}