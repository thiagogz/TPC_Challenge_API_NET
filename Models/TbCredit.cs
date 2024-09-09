using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_CREDIT")]
public partial class TbCredit
{
    [Key]
    [Column("CREDITID", TypeName = "NUMBER(38)")]
    public decimal Creditid { get; set; }

    [Column("VALOR", TypeName = "NUMBER(15,2)")]
    public decimal Valor { get; set; }

    [Column("DATACREDITO", TypeName = "DATE")]
    public DateTime Datacredito { get; set; }

    [Column("DATAEXPIRACAO", TypeName = "DATE")]
    public DateTime Dataexpiracao { get; set; }

    [Column("UTILIZADO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Utilizado { get; set; } = null!;
}
