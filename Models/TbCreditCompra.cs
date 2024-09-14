using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_CREDIT_COMPRAS")]
public partial class TbCreditCompra
{
    [Key]
    [Column("CREDITID", TypeName = "NUMBER(38)")]
    public decimal Creditid { get; set; }

    [Key]
    [Column("COMPRAID", TypeName = "NUMBER(38)")]
    public decimal Compraid { get; set; }

    [ForeignKey("Compraid")]
    public virtual TbCompra? Compra { get; set; }

    [ForeignKey("Creditid")]
    public virtual TbCredit? Credit { get; set; }
}
