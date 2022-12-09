using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolNumber",
                table: "Students");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "ID", "CreatedDate", "FirstName", "Gender", "LastName", "ModifiedDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5625), "Melih", 0, "Bayram", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 2, new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5629), "Merve", 1, "Akdeniz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 3, new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5631), "Mert", 0, "Öden", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 },
                    { 4, new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5632), "Şule", 1, "Çakır", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedDate", "ModifiedDate", "Password", "Role", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5299), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$fIFhJ52Ii6XKagUKgyi/4etbQmlHg.hXNey09L7b2uOGtPtoxLzse", 1, 0, "administrator" },
                    { 2, new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5323), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "$2a$11$..o9BIXelvj.qZzN.5edfeIZCYhjbqKVsncxdf.n4QwQLDF0DZ3Ay", 2, 0, "Elif" }
                });

            migrationBuilder.InsertData(
                table: "StudentDetail",
                columns: new[] { "ID", "BirthDay", "CreatedDate", "ModifiedDate", "PhoneNumber", "SchoolNumber", "Status", "StudentID" },
                values: new object[,]
                {
                    { 1, new DateTime(1997, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "05418965236", "100", 0, 1 },
                    { 2, new DateTime(1997, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5696), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "05418965236", "101", 0, 2 },
                    { 3, new DateTime(1992, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5698), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "05418965236", "102", 0, 3 },
                    { 4, new DateTime(1990, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 13, 18, 0, 42, 763, DateTimeKind.Local).AddTicks(5701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "05418965236", "103", 0, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StudentDetail",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
