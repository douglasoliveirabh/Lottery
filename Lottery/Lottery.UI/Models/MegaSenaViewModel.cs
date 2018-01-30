using Lottery.UI.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.UI.Models
{
    public class MegaSenaViewModel
    {        
        [NumerosValidos]
        public string Numeros { get; set; }

        public string NumerosSorteados { get; set; }

        public List<MegaSenaBilheteViewModel> Bilhetes { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesSemAcerto { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesComUmAcerto { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesComDoisAcertos { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesComTresAcertos { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesVencedoresQuadra { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesVencedoresQuina { get; set; }

        public List<MegaSenaBilheteViewModel> BilhetesVencedoresSena { get; set; }

        public MegaSenaViewModel()
        {
            Bilhetes = new List<MegaSenaBilheteViewModel>();
            BilhetesSemAcerto = new List<MegaSenaBilheteViewModel>();
            BilhetesComUmAcerto = new List<MegaSenaBilheteViewModel>();
            BilhetesComDoisAcertos = new List<MegaSenaBilheteViewModel>();
            BilhetesComTresAcertos = new List<MegaSenaBilheteViewModel>();
            BilhetesVencedoresQuadra = new List<MegaSenaBilheteViewModel>();
            BilhetesVencedoresQuina = new List<MegaSenaBilheteViewModel>();
            BilhetesVencedoresSena = new List<MegaSenaBilheteViewModel>();
        }

    }
}
