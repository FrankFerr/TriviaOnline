using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class PartiteDomandeVM
    {
        [Key]
        public decimal Oid;

        public decimal OidPartita;

        public decimal OidDomanda;

        public string FlProposta;

        public int NmDomanda;

    }
}
