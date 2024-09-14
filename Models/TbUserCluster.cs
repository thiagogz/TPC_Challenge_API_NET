using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_USER_CLUSTER")]
public partial class TbUserCluster
{
    [Key]
    [Column("USERCLUSTERID", TypeName = "NUMBER(38)")]
    public decimal Userclusterid { get; set; }

    [Column("CLUSTERID", TypeName = "NUMBER(38)")]
    public decimal Clusterid { get; set; }

    [Column("USERID", TypeName = "NUMBER(38)")]
    public decimal Userid { get; set; }

    [ForeignKey("Clusterid")]
    [InverseProperty("TbUserClusters")]
    public virtual TbCluster? Cluster { get; set; }

    [ForeignKey("Userid")]
    [InverseProperty("TbUserClusters")]
    public virtual TbUser? User { get; set; }
}
