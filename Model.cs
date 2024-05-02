namespace MarketPredictor
{
    class Model
    {
        public delegate void PrevisaoAtualizadaEventHandler(List<Previsao> previsoes);
        public event PrevisaoAtualizadaEventHandler PrevisaoAtualizada;

        private List<Previsao> previsoes;

        public Model()
        {
            previsoes = new List<Previsao>();
        }

        public void BuscaDadosHistoricos(string simboloAcao)
        {
            // Busca de dados ao API da Yahoo Finance
            var dadosHistoricos = new DadosHistoricos(simboloAcao);
            EfetuarPrevisao(ref dadosHistoricos);
        }

        // Utiliza o Infer.Net para fazer a previsão
        public void EfetuarPrevisao(ref DadosHistoricos dadosHistoricos)
        {
            AtualizarPrevisoes(new Previsao());  // Simula a adição de uma nova previsão
        }

        private void AtualizarPrevisoes(Previsao novaPrevisao)
        {
            previsoes.Add(novaPrevisao);
            PrevisaoAtualizada?.Invoke(previsoes);
        }
    }
}