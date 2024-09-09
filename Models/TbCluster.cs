using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_CLUSTER")]
public partial class TbCluster
{
    [Key]
    [Column("CLUSTERID", TypeName = "NUMBER(38)")]
    public decimal Clusterid { get; set; }

    [Column("NAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("DESCRICAO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Descricao { get; set; } = null!;

    [InverseProperty("Cluster")]
    [JsonIgnore]
    public virtual ICollection<TbCampanha> TbCampanhas { get; set; } = new List<TbCampanha>();

    [InverseProperty("Cluster")]
    [JsonIgnore]
    public virtual ICollection<TbUserCluster> TbUserClusters { get; set; } = new List<TbUserCluster>();
}
