﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TriviaRepository.Context.TriviaModel;

[Table("UTENTI")]
[Index("ExternalId", Name = "U_UTENTI", IsUnique = true)]
public partial class Utenti
{
    [Key]
    [Column("OID", TypeName = "NUMBER(38)")]
    public decimal Oid { get; set; }

    [Required]
    [Column("EXTERNAL_ID")]
    [StringLength(60)]
    [Unicode(false)]
    public string ExternalId { get; set; }

    [Column("ID_USERNAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string IdUsername { get; set; }

    [InverseProperty("OidUtenteNavigation")]
    public virtual ICollection<PartiteUtenti> PartiteUtenti { get; set; } = new List<PartiteUtenti>();
}