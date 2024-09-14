using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_PONTOS_COMPRA")]
public partial class TbPontosCompra
{
    [Key]
    [Column("COMPRAID", TypeName = "NUMBER(38)")]
    public decimal Compraid { get; set; }

    [Key]
    [Column("POINTID", TypeName = "NUMBER(38)")]
    public decimal Pointid { get; set; }

    [ForeignKey("Compraid")]
    public virtual TbCompra? Compra { get; set; }

    [ForeignKey("Pointid")]
    public virtual TbPonto? Point { get; set; }
}
