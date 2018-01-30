using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lottery.UI.Models
{
    public class MegaSenaBilheteViewModel
    {
        public int Id { get; set; }
        public DateTime DataHoraAposta { get; set; }
        public int[] Numeros { get; set; }


        public MegaSenaBilheteViewModel(int id, int[] numeros)
        {
            this.Id = id;
            this.Numeros = numeros;
        }

    }
}
