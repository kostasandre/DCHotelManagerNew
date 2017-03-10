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
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookingId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("IsChecked");

                    b.Property<bool>("Paid");

                    b.Property<double>("PriceForRoom");

                    b.Property<double>("PriceForServices");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.BillingService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillingId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<bool>("IsChecked");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("ServiceId");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.HasIndex("ServiceId");

                    b.ToTable("BillingServices");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AgreedPrice");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<DateTime>("From");

                    b.Property<bool>("IsChecked");

                    b.Property<int>("RoomId");

                    b.Property<int>("Status");

                    b.Property<double>("SystemPrice");

                    b.Property<DateTime>("To");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

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

                    b.ToTable("Pictures");
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

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedBy");

                    b.Property<string>("Description");

                    b.Property<int>("HotelId");

                    b.Property<bool>("IsChecked");

                    b.Property<DateTime?>("Updated");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Billing", b =>
                {
                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Booking")
                        .WithMany("Billings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.BillingService", b =>
                {
                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Billing", "Billing")
                        .WithMany("BillingServices")
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Service")
                        .WithMany("BillingServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DCHotelManagerCore.Lib.Models.Persistent.Booking", b =>
                {
                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DCHotelManagerCore.Lib.Models.Persistent.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade);
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
