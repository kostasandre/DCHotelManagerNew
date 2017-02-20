using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DCHotelManagerCore.Lib.DbContext;
using DCHotelManagerCore.Lib.Enums;

namespace DCHotelManagerCore.Lib.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20170220144334_picture")]
    partial class picture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Email");

                    b.Property<string>("IdNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Surname");

                    b.Property<string>("TaxId");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Email");

                    b.Property<string>("Manager");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("TaxId");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("ByteArray");

                    b.Property<int?>("HotelId");

                    b.Property<string>("Name");

                    b.Property<int?>("RoomId");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<int>("HotelId");

                    b.Property<int>("RoomTypeId");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BedType");

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("Sauna");

                    b.Property<bool>("Tv");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.Property<int>("View");

                    b.Property<bool>("WiFi");

                    b.HasKey("Id");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Picture", b =>
                {
                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Hotel")
                        .WithMany("Pictures")
                        .HasForeignKey("HotelId");

                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Room")
                        .WithMany("Pictures")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Room", b =>
                {
                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
