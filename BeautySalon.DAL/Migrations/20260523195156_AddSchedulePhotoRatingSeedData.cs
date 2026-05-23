using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeautySalon.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSchedulePhotoRatingSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Employees",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    WorkStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    WorkEnd = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSchedules_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "PhotoUrl" },
                values: new object[,]
                {
                    { 1, null, "Hair Care", "category_hair.png" },
                    { 2, null, "Nails", "category_nails.png" },
                    { 3, null, "Makeup", "category_makeup.png" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "IsActive", "LastName", "PhoneNumber", "PhotoUrl", "Position", "Rating" },
                values: new object[,]
                {
                    { 1, "Emma", true, "Watson", "+380001111111", "master_hair1.png", "Top Hair Stylist", 5.0 },
                    { 2, "Anna", true, "Smith", "+380002222222", "master_hair2.png", "Hair Stylist", 4.7999999999999998 },
                    { 3, "Sarah", true, "Johnson", "+380003333333", "master_hair3.png", "Expert Colorist", 4.9000000000000004 },
                    { 4, "Michael", true, "Brown", "+380004444444", "master_hair4.png", "Junior Hair Stylist", 4.4000000000000004 },
                    { 5, "Jessica", true, "Davis", "+380005555555", "master_nails1.png", "Top Nail Master", 5.0 },
                    { 6, "Emily", true, "Miller", "+380006666666", "master_nails2.png", "Senior Nail Technician", 4.7999999999999998 },
                    { 7, "Anna", true, "Wilson", "+380007777777", "master_nails3.png", "Nail Technician", 4.5999999999999996 },
                    { 8, "Sophia", true, "Taylor", "+380008888888", "master_nails4.png", "Junior Nail Technician", 4.2999999999999998 },
                    { 9, "Olivia", true, "Martinez", "+380009999999", "master_makeup1.png", "Celebrity Makeup Artist", 5.0 },
                    { 10, "Isabella", true, "Anderson", "+380010101010", "master_makeup2.png", "Bridal Makeup Specialist", 4.9000000000000004 },
                    { 11, "Mia", true, "Thomas", "+380011111111", "master_makeup3.png", "Senior Makeup Artist", 4.7000000000000002 },
                    { 12, "Chloe", true, "Jackson", "+380012121212", "master_makeup4.png", "Junior Makeup Artist", 4.5 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeSchedules",
                columns: new[] { "Id", "DayOfWeek", "EmployeeId", "WorkEnd", "WorkStart" },
                values: new object[,]
                {
                    { 1, 1, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 2, 2, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 3, 3, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, 4, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 5, 5, 1, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 6, 1, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 7, 2, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 8, 3, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 9, 4, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, 5, 2, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 11, 1, 3, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 12, 2, 3, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 13, 3, 3, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 14, 4, 3, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 15, 5, 3, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 16, 1, 4, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 17, 2, 4, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 18, 3, 4, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 19, 4, 4, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 20, 5, 4, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 21, 1, 5, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 22, 2, 5, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 23, 3, 5, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 24, 4, 5, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 25, 5, 5, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 26, 1, 6, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 27, 2, 6, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 28, 3, 6, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 29, 4, 6, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 30, 5, 6, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 31, 1, 7, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 32, 2, 7, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 33, 3, 7, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 34, 4, 7, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 35, 5, 7, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 36, 1, 8, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 37, 2, 8, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 38, 3, 8, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 39, 4, 8, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 40, 5, 8, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 41, 1, 9, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 42, 2, 9, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 43, 3, 9, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 44, 4, 9, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 45, 5, 9, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 46, 1, 10, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 47, 2, 10, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 48, 3, 10, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 49, 4, 10, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 50, 5, 10, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 51, 1, 11, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 52, 2, 11, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 53, 3, 11, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 54, 4, 11, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 55, 5, 11, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 56, 1, 12, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 57, 2, 12, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 58, 3, 12, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 59, 4, 12, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 60, 5, 12, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 9, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CategoryId", "Description", "DurationMinutes", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, 60, "Women's Haircut", 60m },
                    { 2, 1, null, 90, "Hair Coloring", 85m },
                    { 3, 1, null, 45, "Wash & Blow Dry", 40m },
                    { 4, 1, null, 120, "Keratin Treatment", 150m },
                    { 5, 2, null, 45, "Classic Manicure", 25m },
                    { 6, 2, null, 90, "Gel Manicure", 50m },
                    { 7, 2, null, 90, "Nail Extensions", 85m },
                    { 8, 2, null, 30, "Gel Removal", 15m },
                    { 9, 3, null, 45, "Everyday Makeup", 50m },
                    { 10, 3, null, 120, "Evening Makeup", 150m },
                    { 11, 3, null, 120, "Bridal Makeup", 150m },
                    { 12, 3, null, 90, "Makeup Trial", 100m }
                });

            migrationBuilder.InsertData(
                table: "EmployeeServices",
                columns: new[] { "EmployeeId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 5, 5 },
                    { 5, 6 },
                    { 6, 5 },
                    { 6, 7 },
                    { 7, 6 },
                    { 7, 8 },
                    { 8, 5 },
                    { 8, 8 },
                    { 9, 9 },
                    { 9, 10 },
                    { 10, 10 },
                    { 10, 11 },
                    { 11, 9 },
                    { 11, 12 },
                    { 12, 9 },
                    { 12, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSchedules_EmployeeId",
                table: "EmployeeSchedules",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSchedules");

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 9, 10 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 10, 11 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 11, 12 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "EmployeeServices",
                keyColumns: new[] { "EmployeeId", "ServiceId" },
                keyValues: new object[] { 12, 12 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Categories");
        }
    }
}
