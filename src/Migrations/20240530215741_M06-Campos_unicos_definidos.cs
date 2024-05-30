using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoSchedule.Migrations
{
    /// <inheritdoc />
    public partial class M06Campos_unicos_definidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CPF",
                table: "Pacientes",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Email",
                table: "Pacientes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_CPF",
                table: "Dentistas",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dentistas_CRO",
                table: "Dentistas",
                column: "CRO",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pacientes_CPF",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_Email",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Dentistas_CPF",
                table: "Dentistas");

            migrationBuilder.DropIndex(
                name: "IX_Dentistas_CRO",
                table: "Dentistas");
        }
    }
}
