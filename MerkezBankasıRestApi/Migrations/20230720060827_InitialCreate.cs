﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerkezBankasıRestApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birimi = table.Column<int>(type: "int", nullable: false),
                    AlisKuru = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisKuru = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EfektifAlisKuru = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EfektifSatisKuru = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");
        }
    }
}
