using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class UtentiVM
    {
        [Key]
        public decimal Oid { get; set; }

        public string ExternalId { get; set; }

        public string IdUsername { get; set; }

        public string IdEmail { get; set; }

        public string? FlAttivo { get; set; }
    }
}
