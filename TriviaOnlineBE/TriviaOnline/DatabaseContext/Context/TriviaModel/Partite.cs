﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext.Context.TriviaModel;

[Table("PARTITE")]
[Index("IdPartita", "TpPartita", Name = "PKP_PARTITE")]
public partial class Partite
{
    [Key]
    [Column("OID", TypeName = "NUMBER(38)")]
    public decimal Oid { get; set; }

    [Required]
    [Column("ID_PARTITA")]
    [StringLength(20)]
    [Unicode(false)]
    public string IdPartita { get; set; }

    [Column("DS_PARTITA")]
    [StringLength(80)]
    [Unicode(false)]
    public string DsPartita { get; set; }

    [Column("DT_CREAZIONE", TypeName = "DATE")]
    public DateTime DtCreazione { get; set; }

    [Required]
    [Column("TP_PARTITA")]
    [StringLength(1)]
    [Unicode(false)]
    public string TpPartita { get; set; }

    [Column("DS_PASSWORD")]
    [StringLength(80)]
    [Unicode(false)]
    public string DsPassword { get; set; }

    [Column("NM_PARTECIPANTI")]
    [Precision(2)]
    public byte NmPartecipanti { get; set; }

    [Column("NM_DOMANDE")]
    [Precision(2)]
    public byte NmDomande { get; set; }

    [Column("NM_RISPOSTE")]
    [Precision(2)]
    public byte NmRisposte { get; set; }

    [Column("NM_SEC_TIMEOUT_RISPOSTA")]
    [Precision(3)]
    public byte NmSecTimeoutRisposta { get; set; }

    [Required]
    [Column("FL_INIZIATA")]
    [StringLength(1)]
    [Unicode(false)]
    public string FlIniziata { get; set; }

    [Column("DT_INIZIO", TypeName = "DATE")]
    public DateTime? DtInizio { get; set; }

    [Required]
    [Column("FL_CONCLUSA")]
    [StringLength(1)]
    [Unicode(false)]
    public string FlConclusa { get; set; }

    [Column("DT_FINE", TypeName = "DATE")]
    public DateTime? DtFine { get; set; }

    [InverseProperty("OidPartitaNavigation")]
    public virtual ICollection<PartiteDomande> PartiteDomande { get; set; } = new List<PartiteDomande>();

    [InverseProperty("OidPartitaNavigation")]
    public virtual ICollection<PartiteUtenti> PartiteUtenti { get; set; } = new List<PartiteUtenti>();
}