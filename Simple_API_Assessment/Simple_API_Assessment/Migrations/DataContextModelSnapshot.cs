﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Simple_API_Assessment.Data;

#nullable disable

namespace Simple_API_Assessment.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Simple_API_Assessment.Models.Applicant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Applicant");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Njabulo Nhlanhla Mbatha"
                        });
                });

            modelBuilder.Entity("Simple_API_Assessment.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicantId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Skill");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicantId = 1,
                            Name = ".Net Framework"
                        },
                        new
                        {
                            Id = 2,
                            ApplicantId = 1,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 3,
                            ApplicantId = 1,
                            Name = "SQL Server"
                        });
                });

            modelBuilder.Entity("Simple_API_Assessment.Models.Skill", b =>
                {
                    b.HasOne("Simple_API_Assessment.Models.Applicant", "Applicant")
                        .WithMany("Skills")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("Simple_API_Assessment.Models.Applicant", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
