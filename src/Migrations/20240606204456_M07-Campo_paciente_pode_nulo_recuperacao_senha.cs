using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoSchedule.Migrations
{
    /// <inheritdoc />
    public partial class M07Campo_paciente_pode_nulo_recuperacao_senha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecoveryCodes_Pacientes_PacienteId",
                table: "RecoveryCodes");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "RecoveryCodes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RecoveryCodes_Pacientes_PacienteId",
                table: "RecoveryCodes",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecoveryCodes_Pacientes_PacienteId",
                table: "RecoveryCodes");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "RecoveryCodes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RecoveryCodes_Pacientes_PacienteId",
                table: "RecoveryCodes",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
