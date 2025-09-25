using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class FixCalificacionAutoincrement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "alumno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__alumno__3213E83F3F0168AC", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    pass = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__profesor__9AFF8FC762B5F438", x => x.usuario);
                });

            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    creditos = table.Column<int>(type: "int", nullable: false),
                    profesor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__asignatu__3213E83F9CC516AC", x => x.id);
                    table.ForeignKey(
                        name: "FK_asignatura_profesor",
                        column: x => x.profesor,
                        principalTable: "profesor",
                        principalColumn: "usuario");
                });

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alumnoId = table.Column<int>(type: "int", nullable: false),
                    asignaturaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__matricul__3213E83FAD0A910E", x => x.id);
                    table.ForeignKey(
                        name: "FK_matricula_alumno",
                        column: x => x.alumnoId,
                        principalTable: "alumno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matricula_asignatura",
                        column: x => x.asignaturaId,
                        principalTable: "asignatura",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calificacion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    nota = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    porcentaje = table.Column<int>(type: "int", nullable: false),
                    matriculaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__califica__3213E83F5FA5433E", x => x.id);
                    table.ForeignKey(
                        name: "FK_calificacion_matricula",
                        column: x => x.matriculaId,
                        principalTable: "matricula",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__alumno__AB6E61645632E201",
                table: "alumno",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__alumno__D87608A7B7798625",
                table: "alumno",
                column: "dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_asignatura_profesor",
                table: "asignatura",
                column: "profesor");

            migrationBuilder.CreateIndex(
                name: "IX_calificacion_matricula",
                table: "calificacion",
                column: "matriculaId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_alumno",
                table: "matricula",
                column: "alumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_asignatura",
                table: "matricula",
                column: "asignaturaId");

            migrationBuilder.CreateIndex(
                name: "UQ_matricula",
                table: "matricula",
                columns: new[] { "alumnoId", "asignaturaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__profesor__AB6E616453C9ACF2",
                table: "profesor",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificacion");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "alumno");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "profesor");
        }
    }
}
