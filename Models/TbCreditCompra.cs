using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Keyless]
[Table("TB_CREDIT_COMPRAS")]
public partial class TbCreditCompra
{
    [Column("CREDITID", TypeName = "NUMBER(38)")]
    [JsonIgnore]
    public decimal Creditid { get; set; }

    [Column("COMPRAID", TypeName = "NUMBER(38)")]
    [JsonIgnore]
    public decimal Compraid { get; set; }

    [ForeignKey("Compraid")]
    public virtual TbCompra Compra { get; set; } = null!;

    [ForeignKey("Creditid")]
    public virtual TbCredit Credit { get; set; } = null!;
}
