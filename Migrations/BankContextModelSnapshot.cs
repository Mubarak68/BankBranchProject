﻿// <auto-generated />
using Bank_Branch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bank_Branch.Migrations
{
    [DbContext(typeof(BankContext))]
    partial class BankContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Bank_Branch.Models.BankBranch", b =>
                {
                    b.Property<int>("BankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BranchManager")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationURL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BankId");

                    b.ToTable("bankBranchTable");

                    b.HasData(
                        new
                        {
                            BankId = 1,
                            BranchManager = "Mohammed Ali",
                            EmployeeCount = 20,
                            LocationName = "Al-Jahra Branch",
                            LocationURL = "https://maps.app.goo.gl/mPDxWzf5bcwgNCek9"
                        },
                        new
                        {
                            BankId = 2,
                            BranchManager = "Saoud Faleh",
                            EmployeeCount = 18,
                            LocationName = "Kaifan Branch",
                            LocationURL = "https://maps.app.goo.gl/DnMgNCGQD1cpPJLFA"
                        },
                        new
                        {
                            BankId = 3,
                            BranchManager = "Mubarak Mohammed",
                            EmployeeCount = 24,
                            LocationName = "Al-Khaldiya Branch",
                            LocationURL = "https://maps.app.goo.gl/R559DtfAFDN3f92g8"
                        },
                        new
                        {
                            BankId = 4,
                            BranchManager = "Salem Ali",
                            EmployeeCount = 35,
                            LocationName = "Farwaniya Branch",
                            LocationURL = "https://maps.app.goo.gl/mmLBR5aSciF2k9q8A"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
