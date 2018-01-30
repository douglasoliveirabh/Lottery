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
        [Required(ErrorMessage = "Informe os números do seu bilhete")]
        [NumerosValidos]
        public string Numeros { get; set; }

        public List<MegaSenaBilheteViewModel> Bilhetes { get; private set; }

        public MegaSenaViewModel()
        {
            Bilhetes = new List<MegaSenaBilheteViewModel>();
        }

        private void AdicionaBilhete(string numeros) {           
            var maxId = Bilhetes.Max(x => x.Id);
            maxId += 1;

            var novosNumeros = numeros.Split(",").Select(x => int.Parse(x)).ToArray();
            this.Bilhetes.Add(new MegaSenaBilheteViewModel(maxId, novosNumeros));
        }




    }
}
