using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoClienteApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable_DATA_HORA_ULTIMA_ATUALIZACAO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DATAHORAULTIMAATUALIZACAO",
                table: "CLIENTE",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATAHORAULTIMAATUALIZACAO",
                table: "CLIENTE");
        }
    }
}
