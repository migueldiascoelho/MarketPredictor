using System; // Importa o namespace System para usar tipos e funcionalidades básicas do C#
using System.Collections.Generic; // Importa o namespace System.Collections.Generic para usar List<T>
using Microsoft.ML.Probabilistic.Distributions; // Importa o namespace Microsoft.ML.Probabilistic.Distributions para usar distribuições probabilísticas do Infer.NET
using Microsoft.ML.Probabilistic.Models; // Importa o namespace Microsoft.ML.Probabilistic.Models para usar modelos probabilísticos do Infer.NET
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

        // Método para buscar dados históricos da ação
        public async void BuscaDadosHistoricos(string simboloAcao)
        {
            try
            {
                // Busca o preço atual da ação no Yahoo Finance API
                var dadosHistoricos = await YahooFinanceApi.Yahoo.Symbols(simboloAcao).Fields(Field.RegularMarketPrice).QueryAsync();
                var dado = dadosHistoricos[simboloAcao];
                double precoAtual = dado[Field.RegularMarketPrice];

                // Log dos dados obtidos para testagem
                Console.WriteLine($"Preço atual da ação {simboloAcao}: {precoAtual}");

                // Verifica se foram encontrados dados históricos
                if (dadosHistoricos.Count == 0)
                {
                    throw new Exception("Nenhum dado histórico encontrado para a ação: " + simboloAcao);
                }

                // Extrai os valores dos dados históricos
                double[] historicoValores = new double[dadosHistoricos.Count];
                int index = 0;
                foreach (var valor in dadosHistoricos.Values)
                {
                    historicoValores[index++] = valor[Field.RegularMarketPrice];
                }

                // Chama o método para efetuar a previsão com os dados históricos
                EfetuarPrevisao(historicoValores);

                // Cria uma nova previsão (simulada para exemplo)
                var previsao = new Previsao
                {
                    DataPrevisao = DateTime.Now,
                    PrecoPrevisto = precoAtual,
                    IntervaloConfianca = 0 // Apenas como exemplo
                };

                // Atualiza as previsões com a nova previsão
                AtualizarPrevisoes(previsao);
            }
            catch (Exception ex)
            {
                // Log de erro
                Console.WriteLine($"Erro ao buscar dados históricos para a ação {simboloAcao}: {ex.Message}");

                // Relança a exceção para ser tratada pelo Controller
                throw ex;
            }
        }

        // Método para efetuar a previsão com base nos dados históricos
        public void EfetuarPrevisao(double[] dadosHistoricos)
        {
            // Cria um objeto Range que representa o índice dos dados históricos
            Microsoft.ML.Probabilistic.Models.Range T = new Microsoft.ML.Probabilistic.Models.Range(dadosHistoricos.Length);

            // Cria uma variável de array para representar os preços históricos
            VariableArray<double> precos = Variable.Array<double>(T).Named("precos");

            // Cria variáveis para a média e precisão da distribuição Gaussiana
            Variable<double> mean = Variable.GaussianFromMeanAndPrecision(0, 1).Named("mean");
            Variable<double> precision = Variable.GammaFromShapeAndScale(1, 1).Named("precision");

            // Define a distribuição Gaussiana para os preços históricos
            precos[T] = Variable.GaussianFromMeanAndPrecision(mean, precision).ForEach(T);

            // Cria uma instância do mecanismo de inferência do Infer.NET
            InferenceEngine engine = new InferenceEngine();

            // Inferência dos parâmetros do modelo
            Gaussian meanPosterior = engine.Infer<Gaussian>(mean);
            Gamma precisionPosterior = engine.Infer<Gamma>(precision);

            // Armazenar os parâmetros do modelo ou usá-los para fazer previsões futuras
        }

        // Método privado para atualizar a lista de previsões
        private void AtualizarPrevisoes(Previsao novaPrevisao)
        {
            // Adiciona a nova previsão à lista de previsões
            previsoes.Add(novaPrevisao);

            // Aciona o evento de previsão atualizada, passando a lista de previsões como argumento
            PrevisaoAtualizada?.Invoke(previsoes);
        }
    }

    // Classe Previsao para armazenar dados de previsões
    public class Previsao
    {
        public DateTime DataPrevisao { get; set; }
        public double PrecoPrevisto { get; set; }
        public double IntervaloConfianca { get; set; }
    }

    // Interface para o Model
    public interface IModel
    {
        // Declaração do evento de atualização de previsão
        event Model.PrevisaoAtualizadaEventHandler PrevisaoAtualizada;

        // Declaração do método para buscar dados históricos
        void BuscaDadosHistoricos(string simboloAcao);
    }
}
