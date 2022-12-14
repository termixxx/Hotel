// <auto-generated />
using System;
using Hotel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hotel.Entities.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20221126152956_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Hotel.Entities.Models.Booking_room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_chek_in")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_chek_out")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ID_Guest")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Room")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ID_Guest");

                    b.HasIndex("ID_Room");

                    b.ToTable("booking_rooms", (string)null);
                });

            modelBuilder.Entity("Hotel.Entities.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ID_Category")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Price_per_day")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ID_Category");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("Hotel.Entities.Models.Room_category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("room_categories", (string)null);
                });

            modelBuilder.Entity("Hotel.Entities.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passport_serries_and_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephon_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("admin")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Hotel.Entities.Models.Booking_room", b =>
                {
                    b.HasOne("Hotel.Entities.Models.User", "User")
                        .WithMany("Booking_rooms")
                        .HasForeignKey("ID_Guest")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Hotel.Entities.Models.Room", "Room")
                        .WithMany("Booking_rooms")
                        .HasForeignKey("ID_Room")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Hotel.Entities.Models.Room", b =>
                {
                    b.HasOne("Hotel.Entities.Models.Room_category", "Room_categoryes")
                        .WithMany("Rooms")
                        .HasForeignKey("ID_Category")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Room_categoryes");
                });

            modelBuilder.Entity("Hotel.Entities.Models.Room", b =>
                {
                    b.Navigation("Booking_rooms");
                });

            modelBuilder.Entity("Hotel.Entities.Models.Room_category", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Hotel.Entities.Models.User", b =>
                {
                    b.Navigation("Booking_rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
