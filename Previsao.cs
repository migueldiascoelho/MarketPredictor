using System;

namespace MarketPredictor
{
    // Dados associados à previsão
    public class Previsao
    {
        public DateTime DataPrevisao { get; set; }
        public double PrecoPrevisto { get; set; }
        public double IntervaloConfianca { get; set; }
    }
}