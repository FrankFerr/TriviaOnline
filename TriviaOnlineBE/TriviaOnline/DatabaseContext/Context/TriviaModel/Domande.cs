﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TriviaRepository.Context.TriviaModel;

[Table("DOMANDE")]
[Index("OidCategoria", "IdDomanda", Name = "PKP_DOMANDE")]
public partial class Domande
{
    [Key]
    [Column("OID", TypeName = "NUMBER(38)")]
    public decimal Oid { get; set; }

    [Column("OID_CATEGORIA", TypeName = "NUMBER(38)")]
    public decimal OidCategoria { get; set; }

    [Column("ID_DOMANDA")]
    [Precision(4)]
    public int? IdDomanda { get; set; }

    [Column("DS_DOMANDA")]
    [StringLength(255)]
    [Unicode(false)]
    public string DsDomanda { get; set; }

    [Required]
    [Column("TP_DIFFICOLTA")]
    [StringLength(1)]
    [Unicode(false)]
    public string TpDifficolta { get; set; }

    [Required]
    [Column("FL_ATTIVA")]
    [StringLength(1)]
    [Unicode(false)]
    public string FlAttiva { get; set; }

    [InverseProperty("OidDomandaNavigation")]
    public virtual ICollection<DomandeRisposte> DomandeRisposte { get; set; } = new List<DomandeRisposte>();

    [ForeignKey("OidCategoria")]
    [InverseProperty("Domande")]
    public virtual Categorie OidCategoriaNavigation { get; set; }

    [InverseProperty("OidDomandaNavigation")]
    public virtual ICollection<PartiteDomande> PartiteDomande { get; set; } = new List<PartiteDomande>();

    [InverseProperty("OidDomandaNavigation")]
    public virtual ICollection<PartiteUtentiRisposte> PartiteUtentiRisposte { get; set; } = new List<PartiteUtentiRisposte>();
}