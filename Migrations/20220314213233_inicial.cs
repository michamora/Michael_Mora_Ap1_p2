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
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Existencia = table.Column<float>(type: "REAL", nullable: false),
                    Costo = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Ganancia = table.Column<double>(type: "REAL", nullable: false),
                    ValorInventario = table.Column<float>(type: "REAL", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "ProductosDetalle",
                columns: table => new
                {
                    ProductoDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    ExistenciaEmpacada = table.Column<float>(type: "REAL", nullable: true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosDetalle", x => x.ProductoDetalleId);
                    table.ForeignKey(
                        name: "FK_ProductosDetalle_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateTable(
                name: "EntradaEmpacados",
                columns: table => new
                {
                    EmpacadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Concepto = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PProducidosProductoDetalleId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaEmpacados", x => x.EmpacadosId);
                    table.ForeignKey(
                        name: "FK_EntradaEmpacados_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId");
                    table.ForeignKey(
                        name: "FK_EntradaEmpacados_ProductosDetalle_PProducidosProductoDetalleId",
                        column: x => x.PProducidosProductoDetalleId,
                        principalTable: "ProductosDetalle",
                        principalColumn: "ProductoDetalleId");
                });

            migrationBuilder.CreateTable(
                name: "PresentacionDetalles",
                columns: table => new
                {
                    ProductoDetallesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Presentacion = table.Column<string>(type: "TEXT", nullable: false),
                    Cantidad = table.Column<float>(type: "REAL", nullable: false),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    PesoTotal = table.Column<float>(type: "REAL", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExistenciaEmpacada = table.Column<float>(type: "REAL", nullable: false),
                    EntradaEmpacadosEmpacadosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentacionDetalles", x => x.ProductoDetallesId);
                    table.ForeignKey(
                        name: "FK_PresentacionDetalles_EntradaEmpacados_EntradaEmpacadosEmpacadosId",
                        column: x => x.EntradaEmpacadosEmpacadosId,
                        principalTable: "EntradaEmpacados",
                        principalColumn: "EmpacadosId");
                });

            migrationBuilder.CreateTable(
                name: "ProductosUtilizados",
                columns: table => new
                {
                    ProductosUtilizadosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CantidadUtilizados = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductoDetalleId = table.Column<int>(type: "INTEGER", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    EntradaEmpacadosEmpacadosId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosUtilizados", x => x.ProductosUtilizadosId);
                    table.ForeignKey(
                        name: "FK_ProductosUtilizados_EntradaEmpacados_EntradaEmpacadosEmpacadosId",
                        column: x => x.EntradaEmpacadosEmpacadosId,
                        principalTable: "EntradaEmpacados",
                        principalColumn: "EmpacadosId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaEmpacados_PProducidosProductoDetalleId",
                table: "EntradaEmpacados",
                column: "PProducidosProductoDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaEmpacados_ProductoId",
                table: "EntradaEmpacados",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentacionDetalles_EntradaEmpacadosEmpacadosId",
                table: "PresentacionDetalles",
                column: "EntradaEmpacadosEmpacadosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosDetalle_ProductoId",
                table: "ProductosDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosUtilizados_EntradaEmpacadosEmpacadosId",
                table: "ProductosUtilizados",
                column: "EntradaEmpacadosEmpacadosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentacionDetalles");

            migrationBuilder.DropTable(
                name: "ProductosUtilizados");

            migrationBuilder.DropTable(
                name: "EntradaEmpacados");

            migrationBuilder.DropTable(
                name: "ProductosDetalle");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
