﻿// <auto-generated />
using System;
using BasseinProekta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasseinProekta.Migrations
{
    [DbContext(typeof(BasseinContext))]
    partial class BasseinContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasseinProekt.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KartaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeGroupID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KartaId");

                    b.HasIndex("TypeGroupID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("BasseinProekt.Models.Karta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNachala")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Kartas");
                });

            modelBuilder.Entity("BasseinProekt.Models.Klient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FamiliR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NomerPasporta")
                        .HasColumnType("int");

                    b.Property<string>("Otchestvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeriaPasport")
                        .HasColumnType("int");

                    b.Property<int>("SpravkaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpravkaID");

                    b.ToTable("Klients");
                });

            modelBuilder.Entity("BasseinProekt.Models.Kontakt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KlientID")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KlientID");

                    b.ToTable("Kontakts");
                });

            modelBuilder.Entity("BasseinProekt.Models.Raspisanie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNachala")
                        .HasColumnType("datetime2");

                    b.Property<int>("KartaKlientaID")
                        .HasColumnType("int");

                    b.Property<int>("TrenerID")
                        .HasColumnType("int");

                    b.Property<int>("VannaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KartaKlientaID");

                    b.HasIndex("TrenerID");

                    b.HasIndex("VannaID");

                    b.ToTable("Raspisanies");
                });

            modelBuilder.Entity("BasseinProekt.Models.Spravka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNachala")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dopusk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupZdorovie")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Spravkas");
                });

            modelBuilder.Entity("BasseinProekt.Models.Trener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FamiliR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("ImR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Otchestvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeTrenerID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupID");

                    b.HasIndex("TypeTrenerID");

                    b.ToTable("Treners");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameGroup")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nomer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TypeGroups");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeTrener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Personal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeTreners");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeVanna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Forma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeVannas");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeZanRti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Programma")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypeZanRtis");
                });

            modelBuilder.Entity("BasseinProekt.Models.Vanna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dlina")
                        .HasColumnType("int");

                    b.Property<int>("Glubina")
                        .HasColumnType("int");

                    b.Property<string>("NomerVanna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shirina")
                        .HasColumnType("int");

                    b.Property<int>("TypeVannaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeVannaID");

                    b.ToTable("Vannas");
                });

            modelBuilder.Entity("BasseinProekt.Models.Ychet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<int>("KartaKlientaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KartaKlientaID");

                    b.ToTable("Ychets");
                });

            modelBuilder.Entity("BasseinProekt.Models.ZanRti", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int>("KartaKlientaID")
                        .HasColumnType("int");

                    b.Property<int>("TypeZanRtiID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KartaKlientaID");

                    b.HasIndex("TypeZanRtiID");

                    b.ToTable("ZanRtis");
                });

            modelBuilder.Entity("BasseinProekta.Models.KartaKlienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNachala")
                        .HasColumnType("datetime2");

                    b.Property<int>("KartaID")
                        .HasColumnType("int");

                    b.Property<int>("KlientID")
                        .HasColumnType("int");

                    b.Property<int>("NomerKartKlienta")
                        .HasColumnType("int");

                    b.Property<int?>("SpravkaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("KartaID");

                    b.HasIndex("KlientID");

                    b.HasIndex("SpravkaId");

                    b.ToTable("KartaKlientas");
                });

            modelBuilder.Entity("BasseinProekt.Models.Group", b =>
                {
                    b.HasOne("BasseinProekt.Models.Karta", null)
                        .WithMany("Groups")
                        .HasForeignKey("KartaId");

                    b.HasOne("BasseinProekt.Models.TypeGroup", "TypeGroup")
                        .WithMany("Groups")
                        .HasForeignKey("TypeGroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeGroup");
                });

            modelBuilder.Entity("BasseinProekt.Models.Klient", b =>
                {
                    b.HasOne("BasseinProekt.Models.Spravka", "Spravka")
                        .WithMany("Klients")
                        .HasForeignKey("SpravkaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spravka");
                });

            modelBuilder.Entity("BasseinProekt.Models.Kontakt", b =>
                {
                    b.HasOne("BasseinProekt.Models.Klient", "Klient")
                        .WithMany()
                        .HasForeignKey("KlientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");
                });

            modelBuilder.Entity("BasseinProekt.Models.Raspisanie", b =>
                {
                    b.HasOne("BasseinProekta.Models.KartaKlienta", "KartaKlienta")
                        .WithMany("Raspisanies")
                        .HasForeignKey("KartaKlientaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasseinProekt.Models.Trener", "Trener")
                        .WithMany("Raspisanies")
                        .HasForeignKey("TrenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasseinProekt.Models.Vanna", "Vanna")
                        .WithMany("Raspisanies")
                        .HasForeignKey("VannaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KartaKlienta");

                    b.Navigation("Trener");

                    b.Navigation("Vanna");
                });

            modelBuilder.Entity("BasseinProekt.Models.Trener", b =>
                {
                    b.HasOne("BasseinProekt.Models.Group", "Group")
                        .WithMany("Treners")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasseinProekt.Models.TypeTrener", "TypeTrener")
                        .WithMany("Treners")
                        .HasForeignKey("TypeTrenerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("TypeTrener");
                });

            modelBuilder.Entity("BasseinProekt.Models.Vanna", b =>
                {
                    b.HasOne("BasseinProekt.Models.TypeVanna", "TypeVanna")
                        .WithMany("Vanas")
                        .HasForeignKey("TypeVannaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeVanna");
                });

            modelBuilder.Entity("BasseinProekt.Models.Ychet", b =>
                {
                    b.HasOne("BasseinProekta.Models.KartaKlienta", "KartaKlienta")
                        .WithMany("Ychets")
                        .HasForeignKey("KartaKlientaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KartaKlienta");
                });

            modelBuilder.Entity("BasseinProekt.Models.ZanRti", b =>
                {
                    b.HasOne("BasseinProekta.Models.KartaKlienta", "KartaKlienta")
                        .WithMany("ZanRtis")
                        .HasForeignKey("KartaKlientaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasseinProekt.Models.TypeZanRti", "TypeZanRti")
                        .WithMany()
                        .HasForeignKey("TypeZanRtiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KartaKlienta");

                    b.Navigation("TypeZanRti");
                });

            modelBuilder.Entity("BasseinProekta.Models.KartaKlienta", b =>
                {
                    b.HasOne("BasseinProekt.Models.Karta", "Karta")
                        .WithMany()
                        .HasForeignKey("KartaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasseinProekt.Models.Klient", "Klient")
                        .WithMany("KartaKlientas")
                        .HasForeignKey("KlientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasseinProekt.Models.Spravka", null)
                        .WithMany("KartaKlientas")
                        .HasForeignKey("SpravkaId");

                    b.Navigation("Karta");

                    b.Navigation("Klient");
                });

            modelBuilder.Entity("BasseinProekt.Models.Group", b =>
                {
                    b.Navigation("Treners");
                });

            modelBuilder.Entity("BasseinProekt.Models.Karta", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("BasseinProekt.Models.Klient", b =>
                {
                    b.Navigation("KartaKlientas");
                });

            modelBuilder.Entity("BasseinProekt.Models.Spravka", b =>
                {
                    b.Navigation("KartaKlientas");

                    b.Navigation("Klients");
                });

            modelBuilder.Entity("BasseinProekt.Models.Trener", b =>
                {
                    b.Navigation("Raspisanies");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeGroup", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeTrener", b =>
                {
                    b.Navigation("Treners");
                });

            modelBuilder.Entity("BasseinProekt.Models.TypeVanna", b =>
                {
                    b.Navigation("Vanas");
                });

            modelBuilder.Entity("BasseinProekt.Models.Vanna", b =>
                {
                    b.Navigation("Raspisanies");
                });

            modelBuilder.Entity("BasseinProekta.Models.KartaKlienta", b =>
                {
                    b.Navigation("Raspisanies");

                    b.Navigation("Ychets");

                    b.Navigation("ZanRtis");
                });
#pragma warning restore 612, 618
        }
    }
}