using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shopping.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAdminstrator",
                columns: table => new
                {
                    Admin_name = table.Column<string>(maxLength: 50, nullable: true),
                    Admin_Pw = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "TbCart",
                columns: table => new
                {
                    Cart_ID = table.Column<int>(nullable: false),
                    Cart_Img = table.Column<byte[]>(nullable: true),
                    Cart_Name = table.Column<string>(nullable: true),
                    Cart_Price = table.Column<double>(nullable: true),
                    Cart_Qty = table.Column<int>(nullable: true),
                    Cart_Total = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCart", x => x.Cart_ID);
                });

            migrationBuilder.CreateTable(
                name: "TbCategory",
                columns: table => new
                {
                    Cate_ID = table.Column<int>(nullable: false),
                    Cate_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategory", x => x.Cate_ID);
                });

            migrationBuilder.CreateTable(
                name: "TbCustomer",
                columns: table => new
                {
                    Cus_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cus_Name = table.Column<string>(nullable: true),
                    Cus_Email = table.Column<string>(nullable: true),
                    Cus_Phone = table.Column<string>(nullable: true),
                    Cus_Address = table.Column<string>(nullable: true),
                    Cus_Receipt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCustomer", x => x.Cus_ID);
                });

            migrationBuilder.CreateTable(
                name: "TbReview",
                columns: table => new
                {
                    Rev_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Pd_Name = table.Column<string>(nullable: true),
                    Rev_Title = table.Column<string>(nullable: true),
                    Rev_Message = table.Column<string>(nullable: true),
                    Rev_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Rating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbReview", x => x.Rev_ID);
                });

            migrationBuilder.CreateTable(
                name: "TbProduct",
                columns: table => new
                {
                    Pd_ID = table.Column<int>(nullable: false),
                    Pd_Img = table.Column<byte[]>(nullable: true),
                    Pd_Name = table.Column<string>(nullable: true),
                    Pd_Price = table.Column<double>(nullable: true),
                    Pd_Stock = table.Column<int>(nullable: true),
                    Pd_Status = table.Column<string>(nullable: true),
                    Cate_ID = table.Column<int>(nullable: true),
                    Pd_Detail = table.Column<string>(nullable: true),
                    Pd_SubHead = table.Column<string>(nullable: true),
                    Pd_Delete = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Product", x => x.Pd_ID);
                    table.ForeignKey(
                        name: "FK_TbProduct_TbCategory",
                        column: x => x.Cate_ID,
                        principalTable: "TbCategory",
                        principalColumn: "Cate_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbBill",
                columns: table => new
                {
                    Bill_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cus_ID = table.Column<int>(nullable: true),
                    Pd_ID = table.Column<int>(nullable: true),
                    Bill_Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Pd_Name = table.Column<string>(nullable: true),
                    Bill_Qty = table.Column<int>(nullable: true),
                    Bill_Total = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbBill", x => x.Bill_ID);
                    table.ForeignKey(
                        name: "FK_TbBill_TbCustomer",
                        column: x => x.Cus_ID,
                        principalTable: "TbCustomer",
                        principalColumn: "Cus_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbBill_TbProduct",
                        column: x => x.Pd_ID,
                        principalTable: "TbProduct",
                        principalColumn: "Pd_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbBill_Cus_ID",
                table: "TbBill",
                column: "Cus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TbBill_Pd_ID",
                table: "TbBill",
                column: "Pd_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TbProduct_Cate_ID",
                table: "TbProduct",
                column: "Cate_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbAdminstrator");

            migrationBuilder.DropTable(
                name: "TbBill");

            migrationBuilder.DropTable(
                name: "TbCart");

            migrationBuilder.DropTable(
                name: "TbReview");

            migrationBuilder.DropTable(
                name: "TbCustomer");

            migrationBuilder.DropTable(
                name: "TbProduct");

            migrationBuilder.DropTable(
                name: "TbCategory");
        }
    }
}
