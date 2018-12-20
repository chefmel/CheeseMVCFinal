﻿// <auto-generated />
using CheeseMVC2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CheeseMVC2.Migrations
{
    [DbContext(typeof(CheeseDbContext))]
    [Migration("20181219203127_Melissa2")]
    partial class Melissa2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CheeseMVC2.Models.Cheese", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Cheeses");
                });

            modelBuilder.Entity("CheeseMVC2.Models.CheeseCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CheeseMVC2.Models.CheeseMenu", b =>
                {
                    b.Property<int>("CheeseID");

                    b.Property<int>("MenuID");

                    b.Property<int?>("CheeseMenuCheeseID");

                    b.Property<int?>("CheeseMenuMenuID");

                    b.HasKey("CheeseID", "MenuID");

                    b.HasIndex("MenuID");

                    b.HasIndex("CheeseMenuCheeseID", "CheeseMenuMenuID");

                    b.ToTable("CheeseMenus");
                });

            modelBuilder.Entity("CheeseMVC2.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CheeseMVC2.Models.Cheese", b =>
                {
                    b.HasOne("CheeseMVC2.Models.CheeseCategory", "Category")
                        .WithMany("Cheeses")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CheeseMVC2.Models.CheeseMenu", b =>
                {
                    b.HasOne("CheeseMVC2.Models.Cheese", "Cheese")
                        .WithMany("CheeseMenus")
                        .HasForeignKey("CheeseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CheeseMVC2.Models.Menu", "Menu")
                        .WithMany("CheeseMenus")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CheeseMVC2.Models.CheeseMenu")
                        .WithMany("CheeseMenus")
                        .HasForeignKey("CheeseMenuCheeseID", "CheeseMenuMenuID");
                });
#pragma warning restore 612, 618
        }
    }
}
