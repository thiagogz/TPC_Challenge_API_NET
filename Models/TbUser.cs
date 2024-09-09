using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_USERS")]
public partial class TbUser
{
    [Key]
    [Column("USERSID", TypeName = "NUMBER(38)")]
    public decimal Usersid { get; set; }

    [Column("NOME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [Column("SOBRENOME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Sobrenome { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(255)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("PASSWORD")]
    [StringLength(255)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("TELEFONE")]
    [Precision(11)]
    public long Telefone { get; set; }

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

    [Column("ATIVO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Ativo { get; set; } = null!;

    [InverseProperty("Users")]
    [JsonIgnore]
    public virtual ICollection<TbCompra> TbCompras { get; set; } = new List<TbCompra>();

    [InverseProperty("User")]
    [JsonIgnore]
    public virtual ICollection<TbUserCluster> TbUserClusters { get; set; } = new List<TbUserCluster>();
}
