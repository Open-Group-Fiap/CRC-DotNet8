using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRC.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueConstrainsInMb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_BONUS_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_BONUS");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_FATURA_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_FATURA");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_AUTH_ID_AUTH",
                table: "T_OP_CRC_MORADOR");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_MORADOR");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_BONUS_ID_BONUS",
                table: "T_OP_CRC_MORADOR_BONUS");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_MORADOR_BONUS");

            migrationBuilder.DropIndex(
                name: "IX_T_OP_CRC_MORADOR_BONUS_ID_MORADOR",
                table: "T_OP_CRC_MORADOR_BONUS");

            migrationBuilder.AlterColumn<int>(
                name: "PONTOS",
                table: "T_OP_CRC_MORADOR",
                type: "NUMBER(10)",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CUSTO",
                table: "T_OP_CRC_BONUS",
                type: "DECIMAL(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_T_OP_CRC_MORADOR_BONUS_ID_MORADOR_ID_BONUS",
                table: "T_OP_CRC_MORADOR_BONUS",
                columns: new[] { "ID_MORADOR", "ID_BONUS" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_BONUS_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_BONUS",
                column: "ID_CONDOMINIO",
                principalTable: "T_OP_CRC_CONDOMINIO",
                principalColumn: "ID_CONDOMINIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_FATURA_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_FATURA",
                column: "ID_MORADOR",
                principalTable: "T_OP_CRC_MORADOR",
                principalColumn: "ID_MORADOR",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_AUTH_ID_AUTH",
                table: "T_OP_CRC_MORADOR",
                column: "ID_AUTH",
                principalTable: "T_OP_CRC_AUTH",
                principalColumn: "ID_AUTH",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_MORADOR",
                column: "ID_CONDOMINIO",
                principalTable: "T_OP_CRC_CONDOMINIO",
                principalColumn: "ID_CONDOMINIO",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_BONUS_ID_BONUS",
                table: "T_OP_CRC_MORADOR_BONUS",
                column: "ID_BONUS",
                principalTable: "T_OP_CRC_BONUS",
                principalColumn: "ID_BONUS",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_MORADOR_BONUS",
                column: "ID_MORADOR",
                principalTable: "T_OP_CRC_MORADOR",
                principalColumn: "ID_MORADOR",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_BONUS_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_BONUS");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_FATURA_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_FATURA");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_AUTH_ID_AUTH",
                table: "T_OP_CRC_MORADOR");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_MORADOR");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_BONUS_ID_BONUS",
                table: "T_OP_CRC_MORADOR_BONUS");

            migrationBuilder.DropForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_MORADOR_BONUS");

            migrationBuilder.DropIndex(
                name: "IX_T_OP_CRC_MORADOR_BONUS_ID_MORADOR_ID_BONUS",
                table: "T_OP_CRC_MORADOR_BONUS");

            migrationBuilder.AlterColumn<int>(
                name: "PONTOS",
                table: "T_OP_CRC_MORADOR",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "CUSTO",
                table: "T_OP_CRC_BONUS",
                type: "DECIMAL(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18, 2)");

            migrationBuilder.CreateIndex(
                name: "IX_T_OP_CRC_MORADOR_BONUS_ID_MORADOR",
                table: "T_OP_CRC_MORADOR_BONUS",
                column: "ID_MORADOR");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_BONUS_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_BONUS",
                column: "ID_CONDOMINIO",
                principalTable: "T_OP_CRC_CONDOMINIO",
                principalColumn: "ID_CONDOMINIO");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_FATURA_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_FATURA",
                column: "ID_MORADOR",
                principalTable: "T_OP_CRC_MORADOR",
                principalColumn: "ID_MORADOR");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_AUTH_ID_AUTH",
                table: "T_OP_CRC_MORADOR",
                column: "ID_AUTH",
                principalTable: "T_OP_CRC_AUTH",
                principalColumn: "ID_AUTH");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_T_OP_CRC_CONDOMINIO_ID_CONDOMINIO",
                table: "T_OP_CRC_MORADOR",
                column: "ID_CONDOMINIO",
                principalTable: "T_OP_CRC_CONDOMINIO",
                principalColumn: "ID_CONDOMINIO");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_BONUS_ID_BONUS",
                table: "T_OP_CRC_MORADOR_BONUS",
                column: "ID_BONUS",
                principalTable: "T_OP_CRC_BONUS",
                principalColumn: "ID_BONUS");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OP_CRC_MORADOR_BONUS_T_OP_CRC_MORADOR_ID_MORADOR",
                table: "T_OP_CRC_MORADOR_BONUS",
                column: "ID_MORADOR",
                principalTable: "T_OP_CRC_MORADOR",
                principalColumn: "ID_MORADOR");
        }
    }
}
