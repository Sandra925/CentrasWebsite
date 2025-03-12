﻿// <auto-generated />
using System;
using Centras.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Centras.Migrations
{
    [DbContext(typeof(CentrasContext))]
    [Migration("20250312175853_NullableValuesAddedToRoomReservation")]
    partial class NullableValuesAddedToRoomReservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("Centras.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(3);

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 5,
                            Capacity = 0,
                            Description = "Modern and spacious room with a cozy atmosphere.",
                            Name = "Room 5",
                            Price = 0
                        },
                        new
                        {
                            ID = 6,
                            Capacity = 0,
                            Description = "Elegant suite with a balcony and sea view.",
                            Name = "Room 6",
                            Price = 0
                        },
                        new
                        {
                            ID = 7,
                            Capacity = 0,
                            Description = "Luxury suite with a king-sized bed and mini-bar.",
                            Name = "Room 7",
                            Price = 0
                        },
                        new
                        {
                            ID = 8,
                            Capacity = 0,
                            Description = "Comfortable double room perfect for couples.",
                            Name = "Room 8",
                            Price = 0
                        },
                        new
                        {
                            ID = 9,
                            Capacity = 0,
                            Description = "Budget-friendly room with all essential amenities.",
                            Name = "Room 9",
                            Price = 0
                        });
                });

            modelBuilder.Entity("Centras.Models.RoomImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImagePath = "Images/Room 5/Room5_1.jfif",
                            RoomId = 5
                        },
                        new
                        {
                            Id = 2,
                            ImagePath = "Images/Room 5/Room5.jfif",
                            RoomId = 5
                        },
                        new
                        {
                            Id = 3,
                            ImagePath = "Images/Room 5/Room5_2.jfif",
                            RoomId = 5
                        },
                        new
                        {
                            Id = 4,
                            ImagePath = "Images/Room 5/Room5_3.jfif",
                            RoomId = 5
                        },
                        new
                        {
                            Id = 5,
                            ImagePath = "Images/Room 5/Room5_4.jfif",
                            RoomId = 5
                        },
                        new
                        {
                            Id = 6,
                            ImagePath = "Images/Room 5/Room5_5.jfif",
                            RoomId = 5
                        },
                        new
                        {
                            Id = 7,
                            ImagePath = "Images/Room 6/Room6_1.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 8,
                            ImagePath = "Images/Room 6/Room6_2.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 9,
                            ImagePath = "Images/Room 6/Room6_3.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 10,
                            ImagePath = "Images/Room 6/Room6_4.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 11,
                            ImagePath = "Images/Room 6/Room6_5.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 12,
                            ImagePath = "Images/Room 6/Room6_6.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 13,
                            ImagePath = "Images/Room 6/Room6_7.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 14,
                            ImagePath = "Images/Room 6/Room6_8.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 15,
                            ImagePath = "Images/Room 6/Room6_9.jfif",
                            RoomId = 6
                        },
                        new
                        {
                            Id = 16,
                            ImagePath = "Images/Room 7/Room7_1.jfif",
                            RoomId = 7
                        },
                        new
                        {
                            Id = 17,
                            ImagePath = "Images/Room 7/Room7.jfif",
                            RoomId = 7
                        },
                        new
                        {
                            Id = 18,
                            ImagePath = "Images/Room 7/Room7_2.jfif",
                            RoomId = 7
                        },
                        new
                        {
                            Id = 19,
                            ImagePath = "Images/Room 7/Room7_3.jfif",
                            RoomId = 7
                        },
                        new
                        {
                            Id = 20,
                            ImagePath = "Images/Room 7/Room7_5.jfif",
                            RoomId = 7
                        },
                        new
                        {
                            Id = 21,
                            ImagePath = "Images/Room 7/Room7_6.jfif",
                            RoomId = 7
                        },
                        new
                        {
                            Id = 22,
                            ImagePath = "Images/Room 8/Room8_1.jfif",
                            RoomId = 8
                        },
                        new
                        {
                            Id = 23,
                            ImagePath = "Images/Room 8/Room8.jpg",
                            RoomId = 8
                        },
                        new
                        {
                            Id = 24,
                            ImagePath = "Images/Room 8/Room8_2.jfif",
                            RoomId = 8
                        },
                        new
                        {
                            Id = 25,
                            ImagePath = "Images/Room 8/Room8_3.jfif",
                            RoomId = 8
                        },
                        new
                        {
                            Id = 26,
                            ImagePath = "Images/Room 8/Room8_4.jfif",
                            RoomId = 8
                        },
                        new
                        {
                            Id = 27,
                            ImagePath = "Images/Room 9/Room9_1.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 28,
                            ImagePath = "Images/Room 9/Room9_2.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 29,
                            ImagePath = "Images/Room 9/Room9_3.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 30,
                            ImagePath = "Images/Room 9/Room9_4.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 31,
                            ImagePath = "Images/Room 9/Room9_5.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 32,
                            ImagePath = "Images/Room 9/Room9_6.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 33,
                            ImagePath = "Images/Room 9/Room9_7.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 34,
                            ImagePath = "Images/Room 9/Room9_8.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 35,
                            ImagePath = "Images/Room 9/Room9_9.jfif",
                            RoomId = 9
                        },
                        new
                        {
                            Id = 36,
                            ImagePath = "Images/Room 9/Room9_10.jfif",
                            RoomId = 9
                        });
                });

            modelBuilder.Entity("Centras.Models.RoomReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("AdultsNum")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KidsNum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Zip")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomReservations");
                });

            modelBuilder.Entity("Centras.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Centras.Models.RoomImage", b =>
                {
                    b.HasOne("Centras.Models.Room", null)
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Centras.Models.RoomReservation", b =>
                {
                    b.HasOne("Centras.Models.Room", "Room")
                        .WithMany("RoomReservations")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Centras.Models.Room", b =>
                {
                    b.Navigation("RoomImages");

                    b.Navigation("RoomReservations");
                });
#pragma warning restore 612, 618
        }
    }
}
