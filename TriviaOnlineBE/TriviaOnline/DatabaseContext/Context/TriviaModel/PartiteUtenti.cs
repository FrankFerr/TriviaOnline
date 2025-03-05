﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext.Context.TriviaModel;

[Table("PARTITE_UTENTI")]
[Index("OidUtente", "OidPartita", Name = "PKP_PARTITE_UTENTI")]
public partial class PartiteUtenti
{
    [Key]
    [Column("OID", TypeName = "NUMBER(38)")]
    public decimal Oid { get; set; }

    [Column("OID_UTENTE", TypeName = "NUMBER(38)")]
    public decimal OidUtente { get; set; }

    [Column("OID_PARTITA", TypeName = "NUMBER(38)")]
    public decimal OidPartita { get; set; }

    [Required]
    [Column("FL_CREATA")]
    [StringLength(1)]
    [Unicode(false)]
    public string FlCreata { get; set; }

    [ForeignKey("OidPartita")]
    [InverseProperty("PartiteUtenti")]
    public virtual Partite OidPartitaNavigation { get; set; }

    [ForeignKey("OidUtente")]
    [InverseProperty("PartiteUtenti")]
    public virtual Utenti OidUtenteNavigation { get; set; }

    [InverseProperty("OidPartitaUtenteNavigation")]
    public virtual ICollection<PartiteUtentiRisposte> PartiteUtentiRisposte { get; set; } = new List<PartiteUtentiRisposte>();
}