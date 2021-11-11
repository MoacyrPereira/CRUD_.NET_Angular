﻿// <auto-generated />
using CrudAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudAPI.Migrations
{
    [DbContext(typeof(ClienteDetailContext))]
    [Migration("20211110211350_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113");

            modelBuilder.Entity("CrudAPI.Models.ClienteDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("contato");

                    b.Property<string>("nome");

                    b.Property<string>("sobrenome");

                    b.HasKey("id");

                    b.ToTable("ClienteDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
