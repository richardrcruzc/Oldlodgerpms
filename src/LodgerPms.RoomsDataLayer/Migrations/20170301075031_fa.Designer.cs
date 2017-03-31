﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LodgerPms.RoomsDataLayer;

namespace LodgerPms.RoomsDataLayer.Migrations
{
    [DbContext(typeof(RoomsContext))]
    [Migration("20170301075031_fa")]
    partial class fa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lodgerpms.Domain.Common.FullName", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("FullName");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CompanyName");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FullNameId");

                    b.Property<string>("Phone");

                    b.Property<string>("SalesPersonId");

                    b.HasKey("Id");

                    b.HasIndex("FullNameId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.Customer", b =>
                {
                    b.HasOne("lodgerpms.Domain.Common.FullName", "FullName")
                        .WithMany()
                        .HasForeignKey("FullNameId");
                });
        }
    }
}