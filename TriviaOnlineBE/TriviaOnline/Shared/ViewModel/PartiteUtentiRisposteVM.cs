using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class PartiteUtentiRisposteVM
    {
        [Key]
        public decimal Oid;

        public decimal OidPartitaUtente;

        public decimal OidDomanda;

        public decimal OidRisposta;

        public string? FlCorretta;

    }
}
