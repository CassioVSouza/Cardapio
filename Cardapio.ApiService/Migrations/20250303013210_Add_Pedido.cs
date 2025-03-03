using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cardapio.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class Add_Pedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaCodigo = table.Column<int>(type: "int", nullable: false),
                    CodigoProduto = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pedido_Mesa_MesaCodigo",
                        column: x => x.MesaCodigo,
                        principalTable: "Mesa",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Produto_CodigoProduto",
                        column: x => x.CodigoProduto,
                        principalTable: "Produto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_CodigoProduto",
                table: "Pedido",
                column: "CodigoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_MesaCodigo",
                table: "Pedido",
                column: "MesaCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
