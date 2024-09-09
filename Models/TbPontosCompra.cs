using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Keyless]
[Table("TB_PONTOS_COMPRA")]
public partial class TbPontosCompra
{
    [Column("COMPRAID", TypeName = "NUMBER(38)")]
    [JsonIgnore]
    public decimal Compraid { get; set; }

    [Column("POINTID", TypeName = "NUMBER(38)")]
    [JsonIgnore]
    public decimal Pointid { get; set; }

    [ForeignKey("Compraid")]
    public virtual TbCompra Compra { get; set; } = null!;

    [ForeignKey("Pointid")]
    public virtual TbPonto Point { get; set; } = null!;
}
