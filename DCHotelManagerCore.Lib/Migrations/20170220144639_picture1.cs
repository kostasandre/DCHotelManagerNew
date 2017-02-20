using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DCHotelManagerCore.Lib.Migrations
{
    public partial class picture1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Hotels_HotelId",
                table: "Picture");

            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Rooms_RoomId",
                table: "Picture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_RoomId",
                table: "Pictures",
                newName: "IX_Pictures_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_HotelId",
                table: "Pictures",
                newName: "IX_Pictures_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Hotels_HotelId",
                table: "Pictures",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Hotels_HotelId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Rooms_RoomId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_RoomId",
                table: "Picture",
                newName: "IX_Picture_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_HotelId",
                table: "Picture",
                newName: "IX_Picture_HotelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Hotels_HotelId",
                table: "Picture",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Rooms_RoomId",
                table: "Picture",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
