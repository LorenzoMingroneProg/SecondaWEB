﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mingrone.Lorenzo._5h.SecondaWeb.Migrations
{
    public partial class LastCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Prenotazioni",
                newName: "PrenotazioneId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPrenotazione",
                table: "Prenotazioni",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPrenotazione",
                table: "Prenotazioni");

            migrationBuilder.RenameColumn(
                name: "PrenotazioneId",
                table: "Prenotazioni",
                newName: "Id");
        }
    }
}
