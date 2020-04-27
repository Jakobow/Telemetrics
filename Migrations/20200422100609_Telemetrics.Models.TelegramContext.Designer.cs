﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telemetrics.Models;

namespace Telemetrics.Migrations
{
    [DbContext(typeof(TelegramContext))]
    [Migration("20200422100609_Telemetrics.Models.TelegramContext")]
    partial class TelemetricsModelsTelegramContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Telemetrics.Models.Telegram", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime");

                    b.Property<double>("p1")
                        .HasColumnName("p1")
                        .HasColumnType("float");

                    b.Property<double>("p2")
                        .HasColumnName("p2")
                        .HasColumnType("float");

                    b.Property<double>("p3")
                        .HasColumnName("p3")
                        .HasColumnType("float");

                    b.Property<double>("p4")
                        .HasColumnName("p4")
                        .HasColumnType("float");

                    b.Property<double>("p5")
                        .HasColumnName("p5")
                        .HasColumnType("float");

                    b.Property<string>("t1")
                        .IsRequired()
                        .HasColumnName("t1")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Telegrams");
                });
#pragma warning restore 612, 618
        }
    }
}
