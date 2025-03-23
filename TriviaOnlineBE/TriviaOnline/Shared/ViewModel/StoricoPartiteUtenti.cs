using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class StoricoPartiteUtentiVM
    {
        [Key]
        public decimal Oid;

        public decimal OidStoricoPartita;

        public int IdUsername;

        public int? NmRisposteCorrette;

        public string? FlEsito;

    }
}
