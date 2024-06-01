using System;

namespace MarketPredictor
{
    // Dados associados à previsão
    public class IPrevisao
    {
        public DateTime DataPrevisao { get; set; }
        public double PrecoPrevisto { get; set; }
        public double IntervaloConfianca { get; set; }
    }
}
