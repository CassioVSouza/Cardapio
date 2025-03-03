using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cardapio.ApiService.Migrations
{
    /// <inheritdoc />
    public partial class Update_Pedidos_e_Usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ECozinha",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ECozinha",
                table: "Usuario");
        }
    }
}
