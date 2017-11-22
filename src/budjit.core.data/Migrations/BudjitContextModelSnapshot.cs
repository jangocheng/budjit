﻿// <auto-generated />
using budjit.core.data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace budjit.core.data.Migrations
{
    [DbContext(typeof(BudjitContext))]
    partial class BudjitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("budjit.core.models.Tag", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("budjit.core.models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Alteration");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("Merchant");

                    b.Property<int?>("TagID");

                    b.HasKey("ID");

                    b.HasIndex("TagID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("budjit.core.models.Transaction", b =>
                {
                    b.HasOne("budjit.core.models.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagID");
                });
#pragma warning restore 612, 618
        }
    }
}