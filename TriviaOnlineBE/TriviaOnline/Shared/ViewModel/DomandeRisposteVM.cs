using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class DomandeRisposteVM
    {
        [Key]
        public decimal Oid;

        public decimal OidDomanda;

        public int? IdRisposta;

        public string? DsRisposta;

        public string FlCorretta;

    }
}
