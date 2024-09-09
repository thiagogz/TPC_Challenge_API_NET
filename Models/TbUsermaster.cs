using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_USERMASTER")]
public partial class TbUsermaster
{
    [Key]
    [Column("MASTERID", TypeName = "NUMBER(38)")]
    public decimal Masterid { get; set; }

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

    [Column("DATAREGISTRO", TypeName = "DATE")]
    public DateTime Dataregistro { get; set; }

    [Column("ATIVO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Ativo { get; set; } = null!;

    [InverseProperty("Master")]
    [JsonIgnore]
    public virtual ICollection<TbCampanha> TbCampanhas { get; set; } = new List<TbCampanha>();
}
