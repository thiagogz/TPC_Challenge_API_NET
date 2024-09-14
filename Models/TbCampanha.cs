using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_CAMPANHAS")]
public partial class TbCampanha
{
    [Key]
    [Column("CAMPANHAID", TypeName = "NUMBER(38)")]
    public decimal Campanhaid { get; set; }

    [Column("MASTERID", TypeName = "NUMBER(38)")]
    public decimal Masterid { get; set; }

    [Column("CLUSTERID", TypeName = "NUMBER(38)")]
    public decimal Clusterid { get; set; }

    [Column("TITULO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("CONTEUDO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Conteudo { get; set; } = null!;

    [Column("DESCRICAO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [Column("CANALTIPO", TypeName = "NUMBER(38)")]
    public decimal Canaltipo { get; set; }

    [ForeignKey("Clusterid")]
    [InverseProperty("TbCampanhas")]
    public virtual TbCluster? Cluster { get; set; } 

    [ForeignKey("Masterid")]
    [InverseProperty("TbCampanhas")]
    public virtual TbUsermaster? Master { get; set; } 
}
