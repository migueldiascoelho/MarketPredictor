using System;
using System.Collections.Generic;

namespace MarketPredictor
{
    public class Model : IModel
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
            try
            {
                // Simular a busca de dados ao API da Yahoo Finance
                var dadosHistoricos = new DadosHistoricos(simboloAcao);
                if (dadosHistoricos.PrecosHistoricos.Count == 0)
                {
                    throw new Exception("Nenhum dado histórico encontrado para a ação: " + simboloAcao);
                }
                EfetuarPrevisao(ref dadosHistoricos);
            }
            catch (Exception ex)
            {
                // Relançar exceção para ser tratada pelo Controller
                throw ex;
            }
        }

        // Utiliza Infer.Net para aplicar modelos de previsão
        public void EfetuarPrevisao(ref DadosHistoricos dadosHistoricos)
        {
            // Lógica de previsão usando dados históricos
            AtualizarPrevisoes(new Previsao());  // Simula a adição de uma nova previsão
        }

        private void AtualizarPrevisoes(Previsao novaPrevisao)
        {
            previsoes.Add(novaPrevisao);
            PrevisaoAtualizada?.Invoke(previsoes);
        }
    }

    public interface IModel
    {
        event Model.PrevisaoAtualizadaEventHandler PrevisaoAtualizada;
        void BuscaDadosHistoricos(string simboloAcao);
    }
}
