using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class PartiteUtentiVM
    {
        [Key]
        public decimal Oid;

        public decimal OidUtente;

        public decimal OidPartita;

        public string FlCreata;

    }
}
