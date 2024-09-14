using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TPC_Challenge_API_NET.Models;

[Table("TB_NOTIFICACOES")]
public partial class TbNotificaco
{
    [Key]
    [Column("NOTIFICACOESID", TypeName = "NUMBER(38)")]
    public decimal Notificacoesid { get; set; }

    [Column("PDVID", TypeName = "NUMBER(38)")]
    public decimal Pdvid { get; set; }

    [Column("TITULO")]
    [StringLength(255)]
    [Unicode(false)]
    public string Titulo { get; set; } = null!;

    [Column("MENSAGEM")]
    [StringLength(255)]
    [Unicode(false)]
    public string Mensagem { get; set; } = null!;

    [Column("DATAENVIO", TypeName = "DATE")]
    public DateTime Dataenvio { get; set; }

    [ForeignKey("Pdvid")]
    [InverseProperty("TbNotificacos")]
    public virtual TbLoja? Pdv { get; set; }
}
