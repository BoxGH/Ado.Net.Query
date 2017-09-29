//using System;
//using System.Collections.Generic;
//using Microsoft.Data.Entity.Migrations;
//using Microsoft.Data.Entity.Metadata;

//namespace TjAppUI.Migrations
//{
//    public partial class Initial : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Customer",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    CustomerFullName = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Customer", x => x.Id);
//                });
//            migrationBuilder.CreateTable(
//                name: "Product",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    Name = table.Column<string>(nullable: true),
//                    Price = table.Column<decimal>(nullable: false),
//                    Quantity = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Product", x => x.Id);
//                });
//            migrationBuilder.CreateTable(
//                name: "Order",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    Amount = table.Column<decimal>(nullable: false),
//                    CustomerId = table.Column<int>(nullable: false),
//                    CustomerName = table.Column<string>(nullable: true),
//                    DateOperation = table.Column<DateTime>(nullable: false),
//                    OrderNumber = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Order", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Order_Customer_CustomerId",
//                        column: x => x.CustomerId,
//                        principalTable: "Customer",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//            migrationBuilder.CreateTable(
//                name: "ProductOrder",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
//                    OrderId = table.Column<int>(nullable: false),
//                    ProductId = table.Column<int>(nullable: false),
//                    Quantity = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_ProductOrder", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_ProductOrder_Order_OrderId",
//                        column: x => x.OrderId,
//                        principalTable: "Order",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                    table.ForeignKey(
//                        name: "FK_ProductOrder_Product_ProductId",
//                        column: x => x.ProductId,
//                        principalTable: "Product",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Cascade);
//                });
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable("ProductOrder");
//            migrationBuilder.DropTable("Order");
//            migrationBuilder.DropTable("Product");
//            migrationBuilder.DropTable("Customer");
//        }
//    }
//}
