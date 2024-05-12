using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OdontoSchedule.Migrations
{
    /// <inheritdoc />
    public partial class M02horario_seeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Sexo",
                table: "Pacientes",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Horarios",
                columns: new[] { "ID", "Hora" },
                values: new object[,]
                {
                    { 1, new TimeOnly(8, 0, 0) },
                    { 2, new TimeOnly(8, 30, 0) },
                    { 3, new TimeOnly(9, 0, 0) },
                    { 4, new TimeOnly(9, 30, 0) },
                    { 5, new TimeOnly(10, 0, 0) },
                    { 6, new TimeOnly(10, 30, 0) },
                    { 7, new TimeOnly(11, 0, 0) },
                    { 8, new TimeOnly(11, 30, 0) },
                    { 9, new TimeOnly(12, 0, 0) },
                    { 10, new TimeOnly(12, 30, 0) },
                    { 11, new TimeOnly(13, 0, 0) },
                    { 12, new TimeOnly(13, 30, 0) },
                    { 13, new TimeOnly(14, 0, 0) },
                    { 14, new TimeOnly(14, 30, 0) },
                    { 15, new TimeOnly(15, 0, 0) },
                    { 16, new TimeOnly(15, 30, 0) },
                    { 17, new TimeOnly(16, 0, 0) },
                    { 18, new TimeOnly(16, 30, 0) },
                    { 19, new TimeOnly(17, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Horarios",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.AlterColumn<bool>(
                name: "Sexo",
                table: "Pacientes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
