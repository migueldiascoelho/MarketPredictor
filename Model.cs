using System; // Importa o namespace System para usar tipos e funcionalidades básicas do C#
using System.Collections.Generic; // Importa o namespace System.Collections.Generic para usar List<T>
using System.Linq; // Importa o namespace System.Linq para usar LINQ
using System.Threading.Tasks; // Importa o namespace System.Threading.Tasks para usar async/await
using YahooFinanceApi; // Importa o namespace YahooFinanceApi para buscar dados de ações

namespace MarketPredictor // Declara o namespace MarketPredictor
{
    public class Model : IModel // Declara a classe Model
    {
        // Declaração de um delegate para manipular eventos de atualização de previsões
        public delegate void PrevisaoAtualizadaEventHandler(List<Previsao> previsoes);

        // Declaração de um evento que será acionado quando as previsões forem atualizadas
        public event PrevisaoAtualizadaEventHandler PrevisaoAtualizada;

        // Declaração de uma lista para armazenar as previsões
        private List<Previsao> previsoes;

        // Construtor da classe Model
        public Model()
        {
            // Inicializa a lista de previsões
            previsoes = new List<Previsao>();
        }

        public async void BuscaDadosHistoricos(string simboloAcao)
        {
            try
            {
                var dataFim = DateTime.Now;
                var dataInicio = dataFim.AddMonths(-24); // 24 meses de alcance
                var historico = await Yahoo.GetHistoricalAsync(simboloAcao, dataInicio, dataFim, Period.Monthly);

                // Verifica se existem dados históricos
                if (historico.Count == 0)
                {
                    throw new Exception("Nenhum dado histórico encontrado para a ação: " + simboloAcao);
                }

                // Extrai os valores de fecho dos dados históricos
                double[] historicoValores = historico.Select(d => (double)d.Close).ToArray();

                // Obtém o preço atual da ação
                var dadoAtual = await Yahoo.Symbols(simboloAcao).Fields(Field.RegularMarketPrice).QueryAsync();
                double precoAtual = dadoAtual[simboloAcao][Field.RegularMarketPrice];

                // Calcula a previsão do preço usando os dados históricos
                double previsaoPreco = EfetuarPrevisao(historicoValores);

                // Cria uma nova previsão com os dados obtidos
                var previsao = new Previsao
                {
                    DataPrevisao = DateTime.Now,
                    PrecoAtual = precoAtual,
                    PrecoPrevisto = Math.Round(previsaoPreco, 2),
                    IntervaloConfianca = 0 // Apenas como exemplo
                };

                // Atualiza a lista de previsões
                AtualizarPrevisoes(previsao);
            }
            catch (Exception ex)
            {
                // Log de erro caso ocorra uma exceção
                Console.WriteLine($"Erro ao buscar dados históricos para a ação {simboloAcao}: {ex.Message}");
                throw;
            }
        }

        // Utiliza Média Móvel Exponencial (MME) para prever o preço futuro de uma ação
        public double EfetuarPrevisao(double[] dadosHistoricos)
        {
            try
            {
                // Log dos dados históricos para debugging
                Console.WriteLine("Dados Históricos:");
                for (int i = 0; i < dadosHistoricos.Length; i++)
                {
                    Console.WriteLine($"Mês {i + 1}: {dadosHistoricos[i]}");
                }

                // Calcula o MME para os dados históricos
                double smoothingFactor = 2.0 / (dadosHistoricos.Length + 1);
                double ema = dadosHistoricos[0]; // Começa com o primeiro preço

                for (int i = 1; i < dadosHistoricos.Length; i++)
                {
                    ema = (dadosHistoricos[i] * smoothingFactor) + (ema * (1 - smoothingFactor));
                }

                // Prevê o próximo mês com MME
                double predictedPrice = ema;

                // Log do preço previsto
                Console.WriteLine($"Preço Previsto: {predictedPrice}");

                return predictedPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao efetuar previsão: {ex.Message}");
                throw;
            }
        }

        // Nova previsão
        private void AtualizarPrevisoes(Previsao novaPrevisao)
        {
            previsoes.Add(novaPrevisao);
            PrevisaoAtualizada?.Invoke(previsoes);
        }
    }

    // Interface do Model
    public interface IModel
    {
        event Model.PrevisaoAtualizadaEventHandler PrevisaoAtualizada;
        void BuscaDadosHistoricos(string simboloAcao);
    }
}