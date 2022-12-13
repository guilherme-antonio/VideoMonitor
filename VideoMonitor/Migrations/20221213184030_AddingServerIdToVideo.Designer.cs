﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VideoMonitor.Context;

#nullable disable

namespace VideoMonitor.Migrations
{
    [DbContext(typeof(VideoMonitorContext))]
    [Migration("20221213184030_AddingServerIdToVideo")]
    partial class AddingServerIdToVideo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VideoMonitor.Models.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Port")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("VideoMonitor.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ServerId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("VideoMonitor.Models.Video", b =>
                {
                    b.HasOne("VideoMonitor.Models.Server", null)
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
