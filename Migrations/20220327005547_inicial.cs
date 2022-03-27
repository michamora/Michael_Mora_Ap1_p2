using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcial2.Migrations
{   
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradaEmpacados",
                columns: table => new
                {
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: false),
                    CantidadUtilizada = table.Column<float>(type: "REAL", nullable: false),
                    CantidadProducida = table.Column<float>(type: "REAL", nullable: false),
                    PesoTotal = table.Column<float>(type: "REAL", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaEmpacados", x => x.EmpacadosId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Existencia = table.Column<float>(type: "REAL", nullable: false),
                    Peso = table.Column<float>(type: "REAL", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Ganancia = table.Column<double>(type: "REAL", nullable: false),
                    ValorInventario = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "EmpacadosDetalle",
                columns: table => new
                {
                    EmpacadosDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpacadosDetalle", x => x.EmpacadosDetalleId);
                    table.ForeignKey(
                        name: "FK_EmpacadosDetalle_EntradaEmpacados_EmpacadosId",
                        column: x => x.EmpacadosId,
                        principalTable: "EntradaEmpacados",
                        principalColumn: "EmpacadosId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpacadosDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalle",
                columns: table => new
                {
                    ProductoDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: true),
                    Cantidad = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalle", x => x.ProductoDetalleId);
                    table.ForeignKey(
                        name: "FK_ProductosDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpacadosDetalle_EmpacadosId",
                table: "EmpacadosDetalle",
                column: "EmpacadosId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpacadosDetalle_ProductoId",
                table: "EmpacadosDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalle_ProductoId",
                table: "ProductosDetalle",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpacadosDetalle");

            migrationBuilder.DropTable(
                name: "ProductosDetalle");

            migrationBuilder.DropTable(
                name: "EntradaEmpacados");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
