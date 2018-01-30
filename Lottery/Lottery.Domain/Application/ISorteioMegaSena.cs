using Lottery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Domain.Application
{
    /// <summary>
    /// Interface that specify my lottery type 
    /// </summary>
    public interface ISorteioMegaSena : ISorteio<BilheteMegaSena>
    {
        List<BilheteMegaSena> ObtemVencedoresQuadra(int[] numerosSorteados);
        List<BilheteMegaSena> ObtemVencedoresQuina(int[] numerosSorteados);
        List<BilheteMegaSena> ObtemVencedoresSena(int[] numerosSorteados);
        void GeraBilhetesAleatorios(int quantidadeBilhetes);

    }
}
