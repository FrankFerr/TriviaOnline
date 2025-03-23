using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class StoricoPartiteUtentiDomVM
    {
        [Key]
        public decimal Oid;

        public decimal OidStoricoPartitaUtente;

        public string? DsCategoria;

        public string? FlCorretta;

    }
}
