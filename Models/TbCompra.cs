using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_COMPRAS")]
public partial class TbCompra
{
    [Key]
    [Column("COMPRAID", TypeName = "NUMBER(38)")]
    public decimal Compraid { get; set; }

    [Column("USERSID", TypeName = "NUMBER(38)")]
    public decimal Usersid { get; set; }

    [Column("PDVID", TypeName = "NUMBER(38)")]
    public decimal Pdvid { get; set; }

    [Column("VALOR", TypeName = "NUMBER(15,2)")]
    public decimal Valor { get; set; }

    [Column("DATACOMPRA", TypeName = "DATE")]
    public DateTime Datacompra { get; set; }

    [ForeignKey("Pdvid")]
    [InverseProperty("TbCompras")]
    public virtual TbLoja? Pdv { get; set; }

    [ForeignKey("Usersid")]
    [InverseProperty("TbCompras")]
    public virtual TbUser? Users { get; set; }
}
