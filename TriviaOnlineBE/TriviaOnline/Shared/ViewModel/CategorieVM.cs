using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class CategorieVM
    {

        [Key]
        public decimal Oid;

        public string IdCategoria;

        public string? DsCategoria;

        public string FlAttiva;

    }
}
