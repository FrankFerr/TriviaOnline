using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class DomandeVM
    {
        [Key]
        public decimal Oid;

        public decimal OidCategoria;

        public int? IdDomanda;

        public string? DsDomanda;

        public string TpDifficolta;

        public string FlAttiva;

    }
}
