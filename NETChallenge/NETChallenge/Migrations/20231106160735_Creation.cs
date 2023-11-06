using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace challenge.Migrations
{
    /// <inheritdoc />
    public partial class Creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ticker = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(14,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoOrdenDeInversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoOrdenDeInversion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeInversionOperacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeInversionOperacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDeActivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDeActivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoOperacionAuditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoOperacionAuditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenDeInversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    OrdenDeInversionOperacionId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    TipoDeActivoId = table.Column<int>(type: "int", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    AccionId = table.Column<int>(type: "int", nullable: true),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenDeInversion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenDeInversion_Accion_AccionId",
                        column: x => x.AccionId,
                        principalTable: "Accion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrdenDeInversion_EstadoOrdenDeInversion_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoOrdenDeInversion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeInversion_OrdenDeInversionOperacion_OrdenDeInversionOperacionId",
                        column: x => x.OrdenDeInversionOperacionId,
                        principalTable: "OrdenDeInversionOperacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenDeInversion_TipoDeActivo_TipoDeActivoId",
                        column: x => x.TipoDeActivoId,
                        principalTable: "TipoDeActivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoOperacionAuditoriaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tabla = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditoria_TipoOperacionAuditoria_TipoOperacionAuditoriaId",
                        column: x => x.TipoOperacionAuditoriaId,
                        principalTable: "TipoOperacionAuditoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auditoria_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accion",
                columns: new[] { "Id", "Nombre", "PrecioUnitario", "Ticker" },
                values: new object[,]
                {
                    { 1, "Apple", 177.97m, "AAPL" },
                    { 2, "Alphabet Inc", 138.21m, "GOOGL" },
                    { 3, "Microsoft", 329.04m, "MSFT" },
                    { 4, "Coca Cola", 58.3m, "KO" },
                    { 5, "Walmart", 163.42m, "WMT" }
                });

            migrationBuilder.InsertData(
                table: "EstadoOrdenDeInversion",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 0, "En Proceso" },
                    { 1, "Ejecutada" },
                    { 3, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "OrdenDeInversionOperacion",
                columns: new[] { "Id", "Identificador" },
                values: new object[,]
                {
                    { 1, "C" },
                    { 2, "V" }
                });

            migrationBuilder.InsertData(
                table: "TipoDeActivo",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "FCI" },
                    { 2, "Acción" },
                    { 3, "Bono" }
                });

            migrationBuilder.InsertData(
                table: "TipoOperacionAuditoria",
                columns: new[] { "Id", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Alta" },
                    { 2, "Baja" },
                    { 3, "Modificacion" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Contraseña", "NombreUsuario" },
                values: new object[] { 1, "AGecY2IjNhzArzIUZR2ZRSBZv8eFtVrBitRMWZ27zq1YdxyHPp986NyoDPjX+kussQ==", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_TipoOperacionAuditoriaId",
                table: "Auditoria",
                column: "TipoOperacionAuditoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_UsuarioId",
                table: "Auditoria",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeInversion_AccionId",
                table: "OrdenDeInversion",
                column: "AccionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeInversion_EstadoId",
                table: "OrdenDeInversion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeInversion_OrdenDeInversionOperacionId",
                table: "OrdenDeInversion",
                column: "OrdenDeInversionOperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenDeInversion_TipoDeActivoId",
                table: "OrdenDeInversion",
                column: "TipoDeActivoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "OrdenDeInversion");

            migrationBuilder.DropTable(
                name: "TipoOperacionAuditoria");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Accion");

            migrationBuilder.DropTable(
                name: "EstadoOrdenDeInversion");

            migrationBuilder.DropTable(
                name: "OrdenDeInversionOperacion");

            migrationBuilder.DropTable(
                name: "TipoDeActivo");
        }
    }
}
