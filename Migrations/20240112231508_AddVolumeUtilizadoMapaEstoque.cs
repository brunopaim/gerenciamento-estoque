﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gerenciamento_estoque.Migrations
{
    public partial class AddVolumeUtilizadoMapaEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VolumeUtilizado",
                table: "MapaEstoque",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolumeUtilizado",
                table: "MapaEstoque");
        }
    }
}