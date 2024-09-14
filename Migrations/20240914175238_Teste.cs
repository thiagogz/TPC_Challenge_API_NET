using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPC_Challenge_API_NET.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM99085");

            migrationBuilder.CreateTable(
                name: "TB_CATEGORIAS",
                schema: "RM99085",
                columns: table => new
                {
                    CATEGORIAID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    ATIVO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_CATEGORIAS_PK", x => x.CATEGORIAID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CLUSTER",
                schema: "RM99085",
                columns: table => new
                {
                    CLUSTERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_CLUSTER_PK", x => x.CLUSTERID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CREDIT",
                schema: "RM99085",
                columns: table => new
                {
                    CREDITID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    VALOR = table.Column<decimal>(type: "NUMBER(15,2)", nullable: false),
                    DATACREDITO = table.Column<DateTime>(type: "DATE", nullable: false),
                    DATAEXPIRACAO = table.Column<DateTime>(type: "DATE", nullable: false),
                    UTILIZADO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_CREDIT_PK", x => x.CREDITID);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOJA",
                schema: "RM99085",
                columns: table => new
                {
                    PDVID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOMELOJA = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    ENDERECO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    NUMERO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    CEP = table.Column<string>(type: "VARCHAR2(9)", unicode: false, maxLength: 9, nullable: false),
                    ATIVO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_LOJA_PK", x => x.PDVID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PONTOS",
                schema: "RM99085",
                columns: table => new
                {
                    POINTID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    VALOR = table.Column<decimal>(type: "NUMBER(15,2)", nullable: false),
                    DATACREDITADO = table.Column<DateTime>(type: "DATE", nullable: false),
                    DATAEXPIRADO = table.Column<DateTime>(type: "DATE", nullable: false),
                    UTILIZADO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_PONTOS_PK", x => x.POINTID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERMASTER",
                schema: "RM99085",
                columns: table => new
                {
                    MASTERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    SOBRENOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DATAREGISTRO = table.Column<DateTime>(type: "DATE", nullable: false),
                    ATIVO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_USERMASTER_PK", x => x.MASTERID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USERS",
                schema: "RM99085",
                columns: table => new
                {
                    USERSID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    SOBRENOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    TELEFONE = table.Column<long>(type: "NUMBER(11)", precision: 11, nullable: false),
                    ENDERECO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    NUMERO = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    ATIVO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_USERS_PK", x => x.USERSID);
                });

            migrationBuilder.CreateTable(
                name: "TB_NOTIFICACOES",
                schema: "RM99085",
                columns: table => new
                {
                    NOTIFICACOESID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PDVID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    TITULO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    MENSAGEM = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DATAENVIO = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_NOTIFICACOES_PK", x => x.NOTIFICACOESID);
                    table.ForeignKey(
                        name: "TB_NOTIFICACOES_ID_PDVID_FK",
                        column: x => x.PDVID,
                        principalSchema: "RM99085",
                        principalTable: "TB_LOJA",
                        principalColumn: "PDVID");
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTOS",
                schema: "RM99085",
                columns: table => new
                {
                    PRODUTOID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PDVID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    CATEGORIAID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: true),
                    VALOR = table.Column<decimal>(type: "NUMBER(15,2)", nullable: false),
                    ATIVO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_PRODUTOSV1_PK", x => x.PRODUTOID);
                    table.ForeignKey(
                        name: "TB_PRODUTOS_ID_CATEGORIAID_FK",
                        column: x => x.CATEGORIAID,
                        principalSchema: "RM99085",
                        principalTable: "TB_CATEGORIAS",
                        principalColumn: "CATEGORIAID");
                    table.ForeignKey(
                        name: "TB_PRODUTOS_ID_PDVID_FK",
                        column: x => x.PDVID,
                        principalSchema: "RM99085",
                        principalTable: "TB_LOJA",
                        principalColumn: "PDVID");
                });

            migrationBuilder.CreateTable(
                name: "TB_USER_PDV",
                schema: "RM99085",
                columns: table => new
                {
                    USERPDVID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PDVID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    SOBRENOME = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    PASSWORD = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DATAREGISTRO = table.Column<DateTime>(type: "DATE", nullable: false),
                    ATIVO = table.Column<string>(type: "CHAR(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_USERPDV_PK", x => x.USERPDVID);
                    table.ForeignKey(
                        name: "TB_USER_PDV_ID_PDVID_FK",
                        column: x => x.PDVID,
                        principalSchema: "RM99085",
                        principalTable: "TB_LOJA",
                        principalColumn: "PDVID");
                });

            migrationBuilder.CreateTable(
                name: "TB_CAMPANHAS",
                schema: "RM99085",
                columns: table => new
                {
                    CAMPANHAID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    MASTERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    CLUSTERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    TITULO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    CONTEUDO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR2(255)", unicode: false, maxLength: 255, nullable: false),
                    CANALTIPO = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_CAMPANHAS_PK", x => x.CAMPANHAID);
                    table.ForeignKey(
                        name: "TB_CAMPANHAS_ID_CLUSTERID_FK",
                        column: x => x.CLUSTERID,
                        principalSchema: "RM99085",
                        principalTable: "TB_CLUSTER",
                        principalColumn: "CLUSTERID");
                    table.ForeignKey(
                        name: "TB_CAMPANHAS_ID_MASTERID_FK",
                        column: x => x.MASTERID,
                        principalSchema: "RM99085",
                        principalTable: "TB_USERMASTER",
                        principalColumn: "MASTERID");
                });

            migrationBuilder.CreateTable(
                name: "TB_COMPRAS",
                schema: "RM99085",
                columns: table => new
                {
                    COMPRAID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    USERSID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    PDVID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    VALOR = table.Column<decimal>(type: "NUMBER(15,2)", nullable: false),
                    DATACOMPRA = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_COMPRAS_PK", x => x.COMPRAID);
                    table.ForeignKey(
                        name: "TB_COMPRAS_ID_PDVID_FK",
                        column: x => x.PDVID,
                        principalSchema: "RM99085",
                        principalTable: "TB_LOJA",
                        principalColumn: "PDVID");
                    table.ForeignKey(
                        name: "TB_COMPRAS_ID_USERSID_FK",
                        column: x => x.USERSID,
                        principalSchema: "RM99085",
                        principalTable: "TB_USERS",
                        principalColumn: "USERSID");
                });

            migrationBuilder.CreateTable(
                name: "TB_USER_CLUSTER",
                schema: "RM99085",
                columns: table => new
                {
                    USERCLUSTERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    CLUSTERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    USERID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TB_USER_CLUSTER_PK", x => x.USERCLUSTERID);
                    table.ForeignKey(
                        name: "TB_USER_CLUSTER_ID_CLUSTER_FK",
                        column: x => x.CLUSTERID,
                        principalSchema: "RM99085",
                        principalTable: "TB_CLUSTER",
                        principalColumn: "CLUSTERID");
                    table.ForeignKey(
                        name: "TB_USER_CLUSTER_ID_USERS_FK",
                        column: x => x.USERID,
                        principalSchema: "RM99085",
                        principalTable: "TB_USERS",
                        principalColumn: "USERSID");
                });

            migrationBuilder.CreateTable(
                name: "TB_CREDIT_COMPRAS",
                schema: "RM99085",
                columns: table => new
                {
                    CREDITID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    COMPRAID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "TB_CREDIT_C_ID_COMPRASID_FK",
                        column: x => x.COMPRAID,
                        principalSchema: "RM99085",
                        principalTable: "TB_COMPRAS",
                        principalColumn: "COMPRAID");
                    table.ForeignKey(
                        name: "TB_CREDIT_C_ID_CREDITID_FK",
                        column: x => x.CREDITID,
                        principalSchema: "RM99085",
                        principalTable: "TB_CREDIT",
                        principalColumn: "CREDITID");
                });

            migrationBuilder.CreateTable(
                name: "TB_PONTOS_COMPRA",
                schema: "RM99085",
                columns: table => new
                {
                    COMPRAID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    POINTID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "TB_PONTOS_C_ID_COMPRASID_FK",
                        column: x => x.COMPRAID,
                        principalSchema: "RM99085",
                        principalTable: "TB_COMPRAS",
                        principalColumn: "COMPRAID");
                    table.ForeignKey(
                        name: "TB_PONTOS_C_ID_PONTOSID_FK",
                        column: x => x.POINTID,
                        principalSchema: "RM99085",
                        principalTable: "TB_PONTOS",
                        principalColumn: "POINTID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CAMPANHAS_CLUSTERID",
                schema: "RM99085",
                table: "TB_CAMPANHAS",
                column: "CLUSTERID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CAMPANHAS_MASTERID",
                schema: "RM99085",
                table: "TB_CAMPANHAS",
                column: "MASTERID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPRAS_PDVID",
                schema: "RM99085",
                table: "TB_COMPRAS",
                column: "PDVID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMPRAS_USERSID",
                schema: "RM99085",
                table: "TB_COMPRAS",
                column: "USERSID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CREDIT_COMPRAS_COMPRAID",
                schema: "RM99085",
                table: "TB_CREDIT_COMPRAS",
                column: "COMPRAID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CREDIT_COMPRAS_CREDITID",
                schema: "RM99085",
                table: "TB_CREDIT_COMPRAS",
                column: "CREDITID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_NOTIFICACOES_PDVID",
                schema: "RM99085",
                table: "TB_NOTIFICACOES",
                column: "PDVID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTOS_COMPRA_COMPRAID",
                schema: "RM99085",
                table: "TB_PONTOS_COMPRA",
                column: "COMPRAID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PONTOS_COMPRA_POINTID",
                schema: "RM99085",
                table: "TB_PONTOS_COMPRA",
                column: "POINTID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_CATEGORIAID",
                schema: "RM99085",
                table: "TB_PRODUTOS",
                column: "CATEGORIAID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTOS_PDVID",
                schema: "RM99085",
                table: "TB_PRODUTOS",
                column: "PDVID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_CLUSTER_CLUSTERID",
                schema: "RM99085",
                table: "TB_USER_CLUSTER",
                column: "CLUSTERID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_CLUSTER_USERID",
                schema: "RM99085",
                table: "TB_USER_CLUSTER",
                column: "USERID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_PDV_PDVID",
                schema: "RM99085",
                table: "TB_USER_PDV",
                column: "PDVID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CAMPANHAS",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_CREDIT_COMPRAS",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_NOTIFICACOES",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_PONTOS_COMPRA",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_PRODUTOS",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_USER_CLUSTER",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_USER_PDV",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_USERMASTER",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_CREDIT",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_COMPRAS",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_PONTOS",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIAS",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_CLUSTER",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_LOJA",
                schema: "RM99085");

            migrationBuilder.DropTable(
                name: "TB_USERS",
                schema: "RM99085");
        }
    }
}
