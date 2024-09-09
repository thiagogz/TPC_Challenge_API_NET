using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_PONTOS")]
public partial class TbPonto
{
    [Key]
    [Column("POINTID", TypeName = "NUMBER(38)")]
    public decimal Pointid { get; set; }

    [Column("VALOR", TypeName = "NUMBER(15,2)")]
    public decimal Valor { get; set; }

    [Column("DATACREDITADO", TypeName = "DATE")]
    public DateTime Datacreditado { get; set; }

    [Column("DATAEXPIRADO", TypeName = "DATE")]
    public DateTime Dataexpirado { get; set; }

    [Column("UTILIZADO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Utilizado { get; set; } = null!;
}
