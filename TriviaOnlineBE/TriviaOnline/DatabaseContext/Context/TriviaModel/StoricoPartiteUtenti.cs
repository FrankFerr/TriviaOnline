﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TriviaRepository.Context.TriviaModel;

[Table("STORICO_PARTITE_UTENTI")]
[Index("OidStoricoPartita", "IdUsername", Name = "PKP_STORICO_PARTITE_UTENTI")]
public partial class StoricoPartiteUtenti
{
    [Key]
    [Column("OID", TypeName = "NUMBER(38)")]
    public decimal Oid { get; set; }

    [Column("OID_STORICO_PARTITA", TypeName = "NUMBER(38)")]
    public decimal OidStoricoPartita { get; set; }

    [Column("ID_USERNAME", TypeName = "NUMBER(38)")]
    public decimal IdUsername { get; set; }

    [Column("NM_RISPOSTE_CORRETTE")]
    [Precision(2)]
    public int? NmRisposteCorrette { get; set; }

    [Column("FL_ESITO")]
    [StringLength(1)]
    [Unicode(false)]
    public string FlEsito { get; set; }

    [ForeignKey("OidStoricoPartita")]
    [InverseProperty("StoricoPartiteUtenti")]
    public virtual StoricoPartite OidStoricoPartitaNavigation { get; set; }

    [InverseProperty("OidStoricoPartitaUtenteNavigation")]
    public virtual ICollection<StoricoPartiteUtentiDom> StoricoPartiteUtentiDom { get; set; } = new List<StoricoPartiteUtentiDom>();
}