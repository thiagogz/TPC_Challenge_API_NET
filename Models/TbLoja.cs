using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_LOJA")]
public partial class TbLoja
{
    [Key]
    [Column("PDVID", TypeName = "NUMBER(38)")]
    public decimal Pdvid { get; set; }

    [Column("NOMELOJA")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nomeloja { get; set; } = null!;

    [Column("ENDERECO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Endereco { get; set; } = null!;

    [Column("NUMERO", TypeName = "NUMBER(38)")]
    public decimal Numero { get; set; }

    [Column("COMPLEMENTO")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Complemento { get; set; }

    [Column("CEP")]
    [StringLength(9)]
    [Unicode(false)]
    public string Cep { get; set; } = null!;

    [Column("ATIVO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Ativo { get; set; } = null!;

    [InverseProperty("Pdv")]
    [JsonIgnore]
    public virtual ICollection<TbCompra> TbCompras { get; set; } = new List<TbCompra>();

    [InverseProperty("Pdv")]
    [JsonIgnore]
    public virtual ICollection<TbNotificaco> TbNotificacos { get; set; } = new List<TbNotificaco>();

    [InverseProperty("Pdv")]
    [JsonIgnore]
    public virtual ICollection<TbProduto> TbProdutos { get; set; } = new List<TbProduto>();

    [InverseProperty("Pdv")]
    [JsonIgnore]
    public virtual ICollection<TbUserPdv> TbUserPdvs { get; set; } = new List<TbUserPdv>();
}
