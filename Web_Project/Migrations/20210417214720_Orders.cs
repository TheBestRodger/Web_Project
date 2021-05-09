﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web_Project.Migrations
{
    public partial class Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pr",
                table: "PageItem");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ordertime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FunID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    functionsid = table.Column<int>(type: "int", nullable: true),
                    orderid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Functions_functionsid",
                        column: x => x.functionsid,
                        principalTable: "Functions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_orderid",
                        column: x => x.orderid,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_functionsid",
                table: "OrderDetail",
                column: "functionsid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderid",
                table: "OrderDetail",
                column: "orderid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AddColumn<int>(
                name: "pr",
                table: "PageItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
