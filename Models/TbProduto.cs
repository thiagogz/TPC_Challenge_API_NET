using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_PRODUTOS")]
public partial class TbProduto
{
    [Key]
    [Column("PRODUTOID", TypeName = "NUMBER(38)")]
    public decimal Produtoid { get; set; }

    [Column("PDVID", TypeName = "NUMBER(38)")]
    public decimal Pdvid { get; set; }

    [Column("CATEGORIAID", TypeName = "NUMBER(38)")]
    public decimal Categoriaid { get; set; }

    [Column("NOME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("DESCRICAO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Descricao { get; set; }

    [Column("VALOR", TypeName = "NUMBER(15,2)")]
    public decimal Valor { get; set; }

    [Column("ATIVO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Ativo { get; set; } = null!;

    [ForeignKey("Categoriaid")]
    [InverseProperty("TbProdutos")]
    public virtual TbCategoria? Categoria { get; set; }

    [ForeignKey("Pdvid")]
    [InverseProperty("TbProdutos")]
    public virtual TbLoja? Pdv { get; set; }
}
