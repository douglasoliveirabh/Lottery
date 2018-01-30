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
        List<BilheteMegaSena> ObtemVencedoresQuadra();
        List<BilheteMegaSena> ObtemVencedoresQuina();
        List<BilheteMegaSena> ObtemVencedoresSena();
        void GeraBilhetesAleatorios(int quantidadeBilhetes);

    }
}
