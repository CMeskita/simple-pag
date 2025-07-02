using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace simple_pag_Infra.Migrations
{
    /// <inheritdoc />
    public partial class contato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Finalizadoras_Pagamentos_PagamentoId",
            //    table: "Finalizadoras");

            //migrationBuilder.DropIndex(
            //    name: "IX_Finalizadoras_PagamentoId",
            //    table: "Finalizadoras");

            //migrationBuilder.DropColumn(
            //    name: "Modalidade",
            //    table: "Finalizadoras");

            //migrationBuilder.DropColumn(
            //    name: "PagamentoId",
            //    table: "Finalizadoras");

            //migrationBuilder.DropColumn(
            //    name: "QtdParcelas",
            //    table: "Finalizadoras");

            //migrationBuilder.RenameColumn(
            //    name: "Vencimento",
            //    table: "Finalizadoras",
            //    newName: "UsuarioId");

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    Registro = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    UsuarioId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
        //    migrationBuilder.CreateTable(
        //        name: "FinalizadoraPagamentos",
        //        columns: table => new
        //        {
        //            Id = table.Column<string>(type: "text", nullable: false),
        //            FinalizadoraId = table.Column<string>(type: "text", nullable: false),
        //            Valor = table.Column<decimal>(type: "numeric", nullable: false),
        //            Parcelas = table.Column<int>(type: "integer", nullable: false),
        //            Modalidade = table.Column<int>(type: "integer", nullable: false),
        //            PagamentoId = table.Column<string>(type: "text", nullable: false),
        //            Vencimento = table.Column<string>(type: "text", nullable: false),
        //            UsuarioId = table.Column<string>(type: "text", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_FinalizadoraPagamentos", x => x.Id);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_Contatos_UsuarioId",
        //        table: "Contatos",
        //        column: "UsuarioId");
        //}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            //migrationBuilder.DropTable(
            //    name: "FinalizadoraPagamentos");

            //migrationBuilder.RenameColumn(
            //    name: "UsuarioId",
            //    table: "Finalizadoras",
            //    newName: "Vencimento");

            //migrationBuilder.AddColumn<string>(
            //    name: "Modalidade",
            //    table: "Finalizadoras",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "PagamentoId",
            //    table: "Finalizadoras",
            //    type: "text",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<int>(
            //    name: "QtdParcelas",
            //    table: "Finalizadoras",
            //    type: "integer",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Finalizadoras_PagamentoId",
            //    table: "Finalizadoras",
            //    column: "PagamentoId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Finalizadoras_Pagamentos_PagamentoId",
            //    table: "Finalizadoras",
            //    column: "PagamentoId",
            //    principalTable: "Pagamentos",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
