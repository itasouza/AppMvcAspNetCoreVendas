using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class BancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoCliente = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoFornecedor = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabPedidos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Ativo = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true),
                    FornecedorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enderecos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Imagem = table.Column<string>(type: "varchar(100)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime", nullable: true),
                    ProdutoPromocao = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    Ativo = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    FornecedorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    QtdProduto = table.Column<int>(nullable: false),
                    ValorProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ValorTotalProduto = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Ativo = table.Column<bool>(unicode: false, maxLength: 1, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: true),
                    CabPedidoId = table.Column<Guid>(nullable: false),
                    ProdutoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetPedidos_CabPedidos_CabPedidoId",
                        column: x => x.CabPedidoId,
                        principalTable: "CabPedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetPedidos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabPedidos_ClienteId",
                table: "CabPedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetPedidos_CabPedidoId",
                table: "DetPedidos",
                column: "CabPedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetPedidos_ProdutoId",
                table: "DetPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FornecedorId",
                table: "Enderecos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorId",
                table: "Produtos",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetPedidos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "CabPedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
