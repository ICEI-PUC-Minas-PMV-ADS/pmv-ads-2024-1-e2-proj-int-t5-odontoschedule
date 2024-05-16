using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OdontoSchedule.Migrations
{
    /// <inheritdoc />
    public partial class M03Paciente_notificacao_pode_nulo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Pacientes_PacienteId",
                table: "Notificacoes");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Notificacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Pacientes_PacienteId",
                table: "Notificacoes",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notificacoes_Pacientes_PacienteId",
                table: "Notificacoes");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "Notificacoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificacoes_Pacientes_PacienteId",
                table: "Notificacoes",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
