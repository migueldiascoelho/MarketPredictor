using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPredictor
{
    // Esta classe vai ter a estrutura dos dados históricos
    // Esses dados vão ser utilizados na previsão
    public class DadosHistoricos
    {
        public string SimboloAcao { get; set; }
        public List<double> PrecosHistoricos { get; set; }

        public DadosHistoricos(string simboloAcao)
        {
            SimboloAcao = simboloAcao;
            PrecosHistoricos = new List<double>();
        }
    }
}
