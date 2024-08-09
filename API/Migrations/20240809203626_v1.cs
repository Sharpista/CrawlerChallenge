using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "servidores_proxy",
                columns: table => new
                {
                    id_servidor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    protocolo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    porta = table.Column<int>(type: "int", nullable: true),
                    codigo_pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    https = table.Column<bool>(type: "bit", nullable: true),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    anonimato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latencia = table.Column<double>(type: "float", nullable: true),
                    ultima_verificacao = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servidores_proxy", x => x.id_servidor);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "servidores_proxy");
        }
    }
}
