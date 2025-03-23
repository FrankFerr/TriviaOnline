using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModel
{
    public class StoricoPartiteVM
    {
        [Key]
        public decimal Oid;

        public string IdPartita;

        public string? DsPartita;

        public DateTime DtCreazione;

        public string TpPartita;

        public string? DsPassword;

        public int NmPartecipanti;

        public int NmDomande;

        public int NmRisposte;

        public int NmSecTimeoutRisposta;

        public string FlIniziata;

        public DateTime? DtInizio;

        public string FlConclusa;

        public DateTime? DtFine;

    }
}
