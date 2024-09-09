using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_CATEGORIAS")]
public partial class TbCategoria
{
    [Key]
    [Column("CATEGORIAID", TypeName = "NUMBER(38)")]
    public decimal Categoriaid { get; set; }

    [Column("NOME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("DESCRICAO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [Column("ATIVO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Ativo { get; set; } = null!;

    [InverseProperty("Categoria")]
    [JsonIgnore]
    public virtual ICollection<TbProduto> TbProdutos { get; set; } = new List<TbProduto>();
}
