using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YahooFinanceApi;

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

        public async void BuscaDadosHistoricos(string simboloAcao)
        {
            try
            {
                // Busca o preço atual da ação no Yahoo Finance API
                var dadosHistoricos = await YahooFinanceApi.Yahoo.Symbols(simboloAcao).Fields(Field.RegularMarketPrice).QueryAsync();
                var dado = dadosHistoricos[simboloAcao];
                double precoAtual = dado[Field.RegularMarketPrice];

                var previsao = new Previsao
                {
                    DataPrevisao = DateTime.Now,
                    PrecoPrevisto = precoAtual,
                    IntervaloConfianca = 0 // Apenas como exemplo
                };

                // Log dos dados obtidos para testagem
                Console.WriteLine($"Preço atual da ação {simboloAcao}: {precoAtual}");

                AtualizarPrevisoes(previsao);
            }
            catch (Exception ex)
            {
                // Log de erro
                Console.WriteLine($"Erro ao buscar dados históricos para a ação {simboloAcao}: {ex.Message}");

                // Relançar exceção para ser tratada pelo Controller
                throw ex;
            }
        }

        // Utiliza Infer.Net para aplicar modelos de previsão
        public void EfetuarPrevisao(ref DadosHistoricos dadosHistoricos)
        {

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
